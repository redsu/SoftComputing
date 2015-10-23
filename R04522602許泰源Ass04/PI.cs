using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
	class PI : FuzzySet{
		//private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public PI(Universe u) : base(u){
			
			name = "PI" + count++.ToString();
			tmp_name = name;
			double C, A;
			C = theUniverse.Xmin + rnd.NextDouble() * (theUniverse.Xmax-theUniverse.Xmin);
			A = rnd.NextDouble() * (C-theUniverse.Xmin);
			
            series.Name = name;
			parameters.Add("c", C);
            parameters.Add("a", A);
            UpdateSeriesPoints();
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0f;

            if(x<=C-A)
				y = 0;
			else if(x<=(2*C-A)/2)
				y = 2*((x-C+A)/(A))*((x-C+A)/(A));
			else if(x<=C)
				y = 1 - 2*((C-x)/(A))*((C-x)/(A));
			else if(x<=(2*C+A)/2)
				y = 1 - 2*((x-C)/(A))*((x-C)/(A));
			else if(x<=C+A)
				y = 2*((C+A-x)/(A))*((C+A-x)/(A));
			else
				y = 0;
            
            return y;
        }

		//Refresh the data existed in both listbox and chart if any parameters changed.
		//Unused now
		public void Refresh(){            
            UpdateSeriesPoints();
        }

		//Get Parameter of the function.
		public double GetParameter(string NameOfParameter){
			return parameters[NameOfParameter];
		}

		//Set Parameter of the function.
		public void SetParameter(string NameOfParameter, double Parameter){
			parameters[NameOfParameter] = Parameter;
		}

		//Category the parameters
		[Category("Parameters")]
		public double C{
			get{
				return parameters["c"];
			}
			set{
				parameters["c"] = value;
				UpdateSeriesPoints();
			}
		}
		[Category("Parameters")]
		public double A{
			get{
				return parameters["a"];
			}
			set{
				if(value >= 0){
					parameters["a"] = value;
					UpdateSeriesPoints();
				}
			}
		}
	}
}
