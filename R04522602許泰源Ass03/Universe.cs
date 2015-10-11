using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R04522602許泰源Ass03{
	public class Universe{
		static int count = 1;
		public string name;
		public double xMin = 0.0, xMax = 10.0, Interval;
        public ChartArea area;
        public Chart hostChart;

        // consturctor
        public Universe( Chart c ){
            hostChart = c;
            name = "X" + count++.ToString();
            area = new ChartArea(name);
            area.AxisX.Minimum = xMin;
            area.AxisX.Maximum = xMax;
            area.AxisX.Title = name;
            area.AxisX.Enabled = AxisEnabled.True;
			area.AxisY.Minimum = 0.0f;
			area.AxisY.Maximum = 1.25f;
			Interval = (xMax-xMin)/500;
            c.ChartAreas.Add(area);
        }

		public Universe( Chart c , string name){
            hostChart = c;
            this.name = name;
            area = new ChartArea(name);
            area.AxisX.Minimum = xMin;
            area.AxisX.Maximum = xMax;
            area.AxisX.Title = this.name;
            area.AxisX.Enabled = AxisEnabled.True;
			area.AxisY.Minimum = 0.0f;
			area.AxisY.Maximum = 1.25f;
			Interval = (xMax-xMin)/500;
            c.ChartAreas.Add(area);
        }
	}
}
