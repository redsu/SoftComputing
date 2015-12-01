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

        protected Random randomizer = new Random();  // Shared by all derived classes

		
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

// ...

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
        }


        /// <summary>
        ///  This function reallocate memeory for the GA computation subject to newly
        ///  specified properties; e.g, population size. In addition, the initial population
        ///  of chromosomes are initialized.
        /// </summary>
        public virtual void reset(){
            // Allocate memory for gene related data
            chromosomes = new T[populationSize * 3][];
//...
            // Initialize the initial population
            //initializePopulation();
			int len = chromosomes.Length;
			for(int i=0; i<len; i++)
				chromosomes[i] = new T[numberOfGenes];

			soFarTheBestSolution = new T[numberOfGenes];
			objectiveValues = new double[len];
			fitnessValues   = new double[len];
			indices = new int[len];
			
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
            for(int i = upLimit - 1; i > 0; i--){
                int rndidx = randomizer.Next(i+1);
				Swap(indices, i, rndidx);
            }
        }

		public void Swap(int[] indices, int i, int j){
			int tmp = indices[i];
			indices[i] = indices[j];
			indices[j] = tmp;
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
            performCrossoverOperation();
            // Mutation operation
            performMutateOperation();
            // Evaluate all objectives 
            computeObjectiveValues();
            // Transform objectives to fitness values
            setFitnessFromObjectives();
            // Selection
            performSelectionOperation();

            iterationCount++;
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

            switch (optimizationType){
                case OptimizationType.Min:
                    //...
                    break;
                case OptimizationType.Max:
                    //...
                    break;
                case OptimizationType.Goal:
                    // ...
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
            double lowest = double.MaxValue; double upest = double.MinValue;
            for (int i = 0; i < total; i++){
                if (objectiveValues[i] < lowest) lowest = objectiveValues[i];
                if (objectiveValues[i] > upest) upest = objectiveValues[i];
            }
			//...

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
            numberOfCrossoveredChildren = (int)(mutationRate * populationSize);
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

            if (selectionMode == SelectionMode.Deterministic){
                // Sort the fitness
                 // Sort the indices from smallest fitness to the highest one
                 // Revere the order to have an index list with highest fitness to the lowest
             }
            else if (selectionMode == SelectionMode.Stochastic){
                // Normalize the fitness
                     // Spin populationSize times roulette wheel to select a chromosome index each time
                     // ...
             }

            // Sort the indices for the front populationSize chromosome indices
 
            // Reassign population: copy genes of selected chromosmes to the front (populationSize) chromosomes
 // ...

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
