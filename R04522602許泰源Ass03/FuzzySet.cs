using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
    public class FuzzySet{
        protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));

        protected string name;
        protected Dictionary<string, double> parameters = new Dictionary<string,double>();
        protected Universe theUniverse;
        protected Series series;

        public FuzzySet(){
        }

        public FuzzySet( Universe u ){
            theUniverse = u;
			series = new Series();
			series.ChartType = SeriesChartType.Line;
            u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;
        }

        protected virtual double GetFunctionValue(double x){
            return 0.0;
        }

        protected void UpdateSeriesPoints(){
            series.Points.Clear();
            for (double x = theUniverse.Xmin; x <= theUniverse.Xmax; x = x + theUniverse.Interval){
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
            }
        }

		public string GetName(){
			return name;
		}
		public void SetWidth(int w){
			series.BorderWidth = w;
		}
    }
}
