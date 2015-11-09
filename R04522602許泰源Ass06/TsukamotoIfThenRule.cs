using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	public  class TsukamotoIfThenRule : IfThenFuzzyRule{
        FuzzySet monotonic;

        public TsukamotoIfThenRule(List<FuzzySet> ant, FuzzySet cc, bool isCut ) : base(ant, cc, isCut){
            antecedent = ant;
            monotonic = cc;
            useCut = isCut;
        }

        public override double FuzzyInCrispOutInferencing(List<FuzzySet> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = (antecedent[i]&condition[i]).MaxDegree;
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return monotonic.GetMemberByDegree(finalStrength);
        }

		public override double CrispInCrispOutInferencing(List<double> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = antecedent[i].GetFunctionValue(condition[i]);
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return monotonic.GetMemberByDegree(finalStrength);
        }
    }
}

