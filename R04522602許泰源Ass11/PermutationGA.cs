using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace R04522602許泰源Ass11 {
    public class PermutationGA : GASolver<int>{

        PermutationCrossover crossoverType = PermutationCrossover.PartialMapX; // Default crossover type
        PermutationMutation mutationType = PermutationMutation.Inversion;  // Default mutation type
        int[] p1;  // Working array used in GA operations
        int[] p2; // Working array used in GA operations
        int[] selected; // Record the slected cut positions or crossovered gene positions

		[Category("GA Setting")]
		public PermutationCrossover CrossoverType{
			get{
				return crossoverType;
			}
			set{
				crossoverType = value;
			}
		}

		[Category("GA Setting")]
		public PermutationMutation MutationType{
			get{
				return mutationType;
			}
			set{
				mutationType = value;
			}
		}

        public PermutationGA(int numberOfVariables, OptimizationType opType, GASolver<int>.ObjectiveFunctionDelegate objectFunction) 
            : base( numberOfVariables, opType, objectFunction ){
			p1 = new int[numberOfGenes];
            p2 = new int[numberOfGenes];
            selected = new int[numberOfGenes];
        }

        //  Overriden function that randomly assign sequencing gene values to the population
        public override void initializePopulation(){
            for( int i = 0; i < populationSize; i++ ){
				for (int j = 0; j < numberOfGenes; j++)
					chromosomes[i][j] = j;
				shuffle(chromosomes[i]);
            }
        }

        
        //  Helping function that randomly shuffles the given array of permutation encoded integral array.
        private void shuffle(int[] array){
            for( int i = numberOfGenes-1; i> 0; i-- ){
                int index = randomizer.Next(i + 1);
				int temp = array[index];
				array[index] = array[i];
				array[i] = temp;
            }
        }


        //  Perform regular crossover operation on a pair of parents and set gene values to a pair of children
        /// <param name="fartherIdx"> farther index on the chromosome array </param>
        /// <param name="motherIdx"> mother index on the chromosome array </param>
        /// <param name="child1Idx"> the first child index on the chromosome array </param>
        /// <param name="child2Idx"> the second child index on the chromosome array </param>
        public override void generateAPairOfCrossoveredOffspring(int fatherIdx, int motherIdx, int child1Idx, int child2Idx){

            int pos1, pos2, temp, i, j, index, numofpositions;
			int ptr1, ptr2;
			int[] table1, table2, rand;
			table1 = new int[numberOfGenes];
			table2 = new int[numberOfGenes];
			rand   = new int[numberOfGenes];
			
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

					for(i=0; i<numberOfGenes; i++)
						p1[i] = p2[i] = -1;
					
					for(j=0; j<numberOfGenes; j++){
						if(j>=pos1 && j<=pos2){
							if(chromosomes[fatherIdx][j] != chromosomes[motherIdx][j]){
								p1[chromosomes[motherIdx][j]] = chromosomes[fatherIdx][j];
								p2[chromosomes[fatherIdx][j]] = chromosomes[motherIdx][j];
							}
							chromosomes[child1Idx][j] = chromosomes[motherIdx][j];
							chromosomes[child2Idx][j] = chromosomes[fatherIdx][j];
						}
						else{
							chromosomes[child1Idx][j] = chromosomes[fatherIdx][j];
							chromosomes[child2Idx][j] = chromosomes[motherIdx][j];
						}
					}
					int replace;
					for(j=0; j<numberOfGenes; j++){
						if(!(j>=pos1 && j<=pos2)){
							replace = p1[chromosomes[child1Idx][j]];
							if(replace != -1){
								while(p1[replace] != -1){
									replace = p1[replace];
								}
								chromosomes[child1Idx][j] = replace;
							}
							replace = p2[chromosomes[child2Idx][j]];
							if(replace != -1){
								while(p2[replace] != -1){
									replace = p2[replace];
								}
								chromosomes[child2Idx][j] = replace;
							}
						}
					}
                    break;
                case PermutationCrossover.OrderX:
					int first, second, tmp;
					
					for(i = 0; i < numberOfGenes; i++)
						p1[i] = p2[i] = 0;
					
					first = randomizer.Next(numberOfGenes);
					do{	
						second = randomizer.Next(numberOfGenes);
					} while (first==second);

					if(first > second) {
						tmp = first;
						first = second;
						second = tmp;
					}
					
				
					for(i = 0; i < numberOfGenes; i++) {
						if(i>=first&&i<=second) {
							chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
							chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
						}
						else{
							p1[chromosomes[fatherIdx][i]] = 1;
							p2[chromosomes[motherIdx][i]] = 1;
						}
					}
					
					ptr1 = ptr2 = 0;
					for(i=0; i<numberOfGenes; i++) {
						if(i<first || i >second){
							while(true){
								if(p1[chromosomes[motherIdx][ptr1]]==1){
									chromosomes[child1Idx][i] = chromosomes[motherIdx][ptr1];
									ptr1++;
									break;
								}
								ptr1++;
							}
							while(true){
								if(p2[chromosomes[fatherIdx][ptr2]]==1){
									chromosomes[child2Idx][i] = chromosomes[fatherIdx][ptr2];
									ptr2++;
									break;
								}
								ptr2++;
							}
						}
					}
					
                    break;

                case PermutationCrossover.CycleX:

					for(i=0; i<numberOfGenes; i++){
						p1[i] = p2[i] = -1;
						table1[chromosomes[fatherIdx][i]] = i;
						table2[chromosomes[motherIdx][i]] = i;
					}

					index = 0;
					p1[index] = chromosomes[motherIdx][index];
					index = table1[p1[index]];
					while(p1[index] < 0){
						p1[index] = chromosomes[motherIdx][index];
						index = table1[p1[index]];
						
					}//Constuct the cycle

					for(i=0; i<numberOfGenes; i++){
						if(p1[i]>=0){
							chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
							chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
						}
						else{
							chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
							chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
						}
					}
                    break;

                case PermutationCrossover.PositionBasedX:
					
					for(i=0; i<numberOfGenes; i++){
						p1[i] = p2[i] = 1;
						table1[i] = 1;
						table2[i] = 1;
						rand[i] = -1;
					}
					numofpositions = randomizer.Next(numberOfGenes+1);
					i = index = 0;

					while(i<numofpositions){
						temp = randomizer.Next(numberOfGenes);
						if(rand[temp]==-1){
							rand[temp] = 1;
							chromosomes[child1Idx][temp] = chromosomes[fatherIdx][temp];
							chromosomes[child2Idx][temp] = chromosomes[motherIdx][temp];
							table2[chromosomes[fatherIdx][temp]] = -1;
							table1[chromosomes[motherIdx][temp]] = -1;
						}
						else
							i--;
						i++;
					}
					
					ptr1 = ptr2 = 0;
					for(i=0; i<numberOfGenes; i++){
						if(rand[i]==-1){
							while(true){
								if(table2[chromosomes[motherIdx][ptr2]]==1){
									chromosomes[child1Idx][i] = chromosomes[motherIdx][ptr2];
									ptr2++;
									break;
								}
								ptr2++;
							}
							while(true){
								if(table1[chromosomes[fatherIdx][ptr1]]==1){
									chromosomes[child2Idx][i] = chromosomes[fatherIdx][ptr1];
									ptr1++;
									break;
								}
								ptr1++;
							}
						}
					}
					
                    break;

                case PermutationCrossover.OrderBasedX:
					ptr1 = ptr2 = 0;
					
					for(i=0; i<numberOfGenes; i++){
						temp = randomizer.Next(2);
						if(temp == 1)
							rand[chromosomes[fatherIdx][i]] = 1;
						else
							rand[chromosomes[fatherIdx][i]] = 0;
					}
					
					for(i=0; i<numberOfGenes; i++){
						if(rand[chromosomes[motherIdx][i]] == 1){
							while(true){
								if(rand[chromosomes[fatherIdx][ptr1]] == 1){
									chromosomes[child1Idx][i] = chromosomes[fatherIdx][ptr1];
									ptr1++;
									break;
								}
								ptr1++;
							}
						}
						else
							chromosomes[child1Idx][i] = chromosomes[motherIdx][i];

						if(rand[chromosomes[fatherIdx][i]] == 1){
							while(true){
								if(rand[chromosomes[motherIdx][ptr2]] == 1){
									chromosomes[child2Idx][i] = chromosomes[motherIdx][ptr2];
									ptr2++;
									break;
								}
								ptr2++;
							}
						}
						else
							chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
					}
					
                    break;
            }
        }


        //  Overriden mutation operations on permutation encoding GA
		int[] pos;
		int[] val;
		int index;
		int numofmutgene;
		public override void performMutateOperation(){
            // Perform silimar binary encoded GA mutation operation to identify number of parents
            // subject to mutation operation and the parent idices are stored in indices array

            // Set the first mutated chromosome index
            // One by one generated mutated child chromosome
			
           	numberOfMutatedChildren = SimulateMutatedGenesMarkingAndPackParentIndicesReturnBound();
			int size = populationSize + numberOfCrossoveredChildren;
			int position;
			
			int first, second, temp;
			pos = new int[numberOfGenes];
			val = new int[numberOfGenes];

			for (int i = 0; i < numberOfMutatedChildren; i++){
				
				index = size + i;
				int check = 0;
				for (int j = 0; j < numberOfGenes; j++){
					chromosomes[index][j] = chromosomes[indices[i]][j];
					check += chromosomes[index][j];
				}
				if(check != (0+numberOfGenes-1)*numberOfGenes/2)
					continue;
				switch (mutationType){
						
					case PermutationMutation.Inversion:

						first = randomizer.Next(numberOfGenes);

						do{
							second = randomizer.Next(numberOfGenes);
						}while (first == second);

						if(first > second){
							temp = first;
							first = second;
							second = temp;
						}

						for(int j=first; j<=first+(second-first)/2; j++){
							temp = chromosomes[index][j];
							chromosomes[index][j] = chromosomes[index][second-j+first];
							chromosomes[index][second-j+first] = temp;
						}

						break;
					
					case PermutationMutation.Insertion:

						first = randomizer.Next(numberOfGenes);

						do{
							second = randomizer.Next(numberOfGenes);
						}while (first == second);

						if(first > second){
							temp = first;
							first = second;
							second = temp;
						}

						for(int j=first; j < second; j++){
							temp = chromosomes[index][j];
							chromosomes[index][j] = chromosomes[index][j+1];
							chromosomes[index][j+1] = temp;
						}
						
						break;
					
					case PermutationMutation.Displacement:

						do{
							first = randomizer.Next(numberOfGenes);
							second = randomizer.Next(numberOfGenes);
						}while (first == second || Math.Abs(second - first) + 1 == numberOfGenes);

						if(first > second){
							temp = first;
							first = second;
							second = temp;
						}

						do{
							position = randomizer.Next(numberOfGenes);
						}while(position+(second-first+1)>numberOfGenes || position == first);

						for(int j=0; j<second-first+1; j++){
							temp = chromosomes[index][j+first];
							chromosomes[index][j+first] = chromosomes[index][j+position];
							chromosomes[index][j+position] = temp;
						}

						break;
					
					case PermutationMutation.ReciprocalExchange:
					
						first = randomizer.Next(numberOfGenes);
						do{
							second = randomizer.Next(numberOfGenes);
						}while(first==second);

						temp = chromosomes[index][first];
						chromosomes[index][first] = chromosomes[index][second];
						chromosomes[index][second] = temp;
						break;

					case PermutationMutation.Heuristic:
						//For OptimizationType.Min only.
						int selectlimit = numberOfGenes > 8 ? 4 : numberOfGenes/2;
						do{
							numofmutgene = randomizer.Next(numberOfGenes+1);
						}while(numofmutgene > selectlimit || numofmutgene == 0);
						
						int[] list = new int[numofmutgene];
						
						for(int j=0; j<numberOfGenes; j++){
							pos[j] = val[j] = -1;
						}
						for(int j=0; j<numofmutgene; j++){
							temp = randomizer.Next(numberOfGenes);
							if(val[chromosomes[index][temp]]==-1){
								pos[chromosomes[index][temp]] = temp;
								val[chromosomes[index][temp]] = 1;
								list[j] = chromosomes[index][temp];
							}
							else
								j--;
						}
						bestmutation = new int[numberOfGenes];
						currentmutation = new int[numberOfGenes];
						bestobj = double.MaxValue;
						Array.Sort<int>(list);
						FastPermutation(ref list,0,numofmutgene-1);
						for(int j=0; j<numberOfGenes; j++)
							chromosomes[index][j] = bestmutation[j];
						
						break;
				}
			}
        }

		double bestobj, obj;
		int[] bestmutation, currentmutation;
		private void FastPermutation(ref int[] list, int k, int m){
			int temp, ptr;
			if(k==m) {
				for(int i=0; i<numberOfGenes; i++)
					currentmutation[i] = chromosomes[index][i];

				ptr = 0;

				for(int i=0; i<numberOfGenes; i++){
					if(val[chromosomes[index][i]]!=-1){
						currentmutation[i] = list[ptr];
						ptr++;
					}
					if(ptr==numofmutgene)
						break;
				}
				obj = GetObjectiveValueFunction(currentmutation);
				
				if(obj <= bestobj){
					for(int j=0; j<numberOfGenes; j++)
						bestmutation[j] = currentmutation[j];
					bestobj = obj;
				}
			}
			else{
				for(int i= k; i<= m; i++){
					temp = list[i];
					for(int j=i; j>k; j--)
						list[j] = list[j-1];
					list[k] = temp;
					FastPermutation(ref list, k + 1, m);
					temp = list[k];
					for(int j=k; j<i; j++)
						list[j] = list[j+1];
					list[i] = temp;
				}
			}
		}
    }

    // Newly defined enumeration for flagging the types of mutations and crossover operation on permutation-encoded GA
    public enum PermutationCrossover { PartialMapX, OrderX, PositionBasedX, OrderBasedX, CycleX, SubtourX }
    public enum PermutationMutation {  Inversion, Heuristic, Insertion, Displacement, ReciprocalExchange }
}