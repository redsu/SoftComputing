using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
    class gaussian_function : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public gaussian_function(Universe u) : base(u){
			
			name = "Gaussian" + count++.ToString();
			tmp_name = name;
			double mean, sigma;
			mean = theUniverse.Xmin + rnd.NextDouble() * (theUniverse.Xmax-theUniverse.Xmin);
			sigma = 2.0f;
			mean = (int)mean;
			sigma = (int) sigma;
            series.Name = name;
			parameters.Add("mean", mean);
            parameters.Add("sigma", sigma);
            UpdateSeriesPoints();
			int num_pt = series.Points.Count;
			int num_pt_M = (int)((double)num_pt * (parameters["mean"] - theUniverse.Xmin) / (theUniverse.Xmax-theUniverse.Xmin));
			for(int i=1; i<num_pt-1; i++)
				if(series.Points[i].YValues[0]==1){
					series.Points[i].MarkerStyle = MarkerStyle.Circle;
					break;
				}
			if(num_pt_M+num_pt/4<series.Points.Count)
				series.Points[num_pt_M+num_pt/4].MarkerStyle = MarkerStyle.Square;
			if(num_pt_M-num_pt/4>0)
				series.Points[num_pt_M-num_pt/4].MarkerStyle = MarkerStyle.Square;
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

		//Get function value of given x.
        protected override double GetFunctionValue(double x){
            double y = 0.0f;
            double c, sigma;
            c = Mean;
            sigma = Std;
            
            y = Math.Exp(-Math.Pow((x - c), 2.0f)/(2.0f * Math.Pow(sigma, 2.0f)));
            
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

		//Override the previous definition to make sure there always exist a point (Mean, 1.0)
		protected override void UpdateSeriesPoints(){
            series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
				if(x<=Mean && x+theUniverse.Interval>=Mean)
					series.Points.AddXY(Mean, 1.0);
            }
        }

		//Category the parameters
		[Category("Parameters")]
		public double Mean{
			get{
				return parameters["mean"];
			}
			set{
				parameters["mean"] = value;
				UpdateSeriesPoints();
				int num_pt = series.Points.Count;
				int num_pt_M = (int)((double)num_pt * (Mean - theUniverse.Xmin) / (theUniverse.Xmax-theUniverse.Xmin));
				for(int i=1; i<num_pt-1; i++)
					if(series.Points[i].YValues[0]==1){
						series.Points[i].MarkerStyle = MarkerStyle.Circle;
						break;
					}
				if(num_pt_M+num_pt/4<series.Points.Count)
					series.Points[num_pt_M+num_pt/4].MarkerStyle = MarkerStyle.Square;
				if(num_pt_M-num_pt/4>0)
					series.Points[num_pt_M-num_pt/4].MarkerStyle = MarkerStyle.Square;
			}
		}
		[Category("Parameters")]
		public double Std{
			get{
				return parameters["sigma"];
			}
			set{
				if(value >= 0){
					parameters["sigma"] = value;
					UpdateSeriesPoints();
					int num_pt = series.Points.Count;
					int num_pt_M = (int)((double)num_pt * (Mean - theUniverse.Xmin) / (theUniverse.Xmax-theUniverse.Xmin));
					for(int i=1; i<num_pt-1; i++)
					if(series.Points[i].YValues[0]==1){
						series.Points[i].MarkerStyle = MarkerStyle.Circle;
						break;
					}
					if(num_pt_M+num_pt/4<series.Points.Count)
						series.Points[num_pt_M+num_pt/4].MarkerStyle = MarkerStyle.Square;
					if(num_pt_M-num_pt/4>0)
						series.Points[num_pt_M-num_pt/4].MarkerStyle = MarkerStyle.Square;
				}
			}
		}
    }
}