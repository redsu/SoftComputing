using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass02{
    class bell_function{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private string function_name = "Bell MF";
        private static int count = 0;
		public bool visible;

        //Constuctor that enable user to create function with customized function name.
		//Unused in current version.
		public bell_function(string function_name){
            parameters.Add("Half-width", 3.0f);
            parameters.Add("Slope", 5.0f);
            parameters.Add("Center", 30.0f);
            this.function_name = function_name;
        }

		//Constuctor required all parameters.
        public bell_function(double HalfWidth, double Slope, double Center){
            parameters.Add("Half-width", HalfWidth);
            parameters.Add("Slope", Slope);
            parameters.Add("Center", Center);
            function_name = "bell_" + count.ToString() + "(x)";
			visible = true;
            count++;
        }

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return function_name;
        }

		//Get function value of given x.
        public double GetFunctionValue(double x){
            double y = 0.0f;
            double a, b, c;
            a = parameters["Half-width"];
            b = parameters["Slope"];
            c = parameters["Center"];
            
            y = 1/(1+Math.Pow(Math.Abs((x-c)/a),2.0f*b));

            return y;
        }

		//Draw data in the chart, or add the created data to the chart, to be exact.
        public void Draw(Chart chart){            
            double a, b, c;
            a = parameters["Half-width"];
            b = parameters["Slope"];
            c = parameters["Center"];
            double step = Math.Abs(a)*3.0f/1000.0f;
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.Name = function_name;

            for (double x = c-Math.Abs(a)*3.0f; x < c+Math.Abs(a)*3.0f; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
            chart.Series.Add(s);
        }

		//Refresh the data existed in both listbox and chart if any parameters changed.
		public void Refresh(Series s){            
            double a, b, c;
            a = parameters["Half-width"];
            b = parameters["Slope"];
            c = parameters["Center"];
            double step = Math.Abs(a)*3.0f/1000.0f;
			s.Points.Clear();
            for (double x = c-Math.Abs(a)*3.0f; x < c+Math.Abs(a)*3.0f; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
        }

		//Get Left Bound of the function.
		public double GetLeftBound(){
			double a, c;
            a = parameters["Half-width"];
            c = parameters["Center"];
			return c-Math.Abs(a)*3.0f;
		}

		//Get Right Bound of the function.
		public double GetRightBound(){
			double a, c;
            a = parameters["Half-width"];
            c = parameters["Center"];
			return c+Math.Abs(a)*3.0f;
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