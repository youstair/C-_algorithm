#include"stdafx.h"
#include<cstdio>
int qpow(int a, int b)
{
	int sum = 1, base = a;
	while (b)
	{
		if (b & 1) sum *= base;
		base *= base;
		b >>= 1;
	}
	return sum;
}
int main()
{
	int a, b;
	while (scanf_s("%d%d", &a, &b))
	{
		printf("%d\n", qpow(a, b));
	}
	return 0;
}