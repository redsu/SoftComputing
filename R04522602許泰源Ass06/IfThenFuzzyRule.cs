using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	public  class IfThenFuzzyRule{
        protected List<FuzzySet> antecedent = new List<FuzzySet>();
        protected FuzzySet conclusion;
        protected bool useCut = true;

        public IfThenFuzzyRule(List<FuzzySet> ant, FuzzySet cc, bool isCut ){
            antecedent = ant;
            conclusion = cc;
            useCut = isCut;
        }

        /*public FuzzySet Inference(List<FuzzySet> condition){
            double finalStrength = double.MaxValue;
			double MaxDegree = 0.0;

            for( int i = 0; i < antecedent.Count; i++ ){
				MaxDegree = (antecedent[i]&condition[i]).MaxDegree;
				finalStrength = finalStrength > MaxDegree ? MaxDegree : finalStrength;
            }
            return useCut ? finalStrength - conclusion : finalStrength * conclusion;
        }*/

		public virtual double FuzzyInCrispOutInferencing(List<FuzzySet> condition)
        { throw new Exception("No implementation for FuzzyInCrispOutInferencing()."); }
        public virtual FuzzySet FuzzyInFuzzyOutInferencing(List<FuzzySet> condition)
        { throw new Exception("No implementation for FuzzyInFuzzyOutInferencing()."); }
        public virtual FuzzySet CrispInFuzzyOutInferencing(List<double> condition)
        { throw new Exception("No implementation for CrispInFuzzyOutInferencing()."); }
        public virtual double CrispInCrispOutInferencing(List<double> condition)
        { throw new Exception("No implementation for CrispInCrispOutInferencing()."); }

		internal FuzzySet Inference(List<FuzzySet> conds)
		{
			throw new NotImplementedException();
		}
	}
}
