using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	class Intensify : UnaryOperator{
		public Intensify() {
			name = "Intensify";
		}
		public override double calculateFinalValue(double v){
            return v <= 0.5 ? 2.0*v*v : 1.0-(2.0*(1.0-v)*(1.0-v));
        }
	}
}
