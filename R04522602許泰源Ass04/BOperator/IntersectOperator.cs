using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	public class IntersectOperator : BinaryOperator{
		
		public IntersectOperator(){
			name = "Intersect";
		}

        public override double calculateFinalValue(double x, double y){
			return x < y ? x : y;
		}
		
	}
}
