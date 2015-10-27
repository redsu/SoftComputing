using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	public class DuboisPradeTNorm : BinaryOperator{
		double[] parameters;
		public DuboisPradeTNorm(){
			name = "DuboisPradeTNorm";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			return x*y/( (x>y ? x:y)>parameters[0] ? (x>y ? x:y) : parameters[0]);
		}
		
	}
}
