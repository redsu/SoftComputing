using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
    class LeftUpStep : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;

		//Constuctor
        public LeftUpStep(Universe u) : base(u){
			name = "LeftUpStep(" + count++.ToString() +")";
			double left = theUniverse.Xmax, right = theUniverse.Xmin;
			
			left  = rnd.Next((int)theUniverse.Xmin,(int)(theUniverse.Xmax-(theUniverse.Xmax-theUniverse.Xmin)/2));
			right = rnd.Next((int)(theUniverse.Xmin+(theUniverse.Xmax-theUniverse.Xmin)/2),(int)theUniverse.Xmax);

			//series = new Series(name);
			series.Name = name;
			parameters.Add("Left", left);
            parameters.Add("Right", right);
			
			breakpoints = new DataPoint[2];

			breakpoints[0] = new DataPoint(left, 1.0);
			breakpoints[1] = new DataPoint(right, 0.0);

			UpdateSeriesPoints();
        }

		//Constuctor required all parameters.
        public override string ToString(){
            return name;
        }

		

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0;
            double a, c;
            a = parameters["Left"];
            c = parameters["Right"];
            
            if(x <= a)
                y = 1.0;
            else if (x >= a && x < c)
                y = (c - x) / (c - a);
            else if (x >= c)
                y = 0.0;

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

		[Category("Parameters")]
		public double Left{
			get{
				return parameters["Left"];
			}
			set{
				if(value<parameters["Right"]){
					parameters["Left"] = value;
					breakpoints[0].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double Right{
			get{
				return parameters["Right"];
			}
			set{
				if(value>parameters["Left"]){
					parameters["Right"] = value;
					breakpoints[1].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Browsable(false)]
		public override double MaxDegree{
			get{
				return 1.0;
			}
		}
    }
}
