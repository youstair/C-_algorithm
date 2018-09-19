#include<cstdio>
#pragma warning(disable:4996)
#define N 2000
int a[N][N],v[N],n;
void dfs(int s)
{
	if (v[s] != -1)
	{
		printf("%d ", s);
		v[s] = -1;
		for (int i = 1; i <= n; i++)
		{
			if (a[s][i] != 0 && v[i] != -1)
				dfs(i);
		}
	}
		
}
int main()
{
	while (scanf("%d", &n), n)
	{
		for (int i = 1; i <= n; i++)
			v[i] = i;
		for(int i=1;i<=n;i++)
			for (int j = 1; j <= n; j++)
			{
				scanf("%d", &a[i][j]);
			}
		int s;
		while (scanf("%d", &s), s)
		{
			for (int i = 1; i <= n; i++)
				v[i] = i;
			dfs(s);
			puts("");
		}
	}
	return 0;
}
/*
ÎÞÏòÍ¼
0 1 0 1 0
1 0 0 0 1
0 0 0 0 1
1 0 0 0 1
0 1 1 1 0
*/