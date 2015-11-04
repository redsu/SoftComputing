using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class HamacherSNorm : BinaryOperator{
		double[] parameters;
		public HamacherSNorm(){
			name = "HSNorm";
			parameters = new double[1];
			parameters[0] = -1.0;
			while(parameters[0]<=0.0)
				parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			double r = parameters[0];
			return (x+y+(r-2.0)*x*y)/(1.0+(r-1.0)*x*y);
		}
		
	}
}
