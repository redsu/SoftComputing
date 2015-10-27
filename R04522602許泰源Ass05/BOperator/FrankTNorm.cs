using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class FrankTNorm : BinaryOperator{
		double[] parameters;
		public FrankTNorm(){
			name = "FrankTNorm";
			parameters = new double[1];
			parameters[0] = -1.0;
			while(parameters[0]<=0.0)
				parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			double s = parameters[0];
			return Math.Log(1.0+(Math.Pow(s,x)-1.0)*(Math.Pow(s,y)-1.0)/(s-1.0),s);
		}
		
	}
}
