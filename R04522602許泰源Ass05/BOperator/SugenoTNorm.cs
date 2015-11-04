using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class SugenoTNorm : BinaryOperator{
		double[] parameters;
		public SugenoTNorm(){
			name = "STNorm";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble()-1.0;
		}

        public override double calculateFinalValue(double x, double y){
			double l = parameters[0];
			return 0.0>((l+1.0)*(x+y-1.0)-l*x*y)?0.0:((l+1.0)*(x+y-1.0)-l*x*y);
		}
		
	}
}
