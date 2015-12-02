#include<stdio.h>

int solution[30];
int fastbestsolution[30];
int count;
int arr[30][30];
char Position[30];
double bestobj = 2147483647.0;
void FastPremutation(int index){
	int i, j;
	double obj;
	for(i = 0; i < count; i++){
		if(!Position[i]){
			solution[i] = index;
			Position[i] = 1;
			if(index == count-1){
				obj = 0.0;
				for(j = 0; j < count; j++){
					obj += arr[solution[j]][j];
				}
				if(obj < bestobj){
					for(j=0; j<count; j++)
						fastbestsolution[j] = solution[j];
					bestobj = obj;
				}
			}
			else
				FastPremutation(index+1);
			Position[i] = 0;
		}
	}
}

int main(){
	int n;
	int i, j;

	FILE *fin;
	fin = fopen("Jobs10.aop", "r+");

	fscanf(fin, "%d", &n);
	count = n;
	for(i=0; i<n; i++)
		for(j=0; j<n; j++)
			fscanf(fin, "%d", &arr[i][j]);

	for(i=0; i<n; i++)
		Position[30] = 0;

	return 0;
}
