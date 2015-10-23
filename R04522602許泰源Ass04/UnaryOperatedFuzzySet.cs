using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass04{
	class UnaryOperatedFuzzySet : FuzzySet{
		UnaryOperator theOperator;
		FuzzySet theFuzzySet;

        public UnaryOperatedFuzzySet(FuzzySet f, UnaryOperator o) : base(f.TheUniverse){
            theFuzzySet = f;
            theOperator = o;
            name = theOperator.Name + theFuzzySet.Name;
            theFuzzySet.ParameterChanged += theFuzzySet_ParameterChanged;

            UpdateSeriesPoints();
        }

        void theFuzzySet_ParameterChanged(object sender, EventArgs e){
            UpdateSeriesPoints();
            TriggerEvent();
        }
        public override double GetFunctionValue(double x){
            double originalValue;
            originalValue = theFuzzySet.GetFunctionValue(x);
            return theOperator.calculateFinalValue(originalValue);
        }
    }
}
