using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
	class ScaleOperator : UnaryOperator{
		double[] parameters;
		public ScaleOperator() {
			name = "Scale";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}

		public ScaleOperator(double alpha) {
			name = "Scale";
			parameters = new double[1];
			parameters[0] = alpha;
		}

		public override double calculateFinalValue(double v){
            return parameters[0] * v;
        }
	}
}
