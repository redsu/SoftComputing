﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass04{
	public class UnaryOperator{
		protected string name;

        public string Name{
            get{
                return name;
            }
            set{
                name = value;
            }
        }

        public virtual double calculateFinalValue(double x){
			return 0.0;
		}

        
    }
}
