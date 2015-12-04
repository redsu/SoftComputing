using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass08 {
    public class PermutationGA : GASolver<int>
    {

        PermutationCrossover crossoverType = PermutationCrossover.PartialMapX; // Default crossover type
        PermutationMutation mutationType = PermutationMutation.Inversion;  // Default mutation type
        int[] p1;  // Working array used in GA operations
        int[] p2; // Working array used in GA operations
        int[] selected; // Record the slected cut positions or crossovered gene positions

		[Category("GA Setting")]
		public PermutationCrossover CrossoverType{
			get;
			set;
		}

		[Category("GA Setting")]
		public PermutationMutation MutationType{
			get;
			set;
		}

        public PermutationGA(int numberOfVariables, OptimizationType opType, GASolver<int>.ObjectiveFunctionDelegate objectFunction) 
            : base( numberOfVariables, opType, objectFunction ){
			p1 = new int[numberOfGenes];
            p2 = new int[numberOfGenes];
            selected = new int[numberOfGenes];
        }

        // Properties of a permutation GA
        //[Category("GA Setting")]
        //[Category("GA Setting")]

  

        /// <summary>
        ///  Overriden function that randomly assign sequencing gene values to the population
        /// </summary>
        public override void initializePopulation(){
            for( int i = 0; i < populationSize; i++ ){
				for (int j = 0; j < this.numberOfGenes; j++)
					chromosomes[i][j] = j;
				shuffle(chromosomes[i]);
            }
        }

        
        /// <summary>
        ///  Helping function that randomly shuffles the given array of permutation encoded integral array.
        /// </summary>
        /// <param name="array"> the list of ingegers </param>
        private void shuffle(int[] array){
            for( int i = numberOfGenes-1; i> 0; i-- ){
                int index = this.randomizer.Next(i + 1);
				int temp = array[index];
				array[index] = array[i];
				array[i] = temp;
            }
        }


        /// <summary>
        ///  Perform regular crossover operation on a pair of parents and set gene values to a pair of children
        /// </summary>
        /// <param name="fartherIdx"> farther index on the chromosome array </param>
        /// <param name="motherIdx"> mother index on the chromosome array </param>
        /// <param name="child1Idx"> the first child index on the chromosome array </param>
        /// <param name="child2Idx"> the second child index on the chromosome array </param>
        public override void generateAPairOfCrossoveredOffspring(int fartherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            int pos1, pos2, temp, j, k, p, q, start1, start2, aSource, aTarget, numberOfPairs, index;
            bool done;

            // Perform different crossover operations
            switch (crossoverType){
                case PermutationCrossover.PartialMapX:
                    pos1 = randomizer.Next(numberOfGenes);
                    do{
                        pos2 = randomizer.Next(numberOfGenes);
                    } while (pos1 == pos2);

                    if (pos1 > pos2){
                        temp = pos1;
                        pos1 = pos2;
                        pos2 = temp;
                    }
					j = 0;
					numberOfPairs = 0;
                    while(j < numberOfGenes) {
						if(j>=pos1&&j<=pos2) {
							chromosomes[child1Idx][j] = chromosomes[motherIdx][j];
							chromosomes[child2Idx][j] = chromosomes[fartherIdx][j];
							if(chromosomes[fartherIdx][j]!=chromosomes[motherIdx][j]) {
								pos1 = pos2 = -1;
								for(int i=0;i<numberOfPairs;i++)
									if(p1[i] == chromosomes[motherIdx][j]) {
										pos1 = i;
										break;
                                    }
								for(int i=0;i<numberOfPairs;i++)
									if(p2[i] == chromosomes[fartherIdx][j]) {
										pos2 = i;
										break;
                                    }
								if(pos1 >= 0 && pos2 >= 0) {
									if(pos1==pos2) {
										for(int i=pos1;i<numberOfPairs-1;i++) {
											p1[i] = p1[i + 1];
											p2[i] = p2[i + 1];
										}
										numberOfPairs--;
									}
									else if(pos1<pos2) {
										p1[pos1] = p1[pos2];
										for(int i=pos2;i<numberOfPairs-1;i++) {
											p1[i] = p1[i + 1];
											p2[i] = p2[i + 1];
										}
										numberOfPairs--;
									}
									else if(pos1>pos2) {
										p2[pos2] = p2[pos1];
										for(int i=pos1;i<numberOfPairs-1;i++) {
											p1[i] = p1[i + 1];
											p2[i] = p2[i + 1];
										}
										numberOfPairs--;
									}
								}
							}
							else{
								if(pos1>=0)
									p1[pos1] = chromosomes[fartherIdx][j];
								else {
									if(pos2>=0)
										p2[pos2] = chromosomes[motherIdx][j];
									else{
										p1[numberOfPairs] = chromosomes[fartherIdx][j];
										p2[numberOfPairs] = chromosomes[motherIdx][j];
										numberOfPairs++;
									}
								}
							}
						}
						else {
							chromosomes[child1Idx][j] = chromosomes[fartherIdx][j];
							chromosomes[child2Idx][j] = chromosomes[motherIdx][j];
						}
					}
					
					for(int i=0; i<numberOfPairs; i++) {
						for(j=0; j<numberOfGenes; j++) {
							if(j>=pos1&&j<=pos2) {
								if (chromosomes[child1Idx][j] == p2[i])
									chromosomes[child1Idx][j] = p1[i];
								if (chromosomes[child2Idx][j] == p1[i])
									chromosomes[child2Idx][j] = p2[i];
							}
						}
					}

                    break;
                case PermutationCrossover.OrderX:

// ...
                    break;

                case PermutationCrossover.CycleX:

// ...

                    break;

                case PermutationCrossover.PositionBasedX:

 // ...

                    break;

                case PermutationCrossover.OrderBasedX:
                     // source 登記 內容 target 登記其餘內容
// ...
                    break;
            }
        }


        /// <summary>
        ///  Overriden mutation operations on permutation encoding GA
        /// </summary>
        public override void performMutateOperation()
        {
            // Perform silimar binary encoded GA mutation operation to identify number of parents
            // subject to mutation operation and the parent idices are stored in indices array
            numberOfMutatedChildren = SimulateMutatedGenesMarkingAndPackParentIndicesReturnBound();

            // Set the first mutated chromosome index
            int start = populationSize + numberOfCrossoveredChildren;

            // One by one generated mutated child chromosome
            for (int ii = 0; ii < numberOfMutatedChildren; ii++)
            {
                int cid = start + ii;

                // Copy genes from the targeted parent
//...

                int pos1, pos2;

                // Perform mutation operation on the newly copied child chromosome
                switch (mutationType)
                {
                    case PermutationMutation.Inversion:
                        pos1 = randomizer.Next(numberOfGenes);
                        do
                        {
                            pos2 = randomizer.Next(numberOfGenes);
                        }
                        while (pos2 == pos1);
//...                            chromosomes[cid][i] = chromosomes[cid][j];
//...                            chromosomes[cid][j] = temp;
                        break;
                    case PermutationMutation.Insertion:
                        //...
                        break;
                    case PermutationMutation.Displacement:

//...
                        break;
                    case PermutationMutation.ReciprocalExchange:
                        //...
                        break;
                }
            }
        }

    }

    // Newly defined enumeration for flagging the types of mutations and crossover operation on permutation-encoded GA
    public enum PermutationCrossover { PartialMapX, OrderX, PositionBasedX, OrderBasedX, CycleX, SubtourX }
    public enum PermutationMutation {  Inversion, Swapped, Insertion, Displacement, ReciprocalExchange }
}