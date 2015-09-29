using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass02{
    class triangle_function{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private string function_name = "triangle(x)";
        private static int count = 0;
		public bool visible;
		public double Lbound = 0, Rbound = 0;

		//Constuctor that enable user to create function with customized function name.
		//Unused in current version.
        public triangle_function(string function_name){
            parameters.Add("Left", 10.0f);
            parameters.Add("Middle", 30.0f);
            parameters.Add("Right", 50.0f);
            this.function_name = function_name;
        }

		//Constuctor required all parameters.
        public triangle_function(double a, double b, double c){
            parameters.Add("Left", a);
            parameters.Add("Middle", b);
            parameters.Add("Right", c);
			Lbound = a - (c-a);
			Rbound = c + (c-a);
            function_name = "triangle_" + count.ToString() + "(x)";
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
            a = parameters["Left"];
            b = parameters["Middle"];
            c = parameters["Right"];
            
            if(x <= a)
                y = 0.0f;
            else if (x >= a && x <= b)
                y = (x - a) / (b - a);
            else if (x >= b && x <= c)
                y = (c - x) / (double)(c - b);
            else
                y = 0.0f;

            return y;
        }

		//Draw data in the chart, or add the created data to the chart, to be exact.
        public void Draw(Chart chart){            
            double a, b, c;
            a = parameters["Left"];
            b = parameters["Middle"];
            c = parameters["Right"];
            double step = (c-a)/1000.0f;
            Series s = new Series();
            s.ChartType = SeriesChartType.Line;
            s.Name = function_name;

            for(double x = a - (c-a)/10.0f; x < c + (c-a)/10.0f; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
            
            chart.Series.Add(s);
        }

		//Refresh the data existed in both listbox and chart if any parameters changed.
		public void Refresh(Series s){            
            double a, b, c;
            a = parameters["Left"];
            b = parameters["Middle"];
            c = parameters["Right"];
			
            double step = (c-a)/1000.0f;
            s.Points.Clear();
			for(double x = a - (c-a)/10.0f; x < c + (c-a)/10.0f; x+=step)
                s.Points.AddXY(x, GetFunctionValue(x));
        }

		//Get Left Bound of the function.
		public double GetLeftBound(){
			double a, c;
            a = parameters["Left"];
            c = parameters["Right"];
			return a - (c-a)/10.0f;
		}

		//Get Right Bound of the function.
		public double GetRightBound(){
			double a, c;
            a = parameters["Left"];
            c = parameters["Right"];
			return c + (c-a)/10.0f;
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
