using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass05{
	class ConcentrationOperator : UnaryOperator{
		public ConcentrationOperator() {
			name = "Very";
		}
		public override double calculateFinalValue(double v){
            return v*v;
        }
	}
}
