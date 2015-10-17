using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass03{
    class bell_function : FuzzySet{

        private static int count = 1;

        //Constuctor
		public bell_function(Universe u) : base(u){
			name = "Bell" + count++.ToString();
			tmp_name = name;
			double hw, slope, center;
			center = theUniverse.Xmin + rnd.NextDouble()*(theUniverse.Xmax-theUniverse.Xmin);
			hw = 1.5f;
			slope = 5.0f;
	
            series.Name = name;

			parameters.Add("Half-width", hw);
            parameters.Add("Slope", slope);
            parameters.Add("Center", center);

			UpdateSeriesPoints();
        }
		
		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

		//Get function value of given x.
        protected override double GetFunctionValue(double x){
            double y = 0.0f;
            double a, b, c;
            a = parameters["Half-width"];
            b = parameters["Slope"];
            c = parameters["Center"];
            
            y = 1/(1+Math.Pow(Math.Abs((x-c)/a),2.0f*b));

            return y;
        }

		//Refresh the data existed in both listbox and chart if any parameters changed.
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
		public double HalfWidth{
			get{
				return parameters["Half-width"];
			}
			set{
				parameters["Half-width"] = value;
				UpdateSeriesPoints();
			}
		}
		[Category("Parameters")]
		public double Slope{
			get{
				return parameters["Slope"];
			}
			set{
				parameters["Slope"] = value;
				UpdateSeriesPoints();
			}
		}
		[Category("Parameters")]
		public double Center{
			get{
				return parameters["Center"];
			}
			set{
				parameters["Center"] = value;
				UpdateSeriesPoints();
			}
		}
    }
}