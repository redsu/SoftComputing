using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	class PI_fuzzy_set : FuzzySet{
		//private Dictionary<string, double> parameters = new Dictionary<string,double>();
        private static int count = 1;
        //Constuctor
        public PI_fuzzy_set(Universe u) : base(u){
			
			name = "PiFuzzySet(" + count++.ToString() +")";
			double left = theUniverse.Xmax, right = theUniverse.Xmin;
			double middle;
			double leftcorner, rightcorner;
			middle = theUniverse.Xmin + rnd.NextDouble() * (theUniverse.Xmax-theUniverse.Xmin);
			rightcorner = left;
			leftcorner = right;
			while(middle <= left)
				left = theUniverse.Xmin + rnd.NextDouble() * (right-theUniverse.Xmin);
			while(middle >= right)
				right = middle + rnd.NextDouble() * (theUniverse.Xmax-middle);
			
			while(middle <= leftcorner || leftcorner <= left)
				leftcorner = theUniverse.Xmin + rnd.NextDouble() * (right-theUniverse.Xmin);

			while(middle >= rightcorner || rightcorner >= right)
				rightcorner = theUniverse.Xmin + rnd.NextDouble() * (right-theUniverse.Xmin);

            series.Name = name;
			parameters.Add("Left", left);
            parameters.Add("Left Corner", leftcorner);
            parameters.Add("Right Corner", rightcorner);
			parameters.Add("Right", right);

			breakpoints = new DataPoint[4];

			breakpoints[0] = new DataPoint(left, 0.0);
			breakpoints[1] = new DataPoint(leftcorner, 1.0);
			breakpoints[2] = new DataPoint(rightcorner, 1.0);
			breakpoints[3] = new DataPoint(right, 0.0);

            UpdateSeriesPoints();
		}

		//override ToString() in order to show self-defined function name in listbox.
        public override string ToString(){
            return name;
        }

        //Get function value of given x.
        public override double GetFunctionValue(double x){
            double y = 0.0f;

            if(x<=Left)
				y = 0;
			else if(x<=(Left+LeftCorner)/2)
				y = 2*((x-Left)/(LeftCorner-Left))*((x-Left)/(LeftCorner-Left));
			else if(x<=LeftCorner)
				y = 1 - 2*((x-LeftCorner)/(LeftCorner-Left))*((x-LeftCorner)/(LeftCorner-Left));
			else if(x<=RightCorner)
				y = 1;
			else if(x<=(Right+RightCorner)/2)
				y = 1-2*((x-RightCorner)/(Right-RightCorner))*((x-RightCorner)/(Right-RightCorner));
			else if(x<=Right)
				y = 2*((x-Right)/(Right-RightCorner))*((x-Right)/(Right-RightCorner));
			else
				y = 0;
            
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

		//Category the parameters
		[Category("Parameters")]
		public double Left{
			get{
				return parameters["Left"];
			}
			set{
				if(value<parameters["Left Corner"]){
					parameters["Left"] = value;
					breakpoints[0].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double Right{
			get{
				return parameters["Right"];
			}
			set{
				if(value>parameters["Right Corner"]){
					parameters["Right"] = value;
					breakpoints[3].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double RightCorner{
			get{
				return parameters["Right Corner"];
			}
			set{
				if(parameters["Left Corner"]<value&&parameters["Right"]>value){
					parameters["Right Corner"] = value;
					breakpoints[2].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Category("Parameters")]
		public double LeftCorner{
			get{
				return parameters["Left Corner"];
			}
			set{
				if(parameters["Right Corner"]>value&&parameters["Left"]<value){
					parameters["Left Corner"] = value;
					breakpoints[1].XValue = value;
					UpdateSeriesPoints();
					TriggerEvent();
				}
			}
		}
		[Browsable(false)]
		public override double MaxDegree{
			get{
				return 1.0;
			}
		}
	}
}
