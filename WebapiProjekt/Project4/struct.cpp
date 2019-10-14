#include <stdio.h>
#include <stdlib.h>
#define size 25
#include "struct.h"


int main()
{
	struct personale mads; // kalder structen fra vores header.
	struct personale emma; // når vi intialiserer structen giver vi den et navn.

	mads.brugerid_ = 1;  // vi bruget tegnet "." dot til at tilgå hvertenkelt medlem af vores struct
	emma.brugerid_ = 2;

	puts("enter dit navn, mads");// skriver teksten med rød
	gets_s(mads.navn_); //tager bruger indputtet for mads og lægger det over i navn_ i vores struct
	puts("enter dit navn, emma");
	gets_s(emma.navn_); // husk vi bruges dot til at tilgå vores struct

	printf("bruger 1 id er %d\n", mads.brugerid_); // udskriver id for bruger 1

	return 0;
}