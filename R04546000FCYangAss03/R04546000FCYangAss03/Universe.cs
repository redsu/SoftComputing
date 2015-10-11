using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;



namespace R04546000FCYangAss03
{
    public class Universe
    {
        static int count = 1;
        public string name;
        public double xmin = 0.0, xmax = 10.0, interval = 0.1;
        public ChartArea area;
        public Chart hostChart;

        // consturctor
        public Universe( Chart c )
        {
            hostChart = c;
            name = "X" + count++.ToString();
            area = new ChartArea(name);
            area.AxisX.Minimum = xmin;
            area.AxisX.Maximum = xmax;
            area.AxisX.Title = name;
            area.AxisX.Enabled = AxisEnabled.True;
            c.ChartAreas.Add(area);
        }



    }
}
