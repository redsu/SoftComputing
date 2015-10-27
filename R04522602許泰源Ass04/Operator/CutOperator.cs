﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace R04522602許泰源Ass05{
	class CutOperator : UnaryOperator{
		double[] parameters;
		public CutOperator() {
			name = "Cut";
			parameters = new double[1];
			parameters[0] = rnd.NextDouble();
		}
		public override double calculateFinalValue(double v){
            return parameters[0] > v ? v : parameters[0];
        }
	}
}
