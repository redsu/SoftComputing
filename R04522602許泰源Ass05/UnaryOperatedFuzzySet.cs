using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass05{
	class UnaryOperatedFuzzySet : FuzzySet{
		UnaryOperator theOperator;
		FuzzySet theFuzzySet;
		static int count = 1;
        public UnaryOperatedFuzzySet(FuzzySet f, UnaryOperator o) : base(f.TheUniverse){
            theFuzzySet = f;
            theOperator = o;
            name = theOperator.Name + theFuzzySet.Name + count++.ToString();
			tmp_name = name;
            theFuzzySet.ParameterChanged += theFuzzySet_ParameterChanged;
			theFuzzySet.NameChanged += theFuzzySet_NameChanged;

			series.Name = name;
			if(theFuzzySet.BP != null){
				breakpoints = new DataPoint[theFuzzySet.BP.Length];
				if(breakpoints!=null)
					for(int i=0; i<breakpoints.Length; i++){
						if(this.theFuzzySet.BP[i]!=null)
							breakpoints[i] = new DataPoint(this.theFuzzySet.BP[i].XValue, GetFunctionValue(this.theFuzzySet.BP[i].XValue));
					}
			}
            UpdateSeriesPoints();
        }

        void theFuzzySet_ParameterChanged(object sender, EventArgs e){
			Update_BP();
            UpdateSeriesPoints();
            TriggerEvent();
        }

		void theFuzzySet_NameChanged(object sender, EventArgs e){
            Name = theOperator.Name + theFuzzySet.Name;
        }

		public override double GetFunctionValue(double x){
            double originalValue;
            originalValue = theFuzzySet.GetFunctionValue(x);
            return theOperator.calculateFinalValue(originalValue);
        }
		
		//Update breakpoints
		protected override void Update_BP(){
			if(breakpoints != null)
				for(int i=0; i<breakpoints.Length; i++){
					if(theFuzzySet.BP[i]!=null){
						breakpoints[i].XValue = this.theFuzzySet.BP[i].XValue;
						breakpoints[i].YValues[0] = GetFunctionValue(this.theFuzzySet.BP[i].XValue);
					}
				}
		}

		public override string ToString(){
			return name;
		}
    }
}
