using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass02{
    class sigmoidal_function{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private string function_name = "";
        private static int count = 0;
		public bool visible;

		//Constuctor that enable user to create function with customized function name.
		//Unused in current version.
        public sigmoidal_function(string function_name){
            parameters.Add("Slope", 3.0f);
            parameters.Add("CrossoverPoint", 30.0f);
            this.function_name = function_name;
        }
		
		//Constuctor required all parameters.
        public sigmoidal_function(double Slope, double CrossoverPoint){
            parameters.Add("Slope", Slope);
            parameters.Add("CrossoverPoint", CrossoverPoint);
            function_name = "sigmoidal_" + count.ToString() + "(x)";
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
            double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
            y = 1/(1+Math.Exp(-a*(x-c)));
            return y;
        }
		
		//Draw data in the chart, or add the created data to the chart, to be exact.
        public void Draw(Chart chart){            
            double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
            double width = 25/Math.Abs(a);
            double step = width/1000.0f;
            
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.Name = function_name;

            for(double x = c - width/2; x < c + width/2; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
            chart.Series.Add(s);
        }
		
		//Refresh the data existed in both listbox and chart if any parameters changed.
		public void Refresh(Series s){            
            double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
            double width = 25/Math.Abs(a);
            double step = width/1000.0f;
			s.Points.Clear();
            for(double x = c - width/2; x < c + width/2; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
        }

		//Get Left Bound of the function.
		public double GetLeftBound(){
			double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
			double width = 25/Math.Abs(a);
			return c - width/2;
		}

		//Get Right Bound of the function.
		public double GetRightBound(){
			double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
			double width = 25/Math.Abs(a);
			return c + width/2;
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
