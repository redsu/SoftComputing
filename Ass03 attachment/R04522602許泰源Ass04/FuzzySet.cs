using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass03{
    public class FuzzySet{
        protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));

        protected string name;
		public string tmp_name;
        protected Dictionary<string, double> parameters = new Dictionary<string,double>();
        protected Universe theUniverse;
        protected Series series;

        public FuzzySet(){
        }

        public FuzzySet( Universe u ){
            theUniverse = u;
			theUniverse.ParameterChanged += theUniverse_ParameterChanged;
			series = new Series();
			series.ChartType = SeriesChartType.Line;
            u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;
        }

        protected virtual double GetFunctionValue(double x){
            return 0.0;
        }

		void theUniverse_ParameterChanged(object sender, EventArgs e){
            UpdateSeriesPoints();
        }

        protected virtual void UpdateSeriesPoints(){
            series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
            }
        }
		[Category("Design")]
		public string Name{
            get {
				return name;
			}
            set {
				name = value;
			}
        }
		
		public void SetWidth(int w){
			series.BorderWidth = w;
		}
    }
}
