using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	class FuzzyInferenceSystem{
		protected List<IfThenFuzzyRule> allRules = new List<IfThenFuzzyRule>();

        public FuzzyInferenceSystem(List<IfThenFuzzyRule> all ){
            allRules = all;
        }

        public virtual double FuzzyInCrispOutInferencing(List<FuzzySet> condition){
            throw new Exception("No implementation of FuzzyInCrispOutInferencing()");
        }


        public virtual FuzzySet FuzzyInFuzzyOutInferencing(List<FuzzySet> condition){
            FuzzySet final = null;
            final = allRules[0].FuzzyInFuzzyOutInferencing(condition);
            for (int i = 1; i < allRules.Count; i++){
               final |= allRules[i].FuzzyInFuzzyOutInferencing(condition);
            }
            return final;
        }

        public virtual double CrispInCrispOutInferencing(List<double> condition, DefuzzificationType type){
            FuzzySet final = null;
            final = allRules[0].CrispInFuzzyOutInferencing(condition);
            for (int i = 1; i < allRules.Count; i++)
				final |= allRules[i].CrispInFuzzyOutInferencing(condition);
            switch (type){
                case DefuzzificationType.BOA:
					return final.BOACrispValue;
                case DefuzzificationType.COA:
                    return final.COACrispValue;
                case DefuzzificationType.LOM:
					return final.LOMCrispValue;
                case DefuzzificationType.MOM:
					return final.MOMCrispValue;
                case DefuzzificationType.SOM:
					return final.SOMCrispValue;
            }
            return final.COACrispValue;
        }
	}
}
