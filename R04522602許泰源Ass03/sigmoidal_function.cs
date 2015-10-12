using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
    class sigmoidal_function : FuzzySet{
        private Dictionary<string, double> parameters = new Dictionary<string,double>();
		private static int count = 1;

		//Constuctor
        public sigmoidal_function(Universe u) : base(u){
			name = "Sigmoidal" + count++.ToString();
			double slope, crossoverpt;
			slope = 3.0f;
			crossoverpt = theUniverse.xMin + rnd.NextDouble()*(theUniverse.xMax-theUniverse.xMin);

            series.Name = name;

			parameters.Add("Slope", slope);
            parameters.Add("CrossoverPoint", crossoverpt);

			UpdateSeriesPoints();
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
