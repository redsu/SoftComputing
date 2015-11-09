using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass06{
	class DilateOperator : UnaryOperator{
		public DilateOperator() {
			name = "Dilate";
		}
		public override double calculateFinalValue(double v){
            return Math.Pow(v, 0.5);
        }
	}
}
