using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	public  class MamdaniIfThenRule : IfThenFuzzyRule{
        public MamdaniIfThenRule(List<FuzzySet> ant, FuzzySet cc, bool isCut ) : base(ant, cc, isCut){
            antecedent = ant;
            conclusion = cc;
            useCut = isCut;
        }

        public override FuzzySet FuzzyInFuzzyOutInferencing(List<FuzzySet> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = (antecedent[i]&condition[i]).MaxDegree;
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return useCut ? finalStrength - conclusion : finalStrength * conclusion;
        }

		public override FuzzySet CrispInFuzzyOutInferencing(List<double> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = antecedent[i].GetFunctionValue(condition[i]);
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return useCut ? finalStrength - conclusion : finalStrength * conclusion;
        }
    }
}

