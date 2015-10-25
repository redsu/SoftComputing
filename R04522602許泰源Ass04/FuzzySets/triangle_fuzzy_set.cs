using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
    class triangle_fuzzy_set : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;

		//Constuctor
        public triangle_fuzzy_set(Universe u) : base(u){
			name = "Triangle" + count++.ToString();
			tmp_name = name;
			double left = theUniverse.Xmax, middle, right = theUniverse.Xmin;
			middle = theUniverse.Xmin + rnd.NextDouble() * (theUniverse.Xmax-theUniverse.Xmin);
			while(middle <= left)
				left = theUniverse.Xmin + rnd.NextDouble() * (middle-theUniverse.Xmin);
			while(middle >= right)
				right = middle + rnd.NextDouble() * (theUniverse.Xmax-middle);

			//series = new Series(name);
			series.Name = name;
			parameters.Add("Left", left);
            parameters.Add("Middle", middle);
            parameters.Add("Right", right);
			
			breakpoints = new DataPoint[3];

			breakpoints[0] = new DataPoint(left, 0.0);
			breakpoints[1] = new DataPoint(middle, 1.0);
			breakpoints[2] = new DataPoint(right, 0.0);

			UpdateSeriesPoints();
        }

		//Constuctor required all parameters.
        public override string ToString(){
            return name;
        }

		

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0;
            double a, b, c;
            a = parameters["Left"];
            b = parameters["Middle"];
            c = parameters["Right"];
            
            if(x <= a)
                y = 0.0;
            else if (x >= a && x < b)
                y = (x - a) / (b - a);
			/*else if (x >= b)
				y = 1.0;*/
            else if (x >= b && x <= c)
                y = (c - x) / (c - b);
            else
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
		/*protected override void UpdateSeriesPoints(){
			series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
				series.Points.AddXY(x, y);
				if(x<Middle && x+theUniverse.Interval>Middle)
					series.Points.AddXY(Middle, 1.0);
            }
		}*/
		[Category("Parameters")]
		public double Left{
			get{
				return parameters["Left"];
			}
			set{
				if(value<parameters["Middle"]){
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
				if(value>parameters["Middle"]){
					parameters["Right"] = value;
					breakpoints[2].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double Middle{
			get{
				return parameters["Middle"];
			}
			set{
				if(parameters["Left"]<value&&parameters["Right"]>value){
					parameters["Middle"] = value;
					breakpoints[1].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
    }
}
