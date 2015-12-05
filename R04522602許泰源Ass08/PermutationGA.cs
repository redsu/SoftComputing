﻿using System;
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
			get{
				return crossoverType;
			}
			set{
				crossoverType = value;
			}
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
        public override void generateAPairOfCrossoveredOffspring(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            int pos1, pos2, temp, i, j, index, numofpositions;
			int ptr1, ptr2;
			int[] table1, table2, rand;
			table1 = new int[numberOfGenes];
			table2 = new int[numberOfGenes];
			rand   = new int[numberOfGenes];
			Console.WriteLine(crossoverType.ToString());
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
						if(i<=first&&i<=second) {
							chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
							chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
						}
						else{
							p1[chromosomes[motherIdx][i]] = 1;
							p2[chromosomes[fatherIdx][i]] = 1;
						}
					}
					ptr1 = ptr2 = 0;
					if(ptr1 >= first) {
						ptr1 = ptr2 = second + 1;
					}
					for(i=0; i<numberOfGenes; i++) {
						if (p1[chromosomes[motherIdx][i]] == 1) {
							chromosomes[child1Idx][ptr1] = chromosomes[motherIdx][i];
							ptr1++;
						}
						if (p1[chromosomes[fatherIdx][i]] == 1) {
							chromosomes[child2Idx][ptr2] = chromosomes[fatherIdx][i];
							ptr2++;
						}
						if(ptr1 >= first)
							ptr1 = second+1;
						if(ptr2 >= first)
							ptr2 = second+1;
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
					/*for(i=0;i<numberOfGenes; i++)
						Console.Write(chromosomes[fatherIdx][i].ToString()+" ");
					Console.WriteLine();
					for(i=0;i<numberOfGenes; i++)
						Console.Write(chromosomes[motherIdx][i].ToString()+" ");
					Console.WriteLine("\n--------------------------------------");*/
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
					/*
					for(i=0;i<numberOfGenes; i++)
						Console.Write(rand[i].ToString()+" ");
					Console.WriteLine();
					for(i=0;i<numberOfGenes; i++)
						Console.Write(table1[i].ToString()+" ");
					Console.WriteLine();
					for(i=0;i<numberOfGenes; i++)
						Console.Write(table2[i].ToString()+" ");
					Console.WriteLine();*/
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
					/*for(i=0;i<numberOfGenes; i++)
						Console.Write(chromosomes[child1Idx][i].ToString()+" ");
					Console.WriteLine();
					for(i=0;i<numberOfGenes; i++)
						Console.Write(chromosomes[child2Idx][i].ToString()+" ");
					Console.WriteLine("\n===================================");

					*/
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
        {/*
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
            }*/
			this.numberOfMutatedChildren = base.SimulateMutatedGenesMarkingAndPackParentIndicesReturnBound();
			int num = this.populationSize + this.numberOfCrossoveredChildren;
			int num3;
			for (int i = 0; i < this.numberOfMutatedChildren; i = num3 + 1)
			{
				int num2 = num + i;
				for (int j = 0; j < this.numberOfGenes; j = num3 + 1)
				{
					this.chromosomes[num2][j] = this.chromosomes[this.indices[i]][j];
					num3 = j;
				}
				switch (this.mutationType)
				{
				case PermutationMutation.Inversion:
				{
					int num4 = this.randomizer.Next(this.numberOfGenes);
					int num5;
					do
					{
						num5 = this.randomizer.Next(this.numberOfGenes);
					}
					while (num5 == num4);
					bool flag = num4 > num5;
					if (flag)
					{
						int num6 = num4;
						num4 = num5;
						num5 = num6;
					}
					int k = num4;
					int num7 = num5;
					while (k < num7)
					{
						int num6 = this.chromosomes[num2][k];
						this.chromosomes[num2][k] = this.chromosomes[num2][num7];
						this.chromosomes[num2][num7] = num6;
						num3 = k;
						k = num3 + 1;
						num3 = num7;
						num7 = num3 - 1;
					}
					break;
				}
				case PermutationMutation.Insertion:
				{
					int num4 = this.randomizer.Next(this.numberOfGenes);
					int num5;
					do
					{
						num5 = this.randomizer.Next(this.numberOfGenes);
					}
					while (num5 == num4);
					bool flag2 = num4 > num5;
					int num6;
					if (flag2)
					{
						num6 = num4;
						num4 = num5;
						num5 = num6;
					}
					num6 = this.chromosomes[num2][num4];
					for (int k = num4; k < num5; k = num3 + 1)
					{
						this.chromosomes[num2][k] = this.chromosomes[num2][k + 1];
						num3 = k;
					}
					this.chromosomes[num2][num5] = num6;
					break;
				}
				case PermutationMutation.Displacement:
				{
					int num4;
					int num5;
					do
					{
						num4 = this.randomizer.Next(this.numberOfGenes);
						num5 = this.randomizer.Next(this.numberOfGenes);
					}
					while (num4 + num5 > this.numberOfGenes || num5 == 0 || num5 == this.numberOfGenes);
					for (int k = 0; k < num5; k = num3 + 1)
					{
						this.indices[k] = this.chromosomes[num2][num4 + k];
						num3 = k;
					}
					int num6 = num5 + num4;
					for (int k = 0; k < this.numberOfGenes - num6; k = num3 + 1)
					{
						this.chromosomes[num2][num4 + k] = this.chromosomes[num2][k + num6];
						num3 = k;
					}
					do
					{
						bool flag3 = this.numberOfGenes - num5 == 1;
						if (flag3)
						{
							bool flag4 = num4 == 0;
							if (flag4)
							{
								num6 = 1;
							}
							else
							{
								num6 = 0;
							}
						}
						else
						{
							num6 = this.randomizer.Next(this.numberOfGenes - num5);
						}
					}
					while (num6 == num4);
					for (int k = this.numberOfGenes - 1; k >= num6 + num5; k = num3 - 1)
					{
						this.chromosomes[num2][k] = this.chromosomes[num2][k - num5];
						num3 = k;
					}
					for (int k = 0; k < num5; k = num3 + 1)
					{
						this.chromosomes[num2][num6 + k] = this.indices[k];
						num3 = k;
					}
					break;
				}
				case PermutationMutation.ReciprocalExchange:
				{
					int num4;
					int num5;
					do
					{
						num4 = this.randomizer.Next(this.numberOfGenes);
						num5 = this.randomizer.Next(this.numberOfGenes);
					}
					while (num4 == num5);
					int num6 = this.chromosomes[num2][num4];
					this.chromosomes[num2][num4] = this.chromosomes[num2][num5];
					this.chromosomes[num2][num5] = num6;
					break;
				}
				}
				num3 = i;
			}
        }

    }

    // Newly defined enumeration for flagging the types of mutations and crossover operation on permutation-encoded GA
    public enum PermutationCrossover { PartialMapX, OrderX, PositionBasedX, OrderBasedX, CycleX, SubtourX }
    public enum PermutationMutation {  Inversion, Swapped, Insertion, Displacement, ReciprocalExchange }
}