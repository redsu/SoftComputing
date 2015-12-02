// vim: ts=4 sw=4 et
#include<stdio.h>
#include<time.h>
int solution[30];
int fastbestsolution[30];
int count;
double arr[30][30];
char Position[30];
int position = 0;
double bestobj = 2147483647.0;

struct stack{
    int index;
    int position;
    int solution[30];
};

void FastPremutation(){
    
	int i, j, index = 0;
	double obj;
    int ptr = 0;
    struct stack stk[1000];

    stk[ptr].index = 0;
    stk[ptr].position = 0;

    while(ptr>=0){
        index = stk[ptr].index;
        position = stk[ptr].position;
        for(j=0;j<count;j++)
            solution[j] = stk[ptr].solution[j];
	    for(i = 0; i < count; i++){
		    if((position>>i)%2==0){
		    	for(j=0;j<count;j++)
                    stk[ptr].solution[j] = solution[j];
                stk[ptr].solution[i] = index;

		    	stk[ptr].position = position|(1<<i);
                stk[ptr].index = index+1;


		    	if(index == count-1){
		    		obj = 0.0;
		    		for(j = 0; j < count; j++){
		    			obj += arr[stk[ptr].solution[j]][j];
		    		}
					
					/*for(j=0; j<count; j++)
		    			printf("%d ", stk[ptr].solution[j]);
					printf("\n");
					*/
		    		if(obj < bestobj){
		    			for(j=0; j<count; j++)
		    				fastbestsolution[j] = stk[ptr].solution[j];
		    			bestobj = obj;
		    		}
                    ptr--;
		    	}
                ptr++;
	    	}
	    }
        ptr--;
    }
}

int main(int argc, char* argv[]){
	int n;
	int i, j;
	clock_t t1, t2;
	FILE *fin, *fout;
	fin = fopen(argv[1], "r");
	fout = fopen("Ans.txt", "w+");
	fscanf(fin, "%d", &n);
	count = n;
	for(i=0; i<n; i++){
		for(j=0; j<n; j++){
			fscanf(fin, "%lf", &arr[i][j]);
			//printf("%lf ", arr[i][j]);
		}
		//printf("\n");
	}

	for(i=0; i<n; i++)
		Position[30] = 0;

	t1 = clock();
	FastPremutation();
	t2 = clock();
	//printf("Best : %lf\n", bestobj);
	//for(i=0; i<n; i++)
	//	printf("%d ",fastbestsolution[i]);
//	printf("\n");
	
	//printf("\n%lf\n", (t2-t1)/(double)(CLOCKS_PER_SEC));
	fprintf(fout, "%lf\n", bestobj);
	for(i=0; i<n; i++)
		fprintf(fout, "%d ", fastbestsolution[i]);
	fprintf(fout, "\n%lf\n", (t2-t1)/(double)(CLOCKS_PER_SEC));
	fclose(fin);
	fclose(fout);
	return 0;
}
