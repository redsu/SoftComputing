using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class DrasticProduct : BinaryOperator{
		
		public DrasticProduct(){
			name = "DrasticProduct";
		}

        public override double calculateFinalValue(double x, double y){
			if(x==1.0)
				return y;
			else if(y==1.0)
				return x;
			else
				return 0.0;
		}
		
	}
}
