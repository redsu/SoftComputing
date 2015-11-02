using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
    class sigmoidal_fuzzy_set : FuzzySet{
        //private Dictionary<string, double> parameters = new Dictionary<string,double>();
		private static int count = 1;

		//Constuctor
        public sigmoidal_fuzzy_set(Universe u) : base(u){
			name = "Sigmoidal" + count++.ToString();
			double slope, crossoverpt;
			slope = 3.0f;
			crossoverpt = theUniverse.Xmin + rnd.NextDouble()*(theUniverse.Xmax-theUniverse.Xmin);

            series.Name = name;

			parameters.Add("Slope", slope);
            parameters.Add("CrossoverPoint", crossoverpt);

			double p1, p2;
			
			breakpoints = new DataPoint[3];
			breakpoints[0] = new DataPoint(crossoverpt, GetFunctionValue(crossoverpt));

			p1 = crossoverpt + (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
			p2 = crossoverpt - (theUniverse.Xmax - theUniverse.Xmin)/4;
			breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

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
        public override double GetFunctionValue(double x){
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
		/*protected override void UpdateSeriesPoints(){
			series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
				series.Points.AddXY(x, y);
				if(x<=CrossoverPoint && x+theUniverse.Interval>=CrossoverPoint)
					series.Points.AddXY(CrossoverPoint, 0.5);
            }
		}*/
		//Category the parameters
		[Category("Parameters")]
		public double Slope{
			get{
				return parameters["Slope"];
			}
			set{
				parameters["Slope"] = value;
				double p1, p2;

				p1 = CrossoverPoint + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
				p2 = CrossoverPoint - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
			}
		}
		[Category("Parameters")]
		public double CrossoverPoint{
			get{
				return parameters["CrossoverPoint"];
			}
			set{
				parameters["CrossoverPoint"] = value;
				breakpoints[0].XValue = value;
				double p1, p2;

				p1 = CrossoverPoint + (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[1] = new DataPoint(p1, GetFunctionValue(p1));
				p2 = CrossoverPoint - (theUniverse.Xmax - theUniverse.Xmin)/4;
				breakpoints[2] = new DataPoint(p2, GetFunctionValue(p2));

				UpdateSeriesPoints();
				TriggerEvent();
			}
		}
		[Browsable(false)]
		public double MaxDegree{
			get{
				return 1.0;
			}
		}
    }
}
