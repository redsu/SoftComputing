using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	class SugenoIfThenRule : IfThenFuzzyRule{
		int output_Equ;
		public SugenoIfThenRule(List<FuzzySet> ant, FuzzySet cc, bool isCut, int out_Equ) : base(ant, cc, isCut){
			output_Equ = out_Equ;
		}

		public override double CrispInCrispOutInferencing(List<double> condition){
			double x = double.MaxValue;
			
			for (int i = 0; i < antecedent.Count; i++){
				double functionValue = antecedent[i].GetFunctionValue(condition[i]);
				x = functionValue > x ? x : functionValue;
			}
			return x * GetOutputValue(condition);
		}

		public override double FuzzyInCrispOutInferencing(List<FuzzySet> condition){
			double x = double.MaxValue;
			List<double> list = new List<double>();
			for (int i = 0; i < antecedent.Count; i++){
				double maxDegree = (this.antecedent[i] & condition[i]).MaxDegree;
				x = maxDegree > x ? x : maxDegree;
				list.Add(condition[i].MaxDegreeMember);
			}
			return x * this.GetOutputValue(list);
		}

		public double GetOutputValue(List<double> inputs){
			double output = 0.0;
			try{
				switch (output_Equ){
				case 0:
					output = 0.1 * inputs[0] + 6.4;
					return output;
				case 1:
					output = 0.5 * inputs[0] + 4.0;
					return output;
				case 2:
					output = inputs[0] - 2.0;
					return output;
				case 3:
					output = -inputs[0] + inputs[1] + 1.0;
					return output;
				case 4:
					output = -inputs[1] + 3.0;
					return output;
				case 5:
					output = -inputs[0] + 3.0;
					return output;
				case 6:
					output = inputs[0] + inputs[1] + 2.0;
					return output;
				}
			}
			catch{
			}
			output = 0.0;
			return output;
		}
	}
}
