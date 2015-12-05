using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass08{
    /// <summary>
    ///  A generic GA solver, where T is the data type of genes defined in derived classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GASolver<T>{
        // A nested delegate (data Type) declaration defining a function returning a double value 
        // while taking an argument of an array of type T
        public delegate double ObjectiveFunctionDelegate(T[] chrosome);

        // Problem associated data, which are specified via constructor
        // Delegate (function pointer in C) for the user-supplied objective evalution function.
        public ObjectiveFunctionDelegate GetObjectiveValueFunction;
        protected OptimizationType optimizationType = OptimizationType.Min;
        protected int numberOfGenes; // The length of a chromosome
        protected double goalValue;

        protected int populationSize = 20;
        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;
        protected double crossoverRate = 0.8;
        protected double mutationRate = 0.05;
        protected int iterationLimit = 1000; // The default stopping condition
        protected int iterationCount;        // Current iteration index
        SelectionMode selectionMode = SelectionMode.Deterministic;


        protected T[][] chromosomes;         // Parameterized type, specified by the derived class
		protected T[][] chromosomesbuffer;
        protected double[] objectiveValues;  // Positive or negative real numbers
        protected double[] fitnessValues;    // Must be positive values

        protected double iterationBestObjective;   // The best value obtained in the current iteration
        protected double iterationAverage;         // The objective average obtained in the current iteration

        private double soFarTheBestObjective;
        protected T[] soFarTheBestSolution;

        // Used to stochastically select pairs of parents for crossover operation.
        // Used in deterministic selection operation to sort the chromosome indices for ordered fitness
        // Used in stochastic selection operation to store the indices of chosen chromosomes
        protected int[] indices;     // Store indices of chromosome, which are subject to shuffle, sorting, inversing operations

        protected Random randomizer = new Random(DateTime.Now.Millisecond);  // Shared by all derived classes

		
		#region PropertiesRegion
		[Category("GA Setting"), Description("染色體數量，建議值是不低於變數數量的1/4。")]
        public int PopulationSize{
            get{
                return populationSize;
            }
            set{
                if (populationSize < 2) return;
                populationSize = value;
            }
        }

		
		[Category("GA Setting"), Description("交配率，建議值 0.5~0.9。")]
		public double CrossoverRate{
			get{
				return this.crossoverRate;
			}
			set{
				if(value <= 1.0 && value >= 0.0){
					this.crossoverRate = value;
				}
			}
		}

		[Category("GA Setting"), Description("以基因個數為基的突變率，建議值 0.01~0.10。")]
		public double MutationRate{
			get{
				return mutationRate;
			}
			set{
				if(value <= 0.5 && value >= 0.0){
					this.mutationRate = value;
				}
			}
		}

		[Category("GA Setting"), Description("")]
		public SelectionMode SelectionMode{
			get{
				return selectionMode;
			}
			set{
				selectionMode = value;

			}
		}

        [Browsable(false)]
        public double SoFarTheBestObjective{
            get{
                return soFarTheBestObjective;
            }
        }

        [Browsable(false)]
        public T[] SoFarTheBestSolution{
            set{
                soFarTheBestSolution = value;
            }
            get{
                return soFarTheBestSolution;
            }
        }
        [Browsable(false)]
        public int IterationCount{
            get{
                return iterationCount;
            }
        }

        public int IterationLimit{
            get{
                return iterationLimit;
            }

            set{
                iterationLimit = value;
            }
        }

		public double IterationAverage{
            get{
                return iterationAverage;
            }
        }

		public double IterationBestObjective{
            get{
                return iterationBestObjective;
            }
        }

        #endregion


        /// <summary>
        ///  To employ a GA solver, user must provide the number of variables, the optimization type, and a function delegate
        ///  that compute and return the objective value for a given solution.
        /// </summary>
        /// <param name="numberOfVariables"> Number of variables of the problem</param>
        /// <param name="opType"> The optimization problem type </param>
        /// <param name="objectFunction"> The function delegate that computer the objective value for a given solution </param>
        public GASolver(int numberOfVariables, OptimizationType opType, GASolver<T>.ObjectiveFunctionDelegate objectFunction){
            numberOfGenes = numberOfVariables;
            optimizationType = opType;
            if (objectFunction == null) throw new Exception("You must prepare an objective function.");
            GetObjectiveValueFunction = objectFunction;
			SoFarTheBestSolution = new T[numberOfGenes];
        }


        /// <summary>
        ///  This function reallocate memeory for the GA computation subject to newly
        ///  specified properties; e.g, population size. In addition, the initial population
        ///  of chromosomes are initialized.
        /// </summary>
        public virtual void reset(){
            // Allocate memory for gene related data
            chromosomes = new T[populationSize * 3][];
			chromosomesbuffer = new T[populationSize * 3][];
//...
            // Initialize the initial population
            
			int len = chromosomes.Length;
			for(int i=0; i<len; i++){
				chromosomes[i] = new T[numberOfGenes];
				chromosomesbuffer[i] = new T[numberOfGenes];
			}

			objectiveValues = new double[len];
			fitnessValues   = new double[len];
			indices = new int[len];

			initializePopulation();

			for (int j = 0; j < this.populationSize; j++)
				objectiveValues[j] = GetObjectiveValueFunction(this.chromosomes[j]);
							
			// Reset computation realted variables
            iterationCount = 0;
            soFarTheBestObjective = optimizationType == OptimizationType.Min ? double.MaxValue : double.MinValue;
        }


        /// <summary>
        ///  This function setup the indices from 0 to upLimit-1 in indice array (int[] indices).
        ///  Then, shuffle their orders randomly. 
        ///  This function is called to shuffle the indice orders of parent population to support 
        ///  pair-wise crossover operation. If x pairs of parents are to be crossovered, then
        ///  the first 2x indices are the chromosome indices of the x pair parents.
        /// </summary>
        /// <param name="upLimit"></param>
        protected void randomizeIndices(int upLimit){
            for(int i = 0; i < upLimit; i++)
				indices[i] = i;
			int rndidx, tmp;
            for(int i = upLimit - 1; i > 0; i--){
                rndidx = randomizer.Next(i+1);
				tmp = indices[rndidx];
				indices[rndidx] = indices[i];
				indices[i] = tmp;
            }
        }

        /// <summary>
        ///  Called in reset function. Overriden by the derived classes to fill-in
        ///  populationSize chromosomes with gene values of their data types.
        /// </summary>
        public virtual void initializePopulation(){

        }


        /// <summary>
        ///  Default method that carryout the whole GA computation without any interruption.
        /// </summary>
        public virtual void executeToEnd(){
            do{
                executeOneIteration();
            } while (!terminationConditionMet());
        }

        /// <summary>
        ///  A function that determine wether stopping condition is met. By default, the iteration 
        ///  limit is used and checked for termination. Derived calles can override it.
        /// </summary>
        /// <returns></returns>
        public virtual bool terminationConditionMet(){
            if (iterationCount < iterationLimit) return false;
            else return true;
        }


        /// <summary>
        ///  Standard GA computation procedure. However, derived classes may override it.
        /// </summary>
        public virtual void executeOneIteration(){
            // Crossover operation
			//Debug();
            performCrossoverOperation();
			Console.WriteLine("Crossover Finished");
            // Mutation operation
            performMutateOperation();
			Console.WriteLine("Mutation Finished");
            // Evaluate all objectives 
            computeObjectiveValues();
			Console.WriteLine("Compute Finished");
            // Transform objectives to fitness values
            setFitnessFromObjectives();
			Console.WriteLine("Fitness Finished");
            // Selection
            performSelectionOperation();
			//Debug();
			Console.WriteLine("Selection Finished");
            iterationCount++;
        }

		public void Debug(){
			
			for(int i=0; i<populationSize*3; i++){
				if(i >= 0){
					for(int j=0; j<numberOfGenes; j++){
						Console.Write(chromosomes[i][j]+" ");
					}
				//Console.Write(indices[i].ToString()+" ");
				Console.WriteLine(GetObjectiveValueFunction(chromosomes[i]).ToString());
				}
				if(i==populationSize-1)
					Console.WriteLine("pop "+populationSize.ToString());
				if(i==numberOfCrossoveredChildren+populationSize-1)
					Console.WriteLine("cro "+numberOfCrossoveredChildren.ToString());
				if(i==numberOfCrossoveredChildren+populationSize+numberOfMutatedChildren-1)
					Console.WriteLine("mut "+numberOfMutatedChildren.ToString());

			}Console.WriteLine("-------------------------------{0}", numberOfMutatedChildren+numberOfCrossoveredChildren+populationSize);
			for(int i=0; i<populationSize; i++)
				Console.Write(indices[i].ToString()+" "+objectiveValues[i].ToString()+" "+fitnessValues[i].ToString()+"\n");
		}


        /// <summary>
        ///  Standard function that evaluates original objective values for parent and children chromosomes.
        ///  During the computation, iteration best is identified and checked with the so far the best.
        ///  The so far the best objective and solution will be updated, if the iteration best surpass its value.
        ///  Specifically, this function calls the user-supplied objective value evalution function delegate to
        ///  evaluate each chromosome and put value to objectiveValues array. 
        /// </summary>
        public virtual void computeObjectiveValues(){
            int parentPlusChildren = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            for (int i = 0; i < parentPlusChildren; i++)
                objectiveValues[i] = GetObjectiveValueFunction(chromosomes[i]);
			// ...
			int iterationbestindex = -1;
            switch (optimizationType){
                case OptimizationType.Min:
					iterationBestObjective = double.MaxValue;
					iterationAverage = 0.0;
					for(int i=0; i<parentPlusChildren; i++) {
						iterationAverage += objectiveValues[i];
						if (objectiveValues[i] < iterationBestObjective){
							iterationBestObjective = objectiveValues[i];
							iterationbestindex = i;
						}
					}

					iterationAverage /= (double)parentPlusChildren;
					if(iterationBestObjective < soFarTheBestObjective) {
						soFarTheBestObjective = iterationBestObjective;
						for (int i = 0; i < numberOfGenes; i++)
							soFarTheBestSolution[i] = chromosomes[iterationbestindex][i];
					}
                    //Finished on 12/02
                    break;
                case OptimizationType.Max:
					iterationBestObjective = double.MinValue;
					iterationAverage = 0.0;
					for(int i=0; i<parentPlusChildren; i++) {
						iterationAverage += objectiveValues[i];
						if (objectiveValues[i] > iterationBestObjective){
							iterationBestObjective = objectiveValues[i];
							iterationbestindex = i;
						}
					}

					iterationAverage /= (double)parentPlusChildren;
					if(iterationBestObjective > soFarTheBestObjective) {
						soFarTheBestObjective = iterationBestObjective;
						for (int i = 0; i < numberOfGenes; i++)
							soFarTheBestSolution[i] = chromosomes[iterationbestindex][i];
					}
                    //Finished on 12/02
                    break;
                case OptimizationType.Goal:
                    iterationBestObjective = double.MinValue;
					iterationAverage = 0.0;
					for(int i=0; i<parentPlusChildren; i++) {
						iterationAverage += objectiveValues[i];
						if (Math.Abs(this.goalValue - this.objectiveValues[i]) < Math.Abs(this.goalValue - this.iterationBestObjective)){
							iterationBestObjective = objectiveValues[i];
							iterationbestindex = i;
						}
					}

					iterationAverage /= (double)parentPlusChildren;
					if(Math.Abs(goalValue - iterationBestObjective) < Math.Abs(goalValue - soFarTheBestObjective)) {
						soFarTheBestObjective = iterationBestObjective;
						for (int i = 0; i < numberOfGenes; i++)
							soFarTheBestSolution[i] = chromosomes[iterationbestindex][i];
					}
                    //Finished on 12/02
                    break;

            }
        }

        /// <summary>
        ///  This function convert original objective values into positive fitness values, such that
        ///  the better chromosome receives the larger amount of fitness. Notice that the worest one
        ///  still receive the least amount of positive fitness value.
        ///  Sepcifically, the function transform each value in objectiveValues array to the value in
        ///  fitnessValues array.
        /// </summary>
        public void setFitnessFromObjectives(){
            // Develop your own procedure to accomplish this task

            int total = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            double lowest = double.MaxValue;
			double upest  = double.MinValue;
            for (int i = 0; i < total; i++){
                if (objectiveValues[i] < lowest) lowest = objectiveValues[i];
                if (objectiveValues[i] > upest) upest = objectiveValues[i];
            }
			double basevalue = (upest - lowest) / 100.0;
			basevalue = 1E-06 > basevalue ? 1E-06 : basevalue;

			switch (optimizationType){
				case OptimizationType.Min:
					for (int i = 0; i < total; i++)
						fitnessValues[i] = basevalue + upest - objectiveValues[i];
					break;

				case OptimizationType.Max:
					for (int i = 0; i < total; i++)
						fitnessValues[i] = basevalue + objectiveValues[i] - lowest;
					break;
				case OptimizationType.Goal:
					for (int i = 0; i < total; i++)
						fitnessValues[i] = 1.0 / (basevalue + Math.Abs(objectiveValues[i] - goalValue));
					break;
			}
			//Finished on 12/02

        }

        /// <summary>
        ///  Standard crossover operation in a GA iteration. With the help of a shuffled index array (indices array)
        ///  parent chromosomes are paired for crossover operation.
        ///  This standard function calls derived class overriden generateAPairOfCrossoveredOffspring() function to 
        ///  let that function access parent chromosome (via indices) and set gene values for the children chromosome
        ///  (via indices).
        /// </summary>
        public virtual void performCrossoverOperation(){
            // Calculate the number of crossovered chromosomes (must be even number)
            numberOfCrossoveredChildren = (int)(crossoverRate * populationSize);
            if (numberOfCrossoveredChildren % 2 == 1) numberOfCrossoveredChildren++;
            if (numberOfCrossoveredChildren > populationSize) numberOfCrossoveredChildren = populationSize;
            // Randomly sort the parent indices to select the parents for pair-wise crossover
            randomizeIndices(populationSize);
            // For a pair of parent indices, prepare the successive children indices, 
            // call  generateAPairOfCrossoveredOffspring() to produce crossobered offspring
			
            for (int i = 0; i < numberOfCrossoveredChildren; i += 2){
                generateAPairOfCrossoveredOffspring(indices[i], indices[i + 1], populationSize + i, populationSize + i + 1);
            }
        }


        /// <summary>
        ///  Given two parent indices, and two children indices, this function perform crossover operation. The gene values 
        ///  of the children will be set by this function. This function must be overriden by the derived classes.
        /// </summary>
        /// <param name="fartherIdx"> index of farther chromosome </param>
        /// <param name="motherIdx"> index of mother chromosome  </param>
        /// <param name="child1Idx"> index of child 1 chromosome </param>
        /// <param name="child2Idx"> index of child 2 chromosome </param>
        public virtual void generateAPairOfCrossoveredOffspring(int fartherIdx, int motherIdx, int child1Idx, int child2Idx){
        }

        /// <summary>
        ///  This function conducts one of the primary operaion in GA compution. Since different GA codings had different
        ///  mutation operations, no standard mutation operation is available.
        ///  Derived class must override this function.
        /// </summary>
        public virtual void performMutateOperation(){

        }


        /// <summary>
        ///  This function provide standard GA selection operation. However, it allowed derived classes to override it.
        ///  Two selection modes are provided in this funciton: deterministic and stochastic.
        /// </summary>
        public virtual void performSelectionOperation(){
            // Identify the chromosome limit index, including parents, crossovered, and mutated chromosomes.
            int poolSize = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;

			if(selectionMode == SelectionMode.Deterministic){
				// Sort the fitness
				// Sort the indices from smallest fitness to the highest one
				// Revere the order to have an index list with highest fitness to the lowest
				//randomizeIndices(poolSize);
				/*
				for (int i=0;i<poolSize;i++)
					indices[i] = i;
				*/

				randomizeIndices(poolSize);
				Array.Sort<double, int>(this.fitnessValues, this.indices, 0, poolSize);
				Array.Reverse(this.indices, 0, poolSize);
				
			}
            else{
				// Normalize the fitness
				// Spin populationSize times roulette wheel to select a chromosome index each time
				if (selectionMode == SelectionMode.Stochastic){
					double totalfitness = 0.0;
					for (int i = 0; i < poolSize; i++)
						totalfitness += fitnessValues[i];
					for (int i = 0; i < poolSize; i++)
						fitnessValues[i] = fitnessValues[i] / totalfitness;
					for (int i = 1; i < poolSize; i++)
						fitnessValues[i] += fitnessValues[i - 1];

					double threshold;
					for (int j = 0; j < populationSize; j++) {
						threshold = randomizer.NextDouble();
						for (int i = 0; i < poolSize; i++) {
							if(fitnessValues[i] > threshold) {
								indices[j] = i;
								break;
							}
						}
					}					
				}
				
				/*
				Console.WriteLine("******************************************");
				for(int i=0; i<poolSize; i++){
					for(int j=0; j<numberOfGenes; j++)
						Console.Write(chromosomes[indices[i]][j].ToString()+" ");

					Console.WriteLine(objectiveValues[indices[i]].ToString());
				}
				Console.WriteLine("******************************************");
				*/
				
				//---------------------------------------------//
				
				
				// Sort the indices for the front populationSize chromosome indices
 
				// Reassign population: copy genes of selected chromosmes to the front (populationSize) chromosomes
				 // ...

			}
			
			/*for(int i = 0; i < poolSize; i++){
				for (int j = 0; j < numberOfGenes; j++){
					Console.Write(chromosomes[i][j].ToString()+" ");
				}
			 	Console.WriteLine(objectiveValues[i].ToString());
			}
			Console.WriteLine("-----------------------------------------");*/

			Array.Sort<int>(indices, 0, populationSize);

			int ptr = 0, index = -1;
			for(int i=0; i<populationSize; i++) {
				bool remained = false;
				for(int j=0; j<populationSize; j++) {
					if(indices[j]==i) {
						indices[j] = -1;
						remained = true;
						break;
					}
				}

				if(!remained) {
					index = -1;
					for(int j=ptr; j<populationSize; j++) {
						if(indices[j]>=0) {
							index = indices[j];
							ptr=j+1;
							indices[j] = -1;
							break;
						}
					}
					for(int j=0; j<numberOfGenes; j++) {
						chromosomes[i][j] = chromosomes[index][j];
					}
					objectiveValues[i] = objectiveValues[index];
				}
			}
			/*
			for(int i = 0; i < populationSize; i++)
					for (int j = 0; j < numberOfGenes; j++)
						chromosomesbuffer[i][j] = chromosomes[indices[i]][j];
			
				for(int i = 0; i < populationSize; i++){
					for (int j = 0; j < numberOfGenes; j++){
						chromosomes[i][j] = chromosomesbuffer[i][j];
						Console.Write(chromosomes[i][j].ToString()+" ");
					}
			 		Console.WriteLine(objectiveValues[indices[i]].ToString());
				}
			*/
			
			
			
		}

		 /// <summary>
        ///  This function simulate the traditional mutation operation on gene levels.
        ///  Mutated genes are selcted and corresponding parent is identified.
        ///  Mutated Parent indices are packed in indices array and the number of mutated
        ///  parents is returned.
        /// </summary>
        /// <returns> number of mutated parents </returns>
        protected int SimulateMutatedGenesMarkingAndPackParentIndicesReturnBound()
        {
            // Determine number of mutated genes
            int totalGenes = populationSize * numberOfGenes;
            int num = (int)(mutationRate * totalGenes);
            // clean the third part of gene for flagging the mutated genes
            // Mark mutated genes
            for (int i = 0; i < populationSize; i++) indices[i] = int.MaxValue;
            for (int i = 0; i < num; i++)
            {
                int seq = randomizer.Next(populationSize * numberOfGenes) / numberOfGenes;
                indices[seq] = seq;
            }
            // Pack the mutated parent ids in the front part of the indices array.
            Array.Sort(indices, 0, populationSize);

            // Loop through indices array to identify number of mutated children to be generated.
            numberOfMutatedChildren = 0;
            for (int i = 0; i < populationSize; i++)
                if (indices[i] > populationSize){
                    numberOfMutatedChildren = i;
                    break;
                }
            return numberOfMutatedChildren;
        }
    }




    /// <summary>
    ///  Type of optimization problem.
    /// </summary>
    public enum OptimizationType { Min, Max, Goal }

    /// <summary>
    ///  Type of GA selection procedure
    /// </summary>
    public enum SelectionMode { Deterministic, Stochastic }
}
