using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class HamacherTNorm : BinaryOperator{
		double[] parameters;
		public HamacherTNorm(){
			name = "HamacherTNorm";
			parameters = new double[1];
			parameters[0] = -1.0;
			while(parameters[0]<=0.0)
				parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			double r = parameters[0];
			return x*y/(r+(1.0-r)*(x+y-x*y));
		}
		
	}
}
