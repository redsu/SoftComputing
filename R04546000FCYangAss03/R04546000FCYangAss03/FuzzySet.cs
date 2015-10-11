using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04546000FCYangAss03
{
    public class FuzzySet
    {
        protected static Random rnd = new Random(unchecked(DateTime.Now.Ticks.GetHashCode()));

        public string name;
        protected double[] parameterValues;
        protected Universe theUniverse;
        protected Series series;

        public FuzzySet()
        {
        }

        public FuzzySet( Universe u )
        {
            theUniverse = u;
            series = new Series();
            series.ChartType = SeriesChartType.Line;
            u.hostChart.Series.Add(series);
            series.ChartArea = u.area.Name;
        }

        protected virtual double GetFunctionValue(double x)
        {
            return 0.0;
        }

        protected void UpdateSeriesPoints()
        {
            series.Points.Clear();
            for (double x = theUniverse.xmin; x <= theUniverse.xmax; x = x + theUniverse.interval)
            {
                double y = GetFunctionValue( x );
                series.Points.AddXY(x, y);
            }
        }

    }
}
