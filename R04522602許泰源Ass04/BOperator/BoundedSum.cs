using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	public class BoundedSum : BinaryOperator{
		
		public BoundedSum(){
			name = "BoundedSum";
		}

        public override double calculateFinalValue(double x, double y){
			return x+y<1.0 ? x+y : 1.0;
		}
		
	}
}
