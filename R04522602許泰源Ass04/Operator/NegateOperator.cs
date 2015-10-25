using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass04{
	public class NegateOperator : UnaryOperator{
		public NegateOperator() {
			name = "Not";
		}
		public override double calculateFinalValue(double v){
            return 1.0 - v;
        }
	}
}
