#define NTHREADS 10
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>  //Header file for sleep(). man 3 sleep for details.
#include <pthread.h>


int main(){
	pthread_t threads[NTHREADS];
	for(i=0; i< NTHREADS; i++ ){
		pthread_create(&threads[i], &go, i);
	}for(i = 0; i < NTHREADS; i++){
		exitValue = pthread_join(threads[i]);
		printf("Thread %d returned with %d\n", i, exitValue);
	}
	printf("Main thread done.\n");
}

void go(int n){
	printf("Hello from thread %d\n",n);
	pthread_exit(100+n);
}