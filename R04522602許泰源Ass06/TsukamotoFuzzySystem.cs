using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	class TsukamotoFuzzySystem : FuzzyInferenceSystem{
		public TsukamotoFuzzySystem(List<IfThenFuzzyRule> all) : base(all){
			;
		}

		public override double FuzzyInCrispOutInferencing(List<FuzzySet> condition){
			double x = 0.0;
			for(int i=0; i<allRules.Count; i++){
				x += allRules[i].FuzzyInCrispOutInferencing(condition);
			}
			return x;
		}

		public override double CrispInCrispOutInferencing(List<double> condition, DefuzzificationType type){
			double x = 0.0;
			for(int i=0; i<allRules.Count; i++){
				x += allRules[i].CrispInCrispOutInferencing(condition);
			}
			return x;
		}

		public override FuzzySet FuzzyInFuzzyOutInferencing(List<FuzzySet> condition){
	        throw new Exception("No implementation of FuzzyInFuzzyOutInferencing() for TsukamotoFuzzySystem");
        }
	}
}
