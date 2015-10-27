using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	class Extremely : UnaryOperator{
		double[] parameters;
		public Extremely() {
			name = "Extremely";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}
		public override double calculateFinalValue(double v){
            return (v*v)*(v*v)*(v*v);
        }
	}
}
