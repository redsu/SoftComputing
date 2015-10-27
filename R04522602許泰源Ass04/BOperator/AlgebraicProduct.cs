using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	public class AlgebraicProduct : BinaryOperator{
		
		public AlgebraicProduct(){
			name = "AlgebraicProduct";
		}

        public override double calculateFinalValue(double x, double y){
			return x*y;
		}
		
	}
}
