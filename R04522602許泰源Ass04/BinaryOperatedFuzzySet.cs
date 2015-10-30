using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass04{
	class BinaryOperatedFuzzySet : FuzzySet{
		BinaryOperator theOperator;
		FuzzySet OperandOne;
		FuzzySet OperandTwo;
		static int count = 1;
		//Constructor
        public BinaryOperatedFuzzySet(FuzzySet f, FuzzySet g, BinaryOperator o) : base(f.TheUniverse){
            
			/*if(f.TheUniverse != g.TheUniverse){
				throw new Exception("Two fussy set operands are not defined in the same universe for binary operation.");
			}*/
			
			OperandOne = f;
			OperandTwo = g;

            theOperator = o;
            name = OperandOne.Name + theOperator.Name + OperandTwo.Name + count++.ToString();
			tmp_name = name;
            OperandOne.ParameterChanged += theFuzzySet_ParameterChanged;
			OperandTwo.ParameterChanged += theFuzzySet_ParameterChanged;

			OperandOne.ParameterChanged += theFuzzySet_ParameterChanged;
			OperandTwo.ParameterChanged += theFuzzySet_ParameterChanged;

			series.Name = name;
			if(OperandOne.BP != null || OperandTwo.BP != null){
				breakpoints = new DataPoint[OperandOne.BP.Length + OperandTwo.BP.Length];
				if(breakpoints!=null){
					for(int i=0; i<OperandOne.BP.Length; i++){
						if(this.OperandOne.BP[i]!=null)
							breakpoints[i] = new DataPoint(this.OperandOne.BP[i].XValue, GetFunctionValue(this.OperandOne.BP[i].XValue));
					}
					for(int i=0; i<OperandTwo.BP.Length; i++){
						if(this.OperandTwo.BP[i]!=null)
							breakpoints[i+OperandOne.BP.Length] = new DataPoint(this.OperandTwo.BP[i].XValue, GetFunctionValue(this.OperandTwo.BP[i].XValue));
					}
				}
			}
            UpdateSeriesPoints();
        }

        void theFuzzySet_ParameterChanged(object sender, EventArgs e){
			Update_BP();
            UpdateSeriesPoints();
            TriggerEvent();
        }

        public override double GetFunctionValue(double x){
            return theOperator.calculateFinalValue(OperandOne.GetFunctionValue(x), OperandTwo.GetFunctionValue(x));
        }

		//Update breakpoints
		protected override void Update_BP(){
			if(breakpoints != null){
				for(int i=0; i<OperandOne.BP.Length; i++){
					if(OperandOne.BP[i]!=null){
						breakpoints[i].XValue = this.OperandOne.BP[i].XValue;
						breakpoints[i].YValues[0] = GetFunctionValue(this.OperandOne.BP[i].XValue);
					}
				}
				for(int i=0; i<OperandTwo.BP.Length; i++){
					if(OperandTwo.BP[i]!=null){
						breakpoints[i+OperandOne.BP.Length].XValue = this.OperandTwo.BP[i].XValue;
						breakpoints[i+OperandOne.BP.Length].YValues[0] = GetFunctionValue(this.OperandTwo.BP[i].XValue);
					}
				}
			}
		}

		public override string ToString(){
			return name;
		}
    }
}
