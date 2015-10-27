using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class DrasticSum : BinaryOperator{
		
		public DrasticSum(){
			name = "DrasticSum";
		}

        public override double calculateFinalValue(double x, double y){
			if(x==0.0)
				return y;
			else if(y==0.0)
				return x;
			else
				return 1.0;
		}
		
	}
}
