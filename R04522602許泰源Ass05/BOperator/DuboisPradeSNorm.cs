using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class DuboisPradeSNorm : BinaryOperator{
		double[] parameters;
		public DuboisPradeSNorm(){
			name = "DPSNorm";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}

        public override double calculateFinalValue(double x, double y){
			double alpha = parameters[0];
			double Y = 0.0, tmp = 0.0;
			tmp = (x<y?x:y)<(1.0-alpha)?(x<y?x:y):(1.0-alpha);
			Y = x+y-x*y-tmp;
			tmp = ((1-x)>(1-y)?(1-x):(1-y))>alpha?((1-x)>(1-y)?(1-x):(1-y)):alpha;
			Y /= tmp;
			return Y;
		}
		
	}
}
