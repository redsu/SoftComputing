using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass06{
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
			if(ctype_toggle)
				series.ChartType = SeriesChartType.Area;
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
		public virtual double MaxDegreeMember{
			get{
				return series.Points.FindMaxByValue("Y1").XValue;
			}
		}

		[Browsable(false)]
		public virtual double COACrispValue{
			get{
				if(series.Points.Count == 0)
					UpdateSeriesPoints();
				double x, num = 0.0, den = 0.0;
				x = series.Points[0].XValue;
				for(int i=1; i<series.Points.Count; i++){
					num += series.Points[i].YValues[0] * (series.Points[i].XValue - x) * series.Points[i].XValue;
					den += series.Points[i].YValues[0] * (series.Points[i].XValue - x);
				}

				if(den > 0)
					return num/den;
				else
					return 0.0;
			}
		}

		[Browsable(false)]
		public virtual double BOACrispValue{
			get{
				if(series.Points.Count == 0)
					UpdateSeriesPoints();
				double x, L = 0.0, R = 0.0;
				int i;
				x = series.Points[0].XValue;
				for(i=1; i<series.Points.Count; i++){
					R += series.Points[i].YValues[0] * (series.Points[i].XValue - x);
				}
				for(i=1; i<series.Points.Count; i++){
					L += series.Points[i].YValues[0] * (series.Points[i].XValue - x);
					R -= series.Points[i].YValues[0] * (series.Points[i].XValue - x);
					if(L>=R)
						break;
				}
				return i;
			}
		}

		[Browsable(false)]
		public virtual double MOMCrispValue{
			get{
				if(series.Points.Count == 0)
					UpdateSeriesPoints();
				double x, max = 0.0;
				int i, mi = 0, cnt = 0, L = 0, R = 0;
				x = series.Points[0].XValue;
				for(i=0; i<series.Points.Count; i++){
					if(series.Points[i].YValues[0] >= max){
						max = series.Points[i].YValues[0];
						mi = i;
					}
				}
				for(i=0; i<series.Points.Count; i++)
					if(series.Points[i].YValues[0] == max)
						cnt++;
				if(cnt == 1)
					return mi;
				else{
					if(series.Points[0].YValues[0] == max)
						L = 0;
					else
						for(i=1; i<series.Points.Count; i++){
							if(series.Points[i].YValues[0]==max&&series.Points[i-1].YValues[0]!=max)
								L = i;
						}

					if(series.Points[series.Points.Count-1].YValues[0] == max)
						R = series.Points.Count-1;
					else
						for(i=0; i<series.Points.Count-1; i++){
							if(series.Points[i].YValues[0]!=max&&series.Points[i+1].YValues[0]==max)
								R = i;
						}

					return (L+R)/2;
				}
			}
		}

		[Browsable(false)]
		public virtual double SOMCrispValue{
			get{
				if(series.Points.Count == 0)
					UpdateSeriesPoints();
				double x, max = 0.0;
				int i, mi = 0, cnt = 0, L = 0;
				x = series.Points[0].XValue;
				for(i=0; i<series.Points.Count; i++){
					if(series.Points[i].YValues[0] >= max){
						max = series.Points[i].YValues[0];
						mi = i;
					}
				}
				for(i=0; i<series.Points.Count; i++)
					if(series.Points[i].YValues[0] == max)
						cnt++;
				if(cnt == 1)
					return mi;
				else{
					if(series.Points[0].YValues[0] == max)
						L = 0;
					else
						for(i=1; i<series.Points.Count; i++){
							if(series.Points[i].YValues[0]==max&&series.Points[i-1].YValues[0]!=max)
								L = i;
						}
					return L;
				}
			}
		}

		[Browsable(false)]
		public virtual double LOMCrispValue{
			get{
				if(series.Points.Count == 0)
					UpdateSeriesPoints();
				double x, max = 0.0;
				int i, mi = 0, cnt = 0, R = 0;
				x = series.Points[0].XValue;
				for(i=0; i<series.Points.Count; i++){
					if(series.Points[i].YValues[0] >= max){
						max = series.Points[i].YValues[0];
						mi = i;
					}
				}
				for(i=0; i<series.Points.Count; i++)
					if(series.Points[i].YValues[0] == max)
						cnt++;
				if(cnt == 1)
					return mi;
				else{
					if(series.Points[series.Points.Count-1].YValues[0] == max)
						R = series.Points.Count-1;
					else
						for(i=0; i<series.Points.Count-1; i++){
							if(series.Points[i].YValues[0]!=max&&series.Points[i+1].YValues[0]==max)
								R = i;
						}

					return R;
				}
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

		public double GetMemberByDegree(double degree){
			for(int i=1; i<series.Points.Count; i++){
				if((series.Points[i].YValues[0]<degree&&series.Points[i-1].YValues[0]>=degree)||
				   (series.Points[i].YValues[0]>degree&&series.Points[i-1].YValues[0]<=degree))
					return series.Points[i].YValues[0];
			}
			return 0.0;
		}
    }
}
