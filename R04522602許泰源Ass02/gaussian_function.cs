using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass02{
    class gaussian_function{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private string function_name = "";
        private static int count = 0;
		public bool visible;
        public double Lbound = 0, Rbound = 0;
        public double sLbound = 0, sRbound = 0;
        //Constuctor that enable user to create function with customized function name.
        //Unused in current version.
        public gaussian_function(string function_name){
            parameters.Add("c", 30.0f);
            parameters.Add("sigma", 3.0f);
            this.function_name = function_name;
            count++;
        }

		//Constuctor required all parameters.
        public gaussian_function(double c, double sigma){
            parameters.Add("c", c);
            parameters.Add("sigma", sigma);            
            function_name = "gaussian_" + count.ToString() + "(x)";
			visible = true;
            Lbound = c - 4 * sigma;
            Rbound = c + 4 * sigma;
            sLbound = 0;
            sRbound = 10 * sigma;
            count++;
        }

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return function_name;
        }

		//Get function value of given x.
        public double GetFunctionValue(double x){
            double y = 0.0f;
            double c, sigma;
            c = parameters["c"];
            sigma = parameters["sigma"];
            
            y = Math.Exp(-Math.Pow((x - c), 2.0f)/(2.0f * Math.Pow(sigma, 2.0f)));
            
            return y;
        }

		//Draw data in the chart, or add the created data to the chart, to be exact.
        public void Draw(Chart chart){            
            double c, sigma;
            c = parameters["c"];
            sigma = parameters["sigma"];
            double step = sigma*3.0f/1000.0f;
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.Name = function_name;

            for (double x = c-3.0f*sigma; x < c+3.0f*sigma; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
            chart.Series.Add(s);            
        }

		//Refresh the data existed in both listbox and chart if any parameters changed.
		public void Refresh(Series s){            
            double c, sigma;
            c = parameters["c"];
            sigma = parameters["sigma"];
            double step = sigma*3.0f/1000.0f;
			s.Points.Clear();
            for (double x = c-3.0f*sigma; x < c+3.0f*sigma; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
        }

		//Get Left Bound of the function.
		public double GetLeftBound(){
			double c, sigma;
            c = parameters["c"];
            sigma = parameters["sigma"];
			return c-3.0f*sigma;
		}

		//Get Right Bound of the function.
		public double GetRightBound(){
			double c, sigma;
            c = parameters["c"];
            sigma = parameters["sigma"];
			return c+3.0f*sigma;
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