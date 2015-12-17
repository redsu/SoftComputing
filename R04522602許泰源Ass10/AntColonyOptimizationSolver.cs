using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TSP;

namespace R04522602許泰源Ass10{
    public class AntColonyOptimizationSolver{

        protected int numberOfVariables;
        protected int numberOfGroups = 1; // Used in Type2 Bin-packing problem
        protected int numberOfAnts = 40;  // Coloy size
        protected int[][] solutions;      // Default solutions are of int type
        protected double[] objectiveValues;    // Objective values of the solutions constructed by ants
        protected bool squarePheromone = true; // Default nxn matrix; for grouping problem might be gxn
        protected double initialPheromone = 0.001;  // Initail value applied to each pheromone
        protected double dropPheromone = 0.001;       // Simplest method uses this amount to drop on each segment
        protected double dropMultiplier = 1.0; // Q value; the drop amount is    dropMultiplier/objective * dropPheromone

        protected double[,] pheromone;             // Rectangular matrix (square for nxn) of the pheromone values
        protected double[,] heuristicValues;       // Matrix of the heuristic values, usually initialized from the problem

        protected double[] probabilities;    // Variables to keep the compued probabilities of the candidate elements
        protected int[] indicesOfVariables;  // The indices of the candidate elements
        protected int[] indicesOfAnts;        // Used in pheromone updating to hold indices of ants, when objective values are sorted

        protected int[] soFarTheBestSoluiton;     // The best solution obtained so far
        protected double soFarTheBestObjective;   // The best objective value obtained so far
        protected double iterationBestObjective;  // The best objective value in current iteration
        protected double iterationAverage;   // Objecive value avarage of the current iteration
		protected double greedyBestObjective;  // The best objective value in current greedy

        protected double pheromoneFactor = 1.0;  // Power factor for pheromone value in computing probabilities of candidate elements
        protected double heuristicFactor = 3.0;  // Power factor for heuristic value in computing probabilities of candidate elements
        protected double evaporationRate = 0.01; // Pheromone evaporation rate
        protected double deterministricPercentage = 0; // Value range from 0-100, 0 for pure stochastic selection, 100 for pur deterministic selection 

        protected int iterationCount = 0;        // The current iteration index
        protected int iterationLimit = 500;     // Iteration limit for stopping

        protected ObjectiveFunction getObjectiveValue = null;  // Function delegate for computing the objective value, provided by the user
        protected HeuristicFunction getHeuristicValue = null;  // Function delegate for obtaining the heruistic value, provided by the user
        protected OptimizationType optimizationType = OptimizationType.Min; // Optimization type
        protected PheromoneDropStragegy pheromoneDropMode = PheromoneDropStragegy.AllAnts; // Pheromone dropping stragegy
        protected Random randomizer = new Random(); // Random number generator
		protected K_Optimization_Type k_Optimization = K_Optimization_Type.NONE;
		protected bool local_update = false;

        // Properties Definition

        /// <summary>
        ///  The iteration limit of a default stopping condition
        /// </summary>
        [Category("Execution"), Description("演化代次上限 iteration limit")]
        public int IterationLimit{
            get { return iterationLimit; }
            set { iterationLimit = value; }
        }

        /// <summary>
        ///  Current iteration index
        /// </summary>
        [Browsable(false)]
        public int IterationCount{
            get { return iterationCount; }
        }

        /// <summary>
        ///  Power of heuristic value in selection probability calculation
        /// </summary>
        [Category("ACO Setting"), Description("選擇機率的啟發值 乘方，建議值 > 1 power factor for heuristic value ")]
        public double HeuristicFactor{
            get { return heuristicFactor; }
            set { heuristicFactor = value; }
        }

		/// <summary>
        ///  K-Optimization
        /// </summary>
        [Category("ACO Setting"), Description("K-Opt")]
        public K_Optimization_Type K_Optimization{
            get { return k_Optimization; }
            set { k_Optimization = value; }
        }

		/// <summary>
        /// Local_update
        /// </summary>
        [Category("ACO Setting"), Description("Turn On/Off Local Update")]
        public bool Local_update{
            get { return local_update; }
            set { local_update = value; }
        }
		
        /// <summary>
        ///  Power of pheromone value in selection probability calculation
        /// </summary>

		[Category("ACO Setting"), Description("選擇機率的費洛蒙值 乘方，建議值 > 1 power factor for heuristic value ")]
        public double PheromoneFactor{
            get { return pheromoneFactor; }
            set { pheromoneFactor = value; }
        }

		/// <summary>
        ///  The objective avarage of the current iteration 
        /// </summary>
		/// 
        [Browsable(false)]
        public double GreedyShortest{
            get { return greedyBestObjective; }
			set { greedyBestObjective = value; }
        }

        /// <summary>
        ///  The objective avarage of the current iteration 
        /// </summary>
		/// 
        [Browsable(false)]
        public double IterationAverage{
            get { return iterationAverage; }
        }

        /// <summary>
        ///  The iteration best objective
        /// </summary>

		[Browsable(false)]
        public double IterationBestObjective{
            get { return iterationBestObjective; }
        }

        /// <summary>
        ///  So far the best objective value
        /// </summary>
        [Browsable(false)]
        public double SoFarTheBestObjective{
            get { return soFarTheBestObjective; }
			set { soFarTheBestObjective = value; }
        }

        /// <summary>
        ///  So far the best solution
        /// </summary>

		[Browsable(false)]
        public int[] SoFarTheBestSoluiton{
            get { return soFarTheBestSoluiton; }
			set { soFarTheBestSoluiton = value; }
        }

        /// <summary>
        ///  Pheromone value set in the very begining
        /// </summary>
        [Category("ACO Setting"), Description("費洛蒙初始值 initial pheromone value")]
        public double InitialPheromone{
            get { return initialPheromone; }
            set { initialPheromone = value; }
        }

        /// <summary>
        ///  The size of the ant population; i.e., the number of artifical ants employed
        /// </summary>
        [Category("ACO Setting"), Description("蟻窩的螞蟻數 number of ant emplyed")]
        public int PopulationSize{
            get { return numberOfAnts; }
            set { numberOfAnts = value; }
        }


        [Category("ACO Setting"), Description("每代次費洛蒙蒸發率，建議值0.1  evaporation rate ")]
        public double EvaporationRate{
            get { return evaporationRate; }
            set { evaporationRate = value; }
        }

        [Category("ACO Setting"), Description("確定型選擇百分比，100: 確定型；0: 隨機型； x: 百分之x 使用確定型，百分之(100-x)使用隨機型 percentage of using deterministic selection instead of using stochastic one ")]
        public double DeterministricPercentage{
            get { return deterministricPercentage; }
            set { deterministricPercentage = value; }
        }

        /// <summary>
        ///  The stragegy of pheromone dropping.
        /// </summary>
        [Category("ACO Setting"), Description("費洛蒙添加策略 AllAnts: 所有螞蟻都添加; SoFarTheBestOnly: 只有迄今最佳解添加")]
        public PheromoneDropStragegy PheromoneDropMode{
            get { return pheromoneDropMode; }
            set { pheromoneDropMode = value; }
        }

        [Category("ACO Setting"), Description("費洛蒙添加量乘數，用以規範依目標函數值不同的添加量 multiplier of the amount of pheromone dropping that is based on the computed objective value")]
        public double DropMultiplier{
            get { return dropMultiplier; }
            set { dropMultiplier = value; }
        }

        /// <summary>
        ///  Constructor to instantitate a generic ACO sovler 
        /// </summary>
        /// <param name="numVars"> number of variables </param>
        /// <param name="optType"> optimization type </param>
        /// <param name="objFunction"> function delegate for objective value computation </param>
        /// <param name="heuristicFunction"> function delegate for heuristic value computation </param>
        /// <param name="isSquare"> whether a square pheromone matri is used </param>
        /// <param name="numGrps"> the number of groups involved for grouping problems </param>
        public AntColonyOptimizationSolver(int numVars, OptimizationType optType, ObjectiveFunction objFunction, HeuristicFunction heuristicFunction,
            bool isSquare = true, int numGrps = 1){
            getObjectiveValue = objFunction;
            getHeuristicValue = heuristicFunction;
            optimizationType = optType;
            squarePheromone = isSquare;
            numberOfGroups = numGrps;
            numberOfVariables = numVars;

            // Allocate memory for pheromone matrix and heuristic value matrix
            // Heuristic values in the matrix are computed and assigned via 
            // the specified function delegate
            if (squarePheromone){
                pheromone = new double[numberOfVariables, numberOfVariables];
				//if numberofcities larger than 200, it cost a lot of time to build the table.
				//only if number of ants larger than numberofcities, it works better.

                /*heuristicValues = new double[numberOfVariables, numberOfVariables];
                for (int r = 0; r < numberOfVariables; r++)
                    for (int c = 0; c < numberOfVariables; c++)
                        heuristicValues[r, c] = getHeuristicValue(r, c);*/
            }
            else{
                pheromone = new double[numberOfGroups, numberOfVariables];
				//if numberofcities larger than 200, it cost a lot of time to build the table.
				//only if number of ants larger than numberofcities, it works better.
                
				/*heuristicValues = new double[numberOfGroups, numberOfVariables];
                for (int r = 0; r < numberOfGroups; r++)
                    for (int c = 0; c < numberOfVariables; c++)
                        heuristicValues[r, c] = getHeuristicValue(r, c);*/
            }
            // Allocate memory for the arries used in ACO, whose length is 
            // depend on the number of variables. In contrast, those arraies 
            // with length depending on the number of ants are allocated in 
            // reset function.
            soFarTheBestSoluiton = new int[numberOfVariables];
            probabilities = new double[numberOfVariables];
            indicesOfVariables = new int[numberOfVariables];
			solutions = new int[numberOfAnts][];
            // Set drop amount multiplier; which is the avarage length
            dropMultiplier = 1.0;
        }

        /// <summary>
        ///  This function reallocate memeory for the ACO solver subject to newly
        ///  specified properties; e.g, colony size (number of ants employed).
        ///  In addition, the initial population is initialized.
        /// </summary>
        public virtual void reset(){
			solutions = new int[numberOfAnts][];
            // Allocate memory for those arraies whose lengths are depend on the number of ants
            for(int i=0; i<numberOfAnts; i++)
				solutions[i] = new int[numberOfVariables];
            // Initialize the solutons
            initializePopulation();

			// Initialize the pheromone matrix
            for(int i=0; i<numberOfVariables; i++)
				for(int j=0; j<numberOfVariables; j++)
					pheromone[i,j] = initialPheromone;
            
			// Reset counter, values, and variables whose value are update in each iteration
            iterationAverage = 0.0;
            iterationBestObjective = 0.0;
            iterationCount = 0;
			
			objectiveValues = new double[numberOfAnts];

			soFarTheBestObjective = double.MaxValue;
			soFarTheBestSoluiton = new int[numberOfVariables];
		}

        /// <summary>
        ///  Called in reset function. Overriden by the derived classes to fill-in
        ///  colony size solutions with initial values of their data types.
        /// </summary>
        public virtual void initializePopulation(){
            for (int r = 0; r < numberOfAnts; r++)
                shuffleIntegerArray(solutions[r]);
        }

        /// <summary>
        ///  Helping function to set a serial numbers to the given array
        ///  and then shuffle the numbers in the array.
        /// </summary>
        /// <param name="ary"> the target integer array </param>
        void shuffleIntegerArray(int[] ary){
			int rand, tmp;
            for (int i = 0; i < ary.Length; i++) ary[i] = i;
            for (int i = ary.Length - 1; i > 0; i--){
                rand = randomizer.Next(i+1);
				tmp = ary[rand];
				ary[rand] = ary[i];
				ary[i] = tmp;
            }
        }


        /// <summary>
        ///  Standard function that evaluates original objective values for all solutions constructed by ants.
        ///  During the computation, iteration best is identified and checked with the so far the best.
        ///  Then so far the best objective and solution will be updated, if the iteration best surpass its value.
        ///  Specifically, this function calls the user-supplied objective value evalution function delegate to
        ///  evaluate each solution and put value to objectiveValues array. 
        /// </summary>
        public virtual void computeObjectiveValues(){
			
            // Compute the objective value for each solution contructed by the ants
			indicesOfAnts = new int[numberOfAnts];

            for(int i=0; i<numberOfAnts; i++){
				objectiveValues[i] = getObjectiveValue(solutions[i]);
				indicesOfAnts[i] = i;
				iterationAverage += objectiveValues[i];
			}
			iterationAverage /= numberOfAnts;
            // Sort the objective values and ant indices in orders of superior to inferior
			Array.Sort<double, int>(objectiveValues, indicesOfAnts, 0, numberOfAnts);
			if(optimizationType == OptimizationType.Max){
				Array.Reverse(objectiveValues);
				Array.Reverse(indicesOfAnts);
			}

			if(optimizationType == OptimizationType.Min)
				iterationBestObjective = objectiveValues[0];

            // Find iteration best and compare it with the so far the best
            // Update the best solution and solution with the iteration best, if the later is
            // better than the former
            if ((iterationBestObjective < soFarTheBestObjective && optimizationType == OptimizationType.Min) ||
                (iterationBestObjective > soFarTheBestObjective && optimizationType == OptimizationType.Max)){
                soFarTheBestObjective = iterationBestObjective;
				soFarTheBestSoluiton = (int[])solutions[indicesOfAnts[0]].Clone();
            }
			dropMultiplier = getObjectiveValue(soFarTheBestSoluiton);
        }


        /// <summary>
        ///  Standard GA computation procedure. However, derived classes may override it.
        /// </summary>
        public virtual void executeOneIteration(){
            // Each ant constructs a solution
            antsConstructSolutions();
            // Evaluate all objectives 
            computeObjectiveValues();
            // Update the pheromone based on the type of ACO method
            updatePheromone();
            // Forward the iteation count
            iterationCount++;
        }


        /// <summary>
        ///  This virtual function implement the traditional pheromone update method.
        ///  All ants are granted rights to drop pheromone on their constructed trail.
        ///  After that, all pheromone values are subjected to value evaporation.
        ///  Different ACO methods should override this function to carry out their
        ///  implementations.
        /// </summary>
        public virtual void updatePheromone(){
            // Evaporate the pheromone for all pheromone values
            for (int r = 0; r < pheromone.GetLength(0); r++)
                for (int c = 0; c < pheromone.GetLength(1); c++)
                    pheromone[r, c] *= (1.0 - evaporationRate);

			// Loop throught each solution, identify the element indices for each segment
            // Add pheromone drop amount to the identified segment
			switch (pheromoneDropMode){
                case PheromoneDropStragegy.AllAnts:
					for (int i = 0; i < numberOfAnts; i++){
                        for (int j = 1; j < numberOfVariables; j++)
                            pheromone[solutions[i][j-1], solutions[i][j]] += dropPheromone * dropMultiplier / objectiveValues[i];
						pheromone[solutions[i][numberOfVariables-1], solutions[i][0]] += dropPheromone * dropMultiplier / objectiveValues[i];
					}
                    break;
                case PheromoneDropStragegy.SoFarTheBestOnly:
                    for (int j = 1; j < numberOfVariables; j++)
                        pheromone[soFarTheBestSoluiton[j-1], soFarTheBestSoluiton[j]] += dropPheromone * dropMultiplier / soFarTheBestObjective;
                    pheromone[soFarTheBestSoluiton[numberOfVariables - 1], soFarTheBestSoluiton[0]] += dropPheromone * dropMultiplier / soFarTheBestObjective;
                    break;
            }
            
        }

        /// <summary>
        ///  This virtual function implements the default solution construction for all
        ///  ants. The first element is randomly selected, then the selection is based on
        ///  the probabilities computions on each candidate. Probability computation requires
        ///  the pheromone and heuristic values. Stochastic selecion is conducted to select
        ///  the next element to succeed the previous element. 
        /// </summary>
        public virtual void antsConstructSolutions(){
            // Set the selection mode
            bool isDeterministic = false;
            int start, next;
			double P_x;
			
            if (deterministricPercentage == 1.0) isDeterministic = true;
            else if (deterministricPercentage == 0.0) isDeterministic = false;
            else
                if (randomizer.NextDouble() <= deterministricPercentage) isDeterministic = true;
                else isDeterministic = false;
            double mindis;

            // Loop through each ant to construt each solution
            for (int i = 0; i < numberOfAnts; i++){
                // Prepare candidate set, using indicesOfVariables array.
				for(int j=0; j<numberOfVariables; j++)
					indicesOfVariables[j] = solutions[i][j] = -1;				

				start = randomizer.Next(numberOfVariables);
				indicesOfVariables[start] = solutions[i][0] = start;
				double B = TSPBenchmark.MinimalTourDistance / TSPBenchmark.NumberOfCities;
				if (TSPBenchmark.HasOptimalObjective)  B = TSPBenchmark.MinimalTourDistance / TSPBenchmark.NumberOfCities;
				else B = TSPBenchmark.AverageDistance / 5.0;

                if (isDeterministic)
                    // Repeatly select the next element to succeed the previous one, until the solution is completed.
                    // Deterministic method, find the best candidate, by evaluating their selection probability
                    for (int j = 1; j < numberOfVariables; j++){
                        // Compute the probabilities for each candidate to succeed the previous element
						// Directly select the element with the largest probability 
						P_x = double.MinValue;
						next = -1;
                        for(int k = 0; k < numberOfVariables; k++){

							mindis = TSPBenchmark.FromToDistanceMatrix[solutions[i][j-1],k];

							if(indicesOfVariables[k]==-1)
								probabilities[k] = Math.Pow(pheromone[solutions[i][j-1],k], pheromoneFactor) * Math.Pow(mindis < 0.000001 ? 0.0 : B / mindis + 0.0000001, heuristicFactor) + 0.000001;
							else
								probabilities[k] = 0.0;

							if(probabilities[k]>P_x && indicesOfVariables[k]==-1){
								P_x = probabilities[k];
								next = k;
							}
						}

						// The candidate reduced by one
						solutions[i][j] = next;
						indicesOfVariables[next] = next;

						if(local_update){
							pheromone[solutions[i][j-1],next] *= (1-evaporationRate);
							pheromone[solutions[i][j-1],next] += evaporationRate * dropPheromone * dropMultiplier / greedyBestObjective;
						}
                    }
                else{
                    // Repeatly select the next element to succeed the previous one, until the solution is completed.
                    // Stochastic method, probability of all candidates are computed first. Then stochastic selection
                    // is conducted to select the next element
					double totalprobability = 0.0;

                    for (int j = 1; j < numberOfVariables; j++){
                        // Compute the probabilities for each candidate that succeeds the previous element
						totalprobability = 0.0;
                        for(int k = 0; k < numberOfVariables; k++){							

							mindis = TSPBenchmark.FromToDistanceMatrix[solutions[i][j-1],k];

							if(indicesOfVariables[k]==-1)
								probabilities[k] = Math.Pow(pheromone[solutions[i][j-1],k], pheromoneFactor) * Math.Pow(mindis < 0.000001 ? 0.0 : B / mindis + 0.0000001, heuristicFactor) + 0.000001;
							else
								probabilities[k] = 0.0;

							totalprobability += probabilities[k];
						}
						if(totalprobability > 0.000001){
							probabilities[0] /= totalprobability;
							for(int k=1; k<numberOfVariables; k++)
								probabilities[k] += probabilities[k-1]+probabilities[k]/totalprobability;
						}
						else{
							probabilities[0] = 1.0/(numberOfVariables-j);
							for(int k=1; k<numberOfVariables; k++)
								if(indicesOfVariables[k]==-1)
									probabilities[k] += probabilities[k-1]+probabilities[0];
								else
									probabilities[k] = probabilities[k-1];
						}
                        // Stochastically select one variable to succeed the previous one
                        double selectposition = randomizer.NextDouble();

                        for(int k=0; k<numberOfVariables; k++)
							if(probabilities[k] >= selectposition && indicesOfVariables[k]==-1){
								solutions[i][j] = k;
								indicesOfVariables[k] = k;
								break;
							}
                    }
                }
				
				if(k_Optimization == K_Optimization_Type.Two_Opt){
					int first, second, tmp;
					double tObjective = getObjectiveValue(solutions[i]);
					first = randomizer.Next(numberOfVariables);
					do{
						second = randomizer.Next(numberOfVariables);
					}while(first == second);
					
					tmp = solutions[i][first];
					solutions[i][first] = solutions[i][second];
					solutions[i][second] = tmp;

					if(getObjectiveValue(solutions[i])> tObjective){
						tmp = solutions[i][first];
						solutions[i][first] = solutions[i][second];
						solutions[i][second] = tmp;
					}
				}				
            }
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
        ///  Default method that carryout the whole ACO computation without any interruption.
        /// </summary>
        public virtual void executeToEnd(){
            do{
                executeOneIteration();
            } while (!terminationConditionMet());
        }
    }


    public delegate double ObjectiveFunction(int[] aSolution);
    public delegate double HeuristicFunction(int first, int second);
    public enum PheromoneDropStragegy { AllAnts, SoFarTheBestOnly };
	public enum K_Optimization_Type{ NONE, Two_Opt};
}