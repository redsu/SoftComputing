﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
    class sigmoidal_function : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
		private static int count = 1;

		//Constuctor
        public sigmoidal_function(Universe u) : base(u){
			name = "Sigmoidal" + count++.ToString();
			tmp_name = name;
			double slope, crossoverpt;
			slope = 3.0f;
			crossoverpt = theUniverse.Xmin + rnd.NextDouble()*(theUniverse.Xmax-theUniverse.Xmin);

            series.Name = name;

			parameters.Add("Slope", slope);
            parameters.Add("CrossoverPoint", crossoverpt);

			UpdateSeriesPoints();
			/*int num_pt = series.Points.Count;
			int num_pt_M = (int)((double)num_pt * (crossoverpt - theUniverse.Xmin) / (theUniverse.Xmax-theUniverse.Xmin));
				
			for(int i=0; i<num_pt-1; i++){
				if(series.Points[i].YValues[0]<=0.999999 && series.Points[i+1].YValues[0]>=0.999999)
					series.Points[i].MarkerStyle = MarkerStyle.Square;
			}
			for(int i=0; i<num_pt-1; i++){
				if(series.Points[i].YValues[0]<=0.000001 && series.Points[i+1].YValues[0]>=0.000001)
					series.Points[i].MarkerStyle = MarkerStyle.Square;
				if(series.Points[i].YValues[0]==0.5)
					series.Points[i].MarkerStyle = MarkerStyle.Circle;
			}*/

        }
		
		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }
		
		//Get function value of given x.
        protected override double GetFunctionValue(double x){
            double y = 0.0f;
            double a, c;
            a = parameters["Slope"];
            c = parameters["CrossoverPoint"];
            y = 1/(1+Math.Exp(-a*(x-c)));
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
		//Override the previous definition to make sure there always exist a point (CrossoverPoint, 0.5)
		protected override void UpdateSeriesPoints(){
			series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
				series.Points.AddXY(x, y);
				if(x<=CrossoverPoint && x+theUniverse.Interval>=CrossoverPoint)
					series.Points.AddXY(CrossoverPoint, 0.5);
            }
		}
		//Category the parameters
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
		public double CrossoverPoint{
			get{
				return parameters["CrossoverPoint"];
			}
			set{
				parameters["CrossoverPoint"] = value;
				UpdateSeriesPoints();
			}
		}
    }
}
