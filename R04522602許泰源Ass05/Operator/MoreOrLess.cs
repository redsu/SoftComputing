using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass05{
	class MoreOrLess : UnaryOperator{
		public MoreOrLess() {
			name = "MoreOrLess";
		}
		public override double calculateFinalValue(double v){
            return Math.Pow(v, 0.5);
        }
	}
}
