using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R04522602許泰源Ass04{
	class SugenoComplement : UnaryOperator{
		double[] parameters;
		public SugenoComplement() {
			name = "Sugeno";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble()*20-1.0;
		}
		public override double calculateFinalValue(double v){
            return (1.0-v)/(1+s*v);
        }
		public double s{
			get{
				return parameters[0];
			}
			set{
				parameters[0] = value;
			}
		}
	}
}
