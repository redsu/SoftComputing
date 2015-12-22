using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using COP;
namespace R04522602許泰源Ass11{
	class PSOSolver{
		ObjectiveFunctionDelegate GetObjectiveValue = null;
		COPBenchmark COP_Problem;
		Random randomizer = new Random();
		double[] upperbound, lowerbound;
		double[] soFarTheBestSolution;

		double[][] individualBestSolution;
		double[] individualBestValues;

		double[][] solutions;
		double[] objectiveValues;

		double soFarTheBestObjective = 0.0;
		double goal = 0.0;
		double c1 = 1.0, c2 = 1.0;

		OptimizationType optimizationType = OptimizationType.Min;
		LearningType learningType = LearningType.Random;

		int iteration_count = 0;
		int iteration_limit = 100;
		int numberOfVariables = 0;
		int numberOfParticles = 20;

		#region PropertiesRegion
			[Category("PSO Setting"), Description("")]
			public int Iteration_Limit{
				get { return iteration_limit; }
				set { iteration_limit = value; }
			}
			
			[Category("PSO Setting"), Description("")]
			public int NumberOfParticles{
				get { return numberOfParticles; }
				set { numberOfParticles = value; }
			}

			[Category("PSO Setting"), Description("")]
			public double Goal{
				get { return goal; }
				set { goal = value; }
			}

			[Category("PSO Setting"), Description("")]
			public double CognitionFactor{
				get { return c1; }
				set { c1 = value; }
			}

			[Category("PSO Setting"), Description("")]
			public double SocialFactor{
				get { return c2; }
				set { c2 = value; }
			}

			[Category("PSO Setting"), Description("")]
			public OptimizationType Optimization_Type{
				get { return optimizationType; }
				set { optimizationType = value; }
			}

			[Category("PSO Setting"), Description("")]
			public LearningType Learning_Type{
				get { return learningType; }
				set { learningType = value; }
			}

			[Browsable(false)]
			public double SoFarTheBestObjective{
				get {return soFarTheBestObjective; }
			}

			[Browsable(false)]
			public double[][] Solutions{
				get {return solutions; }
			}

			[Browsable(false)]
			public double[] ObjectiveValues{
				get {return objectiveValues; }
			}

			[Browsable(false)]
			public double[] SoFarTheBestSolution{
				get {return soFarTheBestSolution; }
			}
		#endregion
		
//		public PSOSolver(int dim, ObjectiveFunctionDelegate ObjFunc, double[] upper, double[] lower, OptimizationType opt_type){
		public PSOSolver(COPBenchmark COP_Problem, OptimizationType opt_type){
			this.COP_Problem = COP_Problem;
			numberOfVariables = COP_Problem.Dimension;
			upperbound = COP_Problem.UpperBound;
			lowerbound = COP_Problem.LowerBound;
			GetObjectiveValue = COP_Problem.GetObjectiveValue;
			optimizationType = opt_type;

			soFarTheBestSolution = new double[numberOfVariables];
		}

		public void Reset(){
			int i;

			individualBestSolution = new double[numberOfParticles][];
			solutions = new double[numberOfParticles][];

			for(i=0; i<numberOfParticles; i++){
				individualBestSolution[i] = new double[numberOfVariables];
				solutions[i] = new double[numberOfVariables];
			}

			objectiveValues = new double[numberOfParticles];
			individualBestValues = new double[numberOfParticles];

			Initialization();
			iteration_count = 0;
		}

		private void Initialization(){
			int i, j;
			if(optimizationType == OptimizationType.Min)
				soFarTheBestObjective = double.MaxValue;
			else
				soFarTheBestObjective = double.MinValue;

			for(i=0; i<numberOfParticles; i++){
				for(j=0; j<numberOfVariables; j++){
					solutions[i][j] = individualBestSolution[i][j] = lowerbound[j] + randomizer.NextDouble() * (upperbound[j]-lowerbound[j]);
					/*if(j>=2)
						solutions[i][j] = 0;*/
				}
				individualBestValues[i] = objectiveValues[i] = GetObjectiveValue(individualBestSolution[i]);
				
				switch(optimizationType){
					case OptimizationType.Min:
						if(individualBestValues[i] < soFarTheBestObjective){
							soFarTheBestObjective = individualBestValues[i];
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = individualBestSolution[i][j];
						}
						break;

					case OptimizationType.Max:
						if(individualBestValues[i] > soFarTheBestObjective){
							soFarTheBestObjective = individualBestValues[i];
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = individualBestSolution[i][j];
						}
						break;

					case OptimizationType.Goal:
						if(Math.Abs(individualBestValues[i]-goal) < Math.Abs(soFarTheBestObjective-goal)){
							soFarTheBestObjective = individualBestValues[i];
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = individualBestSolution[i][j];
						}
						break;
				}
			}
		}

		public void MoveParticlesToNewPositions_AND_UpdateTheBestPositions(){
            // Referring to so far the best and each individual best 
            // Move to new position to set new solutions
			int i, j;
			double alpha = 1.0, beta = 1.0; //cognition and social learning factors
			double normalization = 1.0;
			double tempObj = 0.0;			

			for(i=0; i<numberOfParticles; i++){
				switch(learningType){
					case LearningType.Random:
						alpha = randomizer.NextDouble() * c1;
						beta  = randomizer.NextDouble() * c2;
						break;
				
					case LearningType.Heuristic:
						normalization = Math.Abs(individualBestValues[i] - objectiveValues[i]) + Math.Abs(soFarTheBestObjective - objectiveValues[i]);
						alpha = Math.Abs(individualBestValues[i] - objectiveValues[i]);
						beta  = Math.Abs(soFarTheBestObjective - objectiveValues[i]);

						if(normalization >= 0.000001){
							alpha = alpha/normalization * c1 * randomizer.NextDouble();
							beta  = beta/normalization  * c2 * randomizer.NextDouble();
						}
						else{
							alpha = randomizer.NextDouble() * c1;
							beta  = randomizer.NextDouble() * c2;
						}

						break;
				}
				for(j=0; j<numberOfVariables; j++){
					solutions[i][j] += alpha * (individualBestSolution[i][j] - solutions[i][j]) + beta * (soFarTheBestSolution[j] - solutions[i][j]);
					/*if(j>=2)
						solutions[i][j] = 0;*/
				}
				//Update Best Solution
				tempObj = objectiveValues[i] = GetObjectiveValue(solutions[i]);
				if(tempObj == soFarTheBestObjective){
					double[] gradient_vector;
					double[] tempsolution = new double[numberOfVariables];
					double gv_factor = randomizer.NextDouble();
					gradient_vector = COP_Problem.GetGradientVector(solutions[i]);
					if(gradient_vector!=null){
						for(j=0; j<numberOfVariables; j++)
							tempsolution[j] = solutions[i][j] - gradient_vector[j] * gv_factor;
					
						tempObj = GetObjectiveValue(tempsolution);
						if(tempObj < objectiveValues[i]){
							objectiveValues[i] = tempObj;
							for(j=0; j<numberOfVariables; j++){
								solutions[i][j] = tempsolution[j];
								/*if(j>=2)
									solutions[i][j] = 0;*/
							}
						}
					}
				}
				switch(optimizationType){
					case OptimizationType.Min:
						if(tempObj < individualBestValues[i]){
							individualBestValues[i] = tempObj;
							for(j=0; j<numberOfVariables; j++)
								individualBestSolution[i][j] = solutions[i][j];
						}
						if(tempObj < soFarTheBestObjective){
							soFarTheBestObjective = tempObj;
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = solutions[i][j];
						}
						break;

					case OptimizationType.Max:
						if(tempObj > individualBestValues[i]){
							individualBestValues[i] = tempObj;
							for(j=0; j<numberOfVariables; j++)
								individualBestSolution[i][j] = solutions[i][j];
						}
						if(tempObj > soFarTheBestObjective){
							soFarTheBestObjective = tempObj;
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = solutions[i][j];
						}
						break;

					case OptimizationType.Goal:
						if(Math.Abs(tempObj-goal) < Math.Abs(individualBestValues[i]-goal)){
							individualBestValues[i] = tempObj;
							for(j=0; j<numberOfVariables; j++)
								individualBestSolution[i][j] = solutions[i][j];
						}
						if(Math.Abs(tempObj-goal) < Math.Abs(soFarTheBestObjective-goal)){
							soFarTheBestObjective = tempObj;
							for(j=0; j<numberOfVariables; j++)
								soFarTheBestSolution[j] = solutions[i][j];
						}
						break;
				}
			}
        }

        public void UpdateTheBestPositions(){
            // Evaluate objectives; find iteration best, update individual best

            // Check if so far the best can be updated
			;
        }

		public void RunOneIteration(){
			MoveParticlesToNewPositions_AND_UpdateTheBestPositions();
		}
	}

	public delegate double ObjectiveFunctionDelegate(double[] aSolution);
	public enum LearningType { Random, Heuristic};
}
