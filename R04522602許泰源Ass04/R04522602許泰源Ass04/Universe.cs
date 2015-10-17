using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass03{
	public class Universe{
		static int count = 1;
		protected string name;
		public string tmp_name;
		double interval;
        public ChartArea area;
        public Chart hostChart;
		public event EventHandler ParameterChanged;
        // consturctor
        public Universe( Chart c ){
            hostChart = c;
            name = "X" + count++.ToString();
			tmp_name = name;
            area = new ChartArea(name);
            area.AxisX.Minimum = 0.0f;
            area.AxisX.Maximum = 10.0f;
            area.AxisX.Title = name;
            area.AxisX.Enabled = AxisEnabled.True;
			area.AxisY.Minimum = 0.0f;
			area.AxisY.Maximum = 1.25f;
			interval = (area.AxisX.Maximum-area.AxisX.Minimum)/500;
            c.ChartAreas.Add(area);
        }

		public Universe( Chart c , string name){
            hostChart = c;
            this.name = name;
			tmp_name = name;
            area = new ChartArea(name);
            area.AxisX.Minimum = 0.0f;
            area.AxisX.Maximum = 10.0f;
            area.AxisX.Title = this.name;
            area.AxisX.Enabled = AxisEnabled.True;
			area.AxisY.Minimum = 0.0f;
			area.AxisY.Maximum = 1.25f;
			interval = (area.AxisX.Maximum-area.AxisX.Minimum)/500;
            c.ChartAreas.Add(area);
        }

		public Universe( Chart c , string name, double min, double max){
			hostChart = c;
            this.name = name;
			tmp_name = name;
            area = new ChartArea(name);
			area.AxisX.Maximum = max;
			area.AxisX.Minimum = min;
            area.AxisX.Minimum = area.AxisX.Minimum;
            area.AxisX.Maximum = area.AxisX.Maximum;
            area.AxisX.Title = this.name;
            area.AxisX.Enabled = AxisEnabled.True;
			area.AxisY.Minimum = 0.0f;
			area.AxisY.Maximum = 1.25f;
			this.interval = (area.AxisX.Maximum-area.AxisX.Minimum)/500;
            c.ChartAreas.Add(area);
			count++;
        }

		public int GetCount(){
			return count;
		}

		
		[Category("Parameters")]
		public double Xmin{
			get{
				return area.AxisX.Minimum;
			}
			set{
				if(value < area.AxisX.Maximum){
					area.AxisX.Minimum = value;
					if( ParameterChanged != null ) ParameterChanged(this, null);
				}
			}
		}
		[Category("Parameters")]
		public double Xmax{
			get{
				return area.AxisX.Maximum;
			}
			set{
				if(value > area.AxisX.Minimum){
					area.AxisX.Maximum = value;
					if( ParameterChanged != null ) ParameterChanged(this, null);
				}
			}
		}
		[Category("Parameters")]
		public double Interval{
			get{
				return interval;
			}
			set{
				if(value > 0 && value < (area.AxisX.Maximum-area.AxisX.Minimum)/100.0f && value >= (area.AxisX.Maximum-area.AxisX.Minimum)/1000.0f){
					interval = value;
					if( ParameterChanged != null ) ParameterChanged(this, null);
				}
			}
		}
		[Category("Design")]
		public string Name{
			get{
				return name;
			}
			set{
				name = value;
			}
		}
	}
}
