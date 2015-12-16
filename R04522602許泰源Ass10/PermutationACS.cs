using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass10{
    public class PermutationACS : AntColonyOptimizationSolver{
        public PermutationACS(int numVars, OptimizationType optType, ObjectiveFunction objFunction, HeuristicFunction heuristicFunction,
            bool square = true, int numGrps = 1) : base(numVars, optType, objFunction, heuristicFunction,square, numGrps){
			;
		}
    }
}