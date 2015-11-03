using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
    class bell_fuzzy_set : FuzzySet{

        private static int count = 1;

        //Constuctor
		public bell_fuzzy_set(Universe u) : base(u){
			name = "Bell" + count++.ToString();
			double hw, slope, center;
			center = theUniverse.Xmin + rnd.NextDouble()*(theUniverse.Xmax-theUniverse.Xmin);
			hw = 1.5f;
			slope = 5.0f;
	
            series.Name = name;

			parameters.Add("Half-width", hw);
            parameters.Add("Slope", slope);
            parameters.Add("Center", center);

			double p1, p2;
			
			breakpoints = new DataPoint[3];
			breakpoints[0] = new DataPoint(center, GetFunctionValue(center));

			p1 = center + (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
			p2 = center - (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

			UpdateSeriesPoints();
        }
		
		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0f;
            double a, b, c;
            a = parameters["Half-width"];
            b = parameters["Slope"];
            c = parameters["Center"];
            
            y = 1/(1+Math.Pow(Math.Abs((x-c)/a),2.0f*b));

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

		//Override the previous definition to make sure there always exist a point (Center, 1.0)
		/*protected override void UpdateSeriesPoints(){
            series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
				if(x<=Center && x+theUniverse.Interval>=Center)
					series.Points.AddXY(Center, 1.0);
            }
        }*/

		//Set Parameter of the function.
		public void SetParameter(string NameOfParameter, double Parameter){
			parameters[NameOfParameter] = Parameter;
		}

		//Category the parameters
		[Category("Parameters")]
		public double HalfWidth{
			get{
				return parameters["Half-width"];
			}
			set{
				parameters["Half-width"] = value;

				double p1, p2;

				p1 = Center + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));

				p2 = Center - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
			}
		}
		[Category("Parameters")]
		public double Slope{
			get{
				return parameters["Slope"];
			}
			set{
				parameters["Slope"] = value;

				double p1, p2;

				p1 = Center + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));

				p2 = Center - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
			}
		}
		[Category("Parameters")]
		public double Center{
			get{
				return parameters["Center"];
			}
			set{
				parameters["Center"] = value;
				breakpoints[0].XValue = value;
				double p1, p2;

				p1 = value + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));

				p2 = value - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
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