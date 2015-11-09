using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
	public class SugenoSNorm : BinaryOperator{
		double[] parameters;
		public SugenoSNorm(){
			name = "SSNorm";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble()-1.0;
		}

        public override double calculateFinalValue(double x, double y){
			double l = parameters[0];
			return 1.0<(x+y-x*y*l)?1.0:(x+y-x*y*l);
		}
		
	}
}
