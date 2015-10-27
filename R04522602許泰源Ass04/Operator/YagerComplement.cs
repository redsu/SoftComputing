using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass05{
	public class YagerComplement : UnaryOperator{
		double[] parameters;
		public YagerComplement() {
			name = "Yager";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble()*2;
		}
		public override double calculateFinalValue(double v){
            return Math.Pow((1.0 - Math.Pow(v, w)),1.0/w);
        }
		public double w{
			get{
				return parameters[0];
			}
			set{
				parameters[0] = value;
			}
		}
	}
}
