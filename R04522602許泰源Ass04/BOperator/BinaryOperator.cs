using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	public class BinaryOperator{
		protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));
		protected string name;

        public string Name{
            get{
                return name;
            }
            set{
                name = value;
            }
        }

        public virtual double calculateFinalValue(double x, double y){
			return 0.0;
		}

		public override string ToString()
		{
			return this.Name + "Binary Operator";
		}
    }
}
