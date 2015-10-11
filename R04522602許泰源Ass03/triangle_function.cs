using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
    class triangle_function : FuzzySet{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;

		//Constuctor that enable user to create function with customized function name.
		//Unused in current version.
        public triangle_function(Universe u) : base(u){
			name = "Triangle" + count++.ToString();
			double left, middle, right;
			middle = theUniverse.xMin + rnd.NextDouble() * (theUniverse.xMax-theUniverse.xMin);
			left = theUniverse.xMin + rnd.NextDouble() * (middle-theUniverse.xMin);
			right = middle + rnd.NextDouble() * (theUniverse.xMax-middle);

			middle = (double)((int)middle);
			left   = (double)((int)left);
			right  = (double)((int)right);

            series = new Series(name);
            series.ChartType = SeriesChartType.Line;
            u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;

			parameters.Add("Left", left);
            parameters.Add("Middle", middle);
            parameters.Add("Right", right);

			UpdateSeriesPoints();
        }

		//Constuctor required all parameters.
        public override string ToString(){
            return name;
        }

		//Get function value of given x.
        protected override double GetFunctionValue(double x){
            double y = 0.0f;
            double a, b, c;
            a = parameters["Left"];
            b = parameters["Middle"];
            c = parameters["Right"];
            
            if(x <= a)
                y = 0.0f;
            else if (x >= a && x <= b)
                y = (x - a) / (b - a);
            else if (x >= b && x <= c)
                y = (c - x) / (c - b);
            else
                y = 0.0f;

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
    }
}
