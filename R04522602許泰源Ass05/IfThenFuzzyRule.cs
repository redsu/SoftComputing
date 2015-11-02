using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass05{
	public  class IfThenFuzzyRule{
        List<FuzzySet> antecedent = new List<FuzzySet>();
        FuzzySet conclusion;
        bool useCut = true;

        public IfThenFuzzyRule(List<FuzzySet> ant, FuzzySet cc, bool isCut ){
            antecedent = ant;
            conclusion = cc;
            useCut = isCut;
        }

        public FuzzySet Inference(List<FuzzySet> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = (antecedent[i]&condition[i]).MaxDegree;
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return useCut ? finalStrength - conclusion : finalStrength * conclusion;
        }
    }
}
