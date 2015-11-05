using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
    public class FuzzySet {
        protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));

        protected string name;
        protected Dictionary<string, double> parameters = new Dictionary<string, double>();
        protected Universe theUniverse;
        protected Series series;
		protected DataPoint[] breakpoints;
		protected bool ctype_toggle = true;
        public FuzzySet() {
        }

        public event EventHandler ParameterChanged;
		public event EventHandler NameChanged;

        //Contructor
        public FuzzySet(Universe u) {
            theUniverse = u;
            theUniverse.ParameterChanged += theUniverse_ParameterChanged;
            series = new Series();
            series.ChartType = SeriesChartType.Line;
            //u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;
			series.Legend = theUniverse.Name;
        }

		[Browsable(false)]
        public Universe TheUniverse {
            get {
                return theUniverse;
            }
        }

		[Browsable(false)]
        public DataPoint[] BP{
            get {
                return breakpoints;
            }
        }

        //Virtual function can be override by new definition
        public virtual double GetFunctionValue(double x) {
            return 0.0;
        }

        protected void TriggerEvent(){
            if (ParameterChanged != null)
                ParameterChanged(this, null);
        }
		protected void TriggerEvent_name(){
			if (NameChanged != null)
                NameChanged(this, null);
        }
        //Update all points in series
        void theUniverse_ParameterChanged(object sender, EventArgs e){
            UpdateSeriesPoints();
        }
        
		//Virtual function can be override by new definition if needed
        protected void UpdateSeriesPoints(){
            series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
            }
			if(breakpoints!=null)
				if(breakpoints.Length!=0){
					foreach(DataPoint pt in breakpoints){
						if(pt != null)
							series.Points.AddXY(pt.XValue, pt.YValues[0]);
					}
				}
			series.Sort(PointSortOrder.Ascending, "X");
			
        }

		//Highlight the selected line
		[Browsable(false)]
		public bool Enchant{
			set{
				if(value){
					series.BorderWidth = 2;
					
					if(breakpoints!=null)
						foreach(DataPoint pt in breakpoints){
							if(pt!=null)
								for(int i=0; i<series.Points.Count; i++){
									if(pt.XValue == series.Points[i].XValue &&
										pt.YValues[0] == series.Points[i].YValues[0]){
										series.Points[i].MarkerSize = 10;
										series.Points[i].MarkerStyle = MarkerStyle.Circle;
										break;
									}
								}
						}

				}
				else{
					series.BorderWidth = 1;
					if(breakpoints!=null)
						foreach(DataPoint pt in breakpoints){
							if(pt!=null)
								for(int i=0; i<series.Points.Count; i++){
									if(pt.XValue == series.Points[i].XValue &&
										pt.YValues[0] == series.Points[i].YValues[0]){
										series.Points[i].MarkerSize = 10;
										series.Points[i].MarkerStyle = MarkerStyle.None;
										break;
									}
								}
						}
				}
			}
		}

		//Category the parameters
		[Category("Design")]
		public string Name{
            get {
				return name;
			}
            set {
				if(theUniverse.hostChart.Series.IsUniqueName(value)){
					name = value;
					series.Name = name;
					TriggerEvent_name();
				}
			}
        }
		//Set the width of line in series
		public void SetWidth(int w){
			series.BorderWidth = w;
		}

		protected virtual void Update_BP(){
			;
		}

		//Operator Overloading
		public static FuzzySet operator ~(FuzzySet f){
			UnaryOperator op = new NegateOperator();
			UnaryOperatedFuzzySet fs = new UnaryOperatedFuzzySet(f, op);
			return fs;
		}

		public static FuzzySet operator -(double alpha, FuzzySet f){
			UnaryOperator op = new CutOperator(alpha);
			UnaryOperatedFuzzySet fs = new UnaryOperatedFuzzySet(f, op);
			return fs;
		}

		public static FuzzySet operator *(double alpha, FuzzySet f){
			UnaryOperator op = new ScaleOperator(alpha);
			UnaryOperatedFuzzySet fs = new UnaryOperatedFuzzySet(f, op);
			return fs;
		}

		public static FuzzySet operator &(FuzzySet f, FuzzySet g){
			BinaryOperator op = new IntersectOperator();
			BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(f, g, op);
			return fs;
		}

		public static FuzzySet operator |(FuzzySet f, FuzzySet g){
			BinaryOperator op = new UnionOperator();
			BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(f, g, op);
			return fs;
		}

		public static FuzzySet operator *(FuzzySet f, FuzzySet g){
			BinaryOperator op = new AlgebraicProduct();
			BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(f, g, op);
			return fs;
		}

		

		public void set_style(){
			if(ctype_toggle) {
				series.ChartType = SeriesChartType.Area;
				series.BorderColor = series.Color;
				series.Color = System.Drawing.Color.FromArgb(100, series.Color);
			}
			else
				series.ChartType = SeriesChartType.Spline;

			ctype_toggle = !ctype_toggle;
		}

		[Browsable(false)]
		public virtual double MaxDegree{
			get{
				return series.Points.FindMaxByValue("Y1").YValues[0];
			}
		}

		[Browsable(false)]
		public bool Display{
			set{
				if(value){
					theUniverse.hostChart.Series.Add(series);
					series.ChartArea = theUniverse.Name;
				}
				else{
					theUniverse.hostChart.Series.Remove(series);
					series.ChartArea = "";
					series.Legend = "";
				}
			}
		}
    }
}
