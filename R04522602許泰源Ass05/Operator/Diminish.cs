using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	class Diminish : UnaryOperator{
		double[] parameters;
		public Diminish() {
			name = "Diminish";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}
		public override double calculateFinalValue(double v){
            return v <= 0.5 ? Math.Pow(v/2.0, 0.5) : 1.0 - Math.Pow((1.0-v)/2.0, 0.5);
        }
	}
}
