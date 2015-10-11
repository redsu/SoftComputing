using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
    class bell_function : FuzzySet{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;

        //Constuctor that enable user to create function with customized function name.
		//Unused in current version.
		public bell_function(Universe u) : base(u){
			name = "Bell" + count++.ToString();
			double hw, slope, center;
			center = theUniverse.xMin + rnd.NextDouble()*(theUniverse.xMax-theUniverse.xMin);
			hw = 1.5f;
			slope = 5.0f;
	
            series = new Series(name);
            series.ChartType = SeriesChartType.Line;
            u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;

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
    }
}