using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
	public class AlgebraicProduct : BinaryOperator{
		
		public AlgebraicProduct(){
			name = "AP";
		}

        public override double calculateFinalValue(double x, double y){
			return x*y;
		}
		
	}
}
