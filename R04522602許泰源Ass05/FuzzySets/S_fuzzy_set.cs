using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	class S_fuzzy_set : FuzzySet{
		//private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public S_fuzzy_set(Universe u) : base(u){
			
			name = "SFuzzySet" + count++.ToString();
			double l, r;
			l = theUniverse.Xmin + rnd.NextDouble() * (theUniverse.Xmax-theUniverse.Xmin);
			r = l + rnd.NextDouble() * (theUniverse.Xmax - l);
			
            series.Name = name;
			parameters.Add("l", l);
            parameters.Add("r", r);
            UpdateSeriesPoints();
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0f;
            double c, sigma;
            c = L;
            sigma = R;
            
            if(x<=L)
				y = 0;
			else if(x<=(L+R)/2)
				y = 2*((x-L)/(R-L))*((x-L)/(R-L));
			else if(x<=R)
				y = 1 - 2*((R-x)/(R-L))*((R-x)/(R-L));
			else
				y = 1;
            
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
		public double L{
			get{
				return parameters["l"];
			}
			set{
				if(value<R){
					parameters["l"] = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double R{
			get{
				return parameters["r"];
			}
			set{
				if(value>L){
					parameters["r"] = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Browsable(false)]
		public double MaxDegree{
			get{
				return 1.0;
			}
		}
	}
}
