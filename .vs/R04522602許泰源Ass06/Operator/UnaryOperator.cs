using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
	public class UnaryOperator{
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

        public virtual double calculateFinalValue(double x){
			return 0.0;
		}
    }
}
