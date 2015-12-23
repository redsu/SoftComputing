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

		double[] gradient_vector;

		double soFarTheBestObjective = 0.0;
		double goal = 0.0;
		double c1 = 1.0, c2 = 1.0;
		double iterationBest;
		double iterationAverage;

		OptimizationType optimizationType = OptimizationType.Min;
		LearningType learningType = LearningType.Random;

		int iteration_limit = 100;
		int numberOfVariables = 0;
		int numberOfParticles = 20;
		int iteration_count = 0;

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
				set { 
					if(value == LearningType.Gradient && (optimizationType == OptimizationType.Max || optimizationType == OptimizationType.Goal))
						learningType = learningType;
					else
						learningType = value;
				}
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

			[Browsable(false)]
			public int Iteration_count{
				get {return iteration_count; }
			}

			[Browsable(false)]
			public double IterationAverage{
				get {return iterationAverage; }
			}

			[Browsable(false)]
			public double IterationBest{
				get {return iterationBest; }
			}
		#endregion
		
		public PSOSolver(COPBenchmark COP_Problem, OptimizationType opt_type){
			this.COP_Problem = COP_Problem;
			numberOfVariables = COP_Problem.Dimension;
			upperbound = COP_Problem.UpperBound;
			lowerbound = COP_Problem.LowerBound;
			GetObjectiveValue = COP_Problem.GetObjectiveValue;
			optimizationType = opt_type;

			soFarTheBestSolution = new double[numberOfVariables];
			iteration_count = 0;
		}

		public void Reset(){
			int i;
			iteration_count = 0;
			individualBestSolution = new double[numberOfParticles][];
			solutions = new double[numberOfParticles][];

			for(i=0; i<numberOfParticles; i++){
				individualBestSolution[i] = new double[numberOfVariables];
				solutions[i] = new double[numberOfVariables];
			}

			objectiveValues = new double[numberOfParticles];
			individualBestValues = new double[numberOfParticles];

			Initialization();
		}

		private void Initialization(){
			int i, j;
			if(optimizationType == OptimizationType.Min)
				soFarTheBestObjective = double.MaxValue;
			else
				soFarTheBestObjective = double.MinValue;

			for(i=0; i<numberOfParticles; i++){
				for(j=0; j<numberOfVariables; j++)
					solutions[i][j] = individualBestSolution[i][j] = lowerbound[j] + randomizer.NextDouble() * (upperbound[j]-lowerbound[j]);
				
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
			if(optimizationType == OptimizationType.Min){
				iterationBest = double.MaxValue;
			}
			else{
				iterationBest = double.MinValue;
			}

			iterationAverage = 0.0;

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
						double normalizationa = 0.0, normalizationb = 0.0;
						gradient_vector = new double[numberOfVariables];
						for(j=0; j<numberOfVariables; j++){
							gradient_vector[j] = (individualBestSolution[i][j] - solutions[i][j]);
							normalizationa += gradient_vector[j]*gradient_vector[j];
							gradient_vector[j] = (soFarTheBestSolution[j] - solutions[i][j]);
							normalizationb += gradient_vector[j]*gradient_vector[j];
						}
						normalizationa = Math.Sqrt(normalizationa);
						normalizationb = Math.Sqrt(normalizationb);
						
						if(normalizationa > 0.000001 && normalizationb > 0.000001)
							for(j=0; j<numberOfVariables; j++)
								solutions[i][j] += alpha * (individualBestSolution[i][j] - solutions[i][j])/normalizationa + beta * (soFarTheBestSolution[j] - solutions[i][j])/normalizationb;
						else
							for(j=0; j<numberOfVariables; j++)
								solutions[i][j] += alpha * (individualBestSolution[i][j] - solutions[i][j]) + beta * (soFarTheBestSolution[j] - solutions[i][j]);
						break;

					case LearningType.Gradient:
						gradient_vector = Gradient(solutions[i]);
						if(optimizationType == OptimizationType.Min)
							for(j=0; j<numberOfVariables; j++){
								solutions[i][j] += gradient_vector[j];
								if(solutions[i][j] >= upperbound[j])
									solutions[i][j] = upperbound[j];
								if(solutions[i][j] <= lowerbound[j])
									solutions[i][j] = lowerbound[j];
							}
						else if(optimizationType == OptimizationType.Max)
							for(j=0; j<numberOfVariables; j++){
								solutions[i][j] -= gradient_vector[j];
								if(solutions[i][j] >= upperbound[j])
									solutions[i][j] = upperbound[j];
								if(solutions[i][j] <= lowerbound[j])
									solutions[i][j] = lowerbound[j];
							}
						break;
				}
				if(learningType!=LearningType.Gradient || learningType!=LearningType.Heuristic)
					for(j=0; j<numberOfVariables; j++)
						solutions[i][j] += alpha * (individualBestSolution[i][j] - solutions[i][j]) + beta * (soFarTheBestSolution[j] - solutions[i][j]);
					
				//Update Best Solution
				tempObj = objectiveValues[i] = GetObjectiveValue(solutions[i]);
				
				
				if(tempObj == soFarTheBestObjective){
					double[] tempsolution = new double[numberOfVariables];
					double gv_factor = randomizer.NextDouble();
					gradient_vector = COP_Problem.GetGradientVector(solutions[i]);
					
					if(COP_Problem.GradientComputationCode != ""){
						if(optimizationType == OptimizationType.Min)
							for(j=0; j<numberOfVariables; j++)
								tempsolution[j] = solutions[i][j] - gradient_vector[j] * gv_factor;
						else if(optimizationType == OptimizationType.Max)
							for(j=0; j<numberOfVariables; j++)
								tempsolution[j] = solutions[i][j] + gradient_vector[j] * gv_factor;

						tempObj = GetObjectiveValue(tempsolution);
						
						if(optimizationType == OptimizationType.Min)
							if(tempObj < objectiveValues[i]){
								objectiveValues[i] = tempObj;
								for(j=0; j<numberOfVariables; j++)
									solutions[i][j] = tempsolution[j];
							}
						else if(optimizationType == OptimizationType.Max)
								if(tempObj > objectiveValues[i]){
								objectiveValues[i] = tempObj;
								for(j=0; j<numberOfVariables; j++)
									solutions[i][j] = tempsolution[j];
							}
					}
					else{
						gradient_vector = Gradient(solutions[i]);
						if(optimizationType == OptimizationType.Min)
							for(j=0; j<numberOfVariables; j++){
								solutions[i][j] += gradient_vector[j];
								if(solutions[i][j] >= upperbound[j])
									solutions[i][j] = upperbound[j];
								if(solutions[i][j] <= lowerbound[j])
									solutions[i][j] = lowerbound[j];
							}
						else if(optimizationType == OptimizationType.Max)
							for(j=0; j<numberOfVariables; j++){
								solutions[i][j] -= gradient_vector[j];
								if(solutions[i][j] >= upperbound[j])
									solutions[i][j] = upperbound[j];
								if(solutions[i][j] <= lowerbound[j])
									solutions[i][j] = lowerbound[j];
							}

					}
				}
				switch(optimizationType){
					case OptimizationType.Min:
						if(tempObj < iterationBest)
							iterationBest = tempObj;
						
						iterationAverage += tempObj;
	
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
						if(tempObj > iterationBest)
							iterationBest = tempObj;
						
						iterationAverage += tempObj;

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
						if(Math.Abs(tempObj - goal) < Math.Abs(iterationBest - goal))
							iterationBest = tempObj;
						
						iterationAverage += tempObj;

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
			iterationAverage /= (double)numberOfParticles;
        }

		public void RunOneIteration(){
			MoveParticlesToNewPositions_AND_UpdateTheBestPositions();
			iteration_count ++;
		}

		public double[] Gradient(double[] solution){
			double[] Grad = new double[numberOfVariables];
			double dx = 1.0, df = 100.0, fv1 = 0.0, fv2 = 0.0, fv0 = 0.0;
			int i;
			bool found;
			for(i=0; i<numberOfVariables; i++){
				df = 5.0;
				found = false;			
				fv1 = fv2 = double.MaxValue;
				Grad[i] = 0.0;
				fv0 = GetObjectiveValue(solution);
				do{
					dx = (upperbound[i]-lowerbound[i])/df;
					solution[i] += dx;
					if(solution[i]<=upperbound[i])
						fv1 = GetObjectiveValue(solution);
					solution[i] -= dx*2;
					if(solution[i]>=lowerbound[i])
						fv2 = GetObjectiveValue(solution);
					solution[i] += dx;
					

					if(fv1 < (fv0<fv2?fv0:fv2)){
						Grad[i] = dx;
						found = true;
						if(solution[i]+Grad[i] > upperbound[i])
							Grad[i] = upperbound[i] - solution[i];
					}
					else if(fv2 < (fv0<fv1?fv0:fv1)){
						Grad[i] = -dx;
						found = true;
						if(solution[i]+Grad[i] < lowerbound[i])
							Grad[i] = lowerbound[i] - solution[i];
					}
					
					if(!found){
						Grad[i] = 0.0;
						df *= 2.0;
					}

					if(dx < 0.000001)
						found = true;
				}while(!found);
			}

			return Grad;
		}
	}

	public delegate double ObjectiveFunctionDelegate(double[] aSolution);
	public enum LearningType { Random, Heuristic, Gradient};
}
