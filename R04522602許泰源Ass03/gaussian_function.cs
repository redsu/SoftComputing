using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
    class gaussian_function : FuzzySet{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public gaussian_function(Universe u) : base(u){
			double mean, sigma;
			mean = theUniverse.xMin + rnd.NextDouble() * (theUniverse.xMax - theUniverse.xMin);
			sigma = 2.0f;
			name = "Gaussian" + count++.ToString();

            series.Name = name;;

			parameters.Add("mean", mean);
            parameters.Add("sigma", sigma);
            UpdateSeriesPoints();
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

		//Get function value of given x.
        protected override double GetFunctionValue(double x){
            double y = 0.0f;
            double c, sigma;
            c = parameters["mean"];
            sigma = parameters["sigma"];
            
            y = Math.Exp(-Math.Pow((x - c), 2.0f)/(2.0f * Math.Pow(sigma, 2.0f)));
            
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