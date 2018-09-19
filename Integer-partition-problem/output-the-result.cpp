#include"stdafx.h"
#include<cstdio>
int n,mark[256];
void display(int sum, int k, int pro)
{
	if (sum > n) return;
	if (sum < n)
	{
		//printf("%d=",n);
		for (int i = pro; i >= 1; i--)
		{
			mark[k] = i;
			display(sum + i, k + 1, i);
		}
	}
	else if (sum == n)
	{
		printf("%d=",n);
		for (int i = 0; i < k - 1; i++)
			printf("%d+", mark[i]);
		printf("%d\n", mark[k - 1]);
	}
}
int main()
{
	while (scanf_s("%d", &n))
	{
		//printf("%d=%d\n",n,n);
		display(0, 0, n);
	}
	return 0;
}