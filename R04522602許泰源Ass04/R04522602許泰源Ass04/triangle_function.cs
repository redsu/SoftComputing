using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass03{
    class triangle_function : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;

		//Constuctor
        public triangle_function(Universe u) : base(u){
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

			UpdateSeriesPoints();

			int num_pt = series.Points.Count;
			for(int i=1; i<num_pt-1; i++){
				if(series.Points[i].YValues[0]==0 && series.Points[i+1].YValues[0]>0)
					series.Points[i].MarkerStyle = MarkerStyle.Square;
				if(series.Points[i].YValues[0]>0 && series.Points[i+1].YValues[0]==0)
					series.Points[i+1].MarkerStyle = MarkerStyle.Square;
				if(series.Points[i].YValues[0]>series.Points[i-1].YValues[0] && series.Points[i].YValues[0]>series.Points[i+1].YValues[0]){
					series.Points[i].MarkerStyle = MarkerStyle.Circle;
					series.Points[i].YValues[0] = 1.0;
				}
			}

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
                y = 0.0;
            else if (x >= a && x < b)
                y = (x - a) / (b - a);
			else if (x == b)
				y = 1.0;
            else if (x > b && x <= c)
                y = (c - x) / (c - b);
            else
                y = 0.0;

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
		protected override void UpdateSeriesPoints(){
			series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
				series.Points.AddXY(x, y);
				if(x<Middle && x+theUniverse.Interval>Middle)
					series.Points.AddXY(Middle, 1.0);
            }
		}
		[Category("Parameters")]
		public double Left{
			get{
				return parameters["Left"];
			}
			set{
				if(value<parameters["Middle"]){
					parameters["Left"] = value;
					UpdateSeriesPoints();
					int num_pt = series.Points.Count;
					for(int i=1; i<num_pt-1; i++){
						if(series.Points[i].YValues[0]==0 && series.Points[i+1].YValues[0]>0)
							series.Points[i].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>0 && series.Points[i+1].YValues[0]==0)
							series.Points[i+1].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>series.Points[i-1].YValues[0] && series.Points[i].YValues[0]>series.Points[i+1].YValues[0]){
							series.Points[i].MarkerStyle = MarkerStyle.Circle;
							series.Points[i].YValues[0] = 1.0;
						}
					}
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
					UpdateSeriesPoints();
					int num_pt = series.Points.Count;
					for(int i=1; i<num_pt-1; i++){
						if(series.Points[i].YValues[0]==0 && series.Points[i+1].YValues[0]>0)
							series.Points[i].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>0 && series.Points[i+1].YValues[0]==0)
							series.Points[i+1].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>series.Points[i-1].YValues[0] && series.Points[i].YValues[0]>series.Points[i+1].YValues[0]){
							series.Points[i].MarkerStyle = MarkerStyle.Circle;
							series.Points[i].YValues[0] = 1.0;
						}
					}
					/*
					series.Points[num_pt_M].MarkerStyle = MarkerStyle.Circle;
					if(num_pt_R<series.Points.Count)
						series.Points[num_pt_R].MarkerStyle = MarkerStyle.Square;
					if(num_pt_L>0)*/
						
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
					UpdateSeriesPoints();
					int num_pt = series.Points.Count;
					for(int i=1; i<num_pt-1; i++){
						if(series.Points[i].YValues[0]==0 && series.Points[i+1].YValues[0]>0)
							series.Points[i].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>0 && series.Points[i+1].YValues[0]==0)
							series.Points[i+1].MarkerStyle = MarkerStyle.Square;
						if(series.Points[i].YValues[0]>series.Points[i-1].YValues[0] && series.Points[i].YValues[0]>series.Points[i+1].YValues[0]){
							series.Points[i].MarkerStyle = MarkerStyle.Circle;
							series.Points[i].YValues[0] = 1.0;
						}
					}
				}
			}
		}
    }
}
