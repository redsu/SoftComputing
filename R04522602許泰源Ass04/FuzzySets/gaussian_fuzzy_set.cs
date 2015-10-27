using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass04{
    class gaussian_fuzzy_set : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public gaussian_fuzzy_set(Universe u) : base(u){
			
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
			
			double p1, p2;
			
			breakpoints = new DataPoint[3];
			breakpoints[0] = new DataPoint(mean, GetFunctionValue(mean));

			p1 = mean + (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
			p2 = mean - (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));
			
			UpdateSeriesPoints();
			
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0f;
            double c, sigma;
            c = Mean;
            sigma = Std;
            
            y = Math.Exp(-Math.Pow((x - c), 2.0)/(2.0 * Math.Pow(sigma, 2.0)));
            
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

		//Category the parameters
		[Category("Parameters")]
		public double Mean{
			get{
				return parameters["mean"];
			}
			set{
				parameters["mean"] = value;
				breakpoints[0].XValue = value;
				double p1, p2;
				p1 = value + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
				p2 = value - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
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
					double p1, p2;

					p1 = Mean + (theUniverse.Xmax - theUniverse.Xmin)/4;
					breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));

					p2 = Mean - (theUniverse.Xmax - theUniverse.Xmin)/4;
					breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
    }
}