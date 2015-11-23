using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
	public class DombiTNorm : BinaryOperator{
		double[] parameters;
		public DombiTNorm(){
			name = "DTNorm";
			parameters = new double[1];
			parameters[0] = -1.0;
			while(parameters[0]<=0.0)
				parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			double l = parameters[0];
			return 1.0/(1.0+Math.Pow((Math.Pow(1.0/x-1.0,l)+Math.Pow(1.0/y-1.0,l)),1.0/l));
		}
		
	}
}
