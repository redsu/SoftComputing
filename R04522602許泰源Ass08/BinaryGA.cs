using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass08{

    /// <summary>
    ///  BinaryGA uses byte type to store 0 or 1 values for a binary-coded GA representation
    /// </summary>
    public class BinaryGA : GASolver<byte>{

        /// <summary>
        ///  Number of cuts in crossover operation
        /// </summary>
        ///        
        [Category("GA Setting"), Description("交配演算的切點數，建議值大於 1。")]
        public int CrossoverCuts{
            set{
                if (value != cutPos.Length){
                    cutPos = new int[value];
                }
            }
            get{
                return cutPos.Length;
            }
        }

        // Used in cut operation
        int[] cutPos = new int[1];


        /// <summary>
        ///  Constructor for an binary coded GA solver.
        /// </summary>
        /// <param name="numberOfVariables"> number of variables </param>
        /// <param name="opType"> optimization type </param>
        /// <param name="objectFunction"> the function delegate computing the objective value </param>
        public BinaryGA(int numberOfVariables, OptimizationType opType, GASolver<byte>.ObjectiveFunctionDelegate objectFunction) : base
            (numberOfVariables, opType, objectFunction){
			//Do nothing, since that all the initiation were done by the constructor in GASolver.
			;
        }


        /// <summary>
        ///  Own procedure that generated mutated offspring
        /// </summary>
        public override void performMutateOperation(){
            // Determine number of mutated genes
            int totalGenes = populationSize * numberOfGenes;
            int numberOfMutatedGenes = (int)(mutationRate * totalGenes);
			int size = populationSize * 2, len = chromosomes.Length;
            // clean the third part of gene for flagging the mutated genes
			for(int i=size; i< len; i++) {
				for (int j = 0; j < numberOfGenes; j++)
					chromosomes[i][j] = 0;
			}
 // ...
            // Mark mutated genes
			for(int i=0; i<numberOfMutatedGenes; i++) {
				int rand = randomizer.Next(totalGenes);
				chromosomes[size + rand / numberOfGenes][rand % numberOfGenes] = 1;
			}

 // ...
            // Loop through each chromosome in third part for marks.
            // If a mark is found, a mutated chromosome is duplacted from the corresponding parent and 
            // the marked places are 0-1 replaced.
            // Notice that mutated chromosomes are adjacent to previously created crossovered offspring.
            // That is the starting index for mutated offspring is   populationSize + numberOfCrossoveredChildren
            numberOfMutatedChildren = 0;
            for (int i = size; i < len; i++){
				bool mutated = false;
				for (int j = 0; j < numberOfGenes; j++) {
					if(chromosomes[i][j] == 1){
						mutated = true;
						break;
					}
				}
				if(mutated){
					int indexOfMutatedParent = i - size;
					int indexOfMutatedChildren = populationSize + numberOfMutatedChildren + numberOfMutatedChildren;
					for (int j = 0; j < numberOfGenes; j++){
						if(chromosomes[indexOfMutatedChildren][j]==1)
							chromosomes[indexOfMutatedChildren][j] = (byte)(1 - chromosomes[indexOfMutatedParent][j]);
						else
							chromosomes[indexOfMutatedChildren][j] = chromosomes[indexOfMutatedParent][j];
					}
					indexOfMutatedChildren++;
				}
            }
            // Update numberOfMutatedChildren for further reference
        }


        /// <summary>
        ///  Own crossover operation procedure to generate and set gene values for a pair of 
        ///  crossovered offspring by referring to a given pair of parent indices 
        /// </summary>
        /// <param name="fartherIdx"> index of farther chromosome </param>
        /// <param name="motherIdx"> index of mother chromosome  </param>
        /// <param name="child1Idx"> index of child 1 chromosome </param>
        /// <param name="child2Idx"> index of child 2 chromosome </param>
        public override void generateAPairOfCrossoveredOffspring(int fartherIdx, int motherIdx, int child1Idx, int child2Idx){
            // Randomly set cut positions for the n cuts.
            // Check class Array for utility functions: Sort(), Inverset(), ...
           // ...     for (int i = 0; i < cutPos.Length; i++) cutPos[i] = randomizer.Next(numberOfGenes);
			for(int i=0; i<cutPos.Length; i++)
				cutPos[i] = randomizer.Next(numberOfGenes);
			Array.Sort<int>(cutPos);
			int front = 0, back;
			for(int i=0; i<=cutPos.Length; i++){
				
				if (i == cutPos.Length)
					back = numberOfGenes;
				else
					back = cutPos[i];

				int crossidx1, crossidx2;

				if (i%2==0){
					crossidx1 = child1Idx;
					crossidx2 = child2Idx;
				}
				else{
					crossidx1 = child2Idx;
					crossidx2 = child1Idx;
				}

				for (int j = front; j < back; j++){
					this.chromosomes[crossidx1][j] = this.chromosomes[fartherIdx][j];
					this.chromosomes[crossidx2][j] = this.chromosomes[motherIdx][j];
				}
				front = back;
			}
        }

        /// <summary>
        ///  Own implementation of population initialization, which will be called in reset function.
        ///  Randomly fill in 0 or 1 value to each gene of each parent chromosome.
        /// </summary>
        public override void initializePopulation(){
            //for (int i = 0; i < populationSize; i++)
            //    for (int j = 0; j < numberOfGenes; j++)
            // ...
			for(int i=0; i<populationSize; i++)
				for(int j=0; j<numberOfGenes; j++)
					chromosomes[i][j] = (byte)(randomizer.Next() % 2);
        }
    }

}
