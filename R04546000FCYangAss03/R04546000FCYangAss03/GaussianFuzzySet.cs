using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R04546000FCYangAss03
{
    public class GaussianFuzzySet : FuzzySet
    {
        static int count = 1;

        public GaussianFuzzySet( Universe u ) : base( u )
        {
            name = "Gaussian" + count++.ToString();
            parameterValues = new double[2];
            parameterValues[0] = theUniverse.xmin + rnd.NextDouble() * (theUniverse.xmax - theUniverse.xmin);
            parameterValues[1] = 2;

            UpdateSeriesPoints();
        }

        protected override double GetFunctionValue(double x)
        {
            return Math.Exp(-0.5 * (x - parameterValues[0]) * (x - parameterValues[0]) / parameterValues[1] / parameterValues[1]);
        }
    }
}
