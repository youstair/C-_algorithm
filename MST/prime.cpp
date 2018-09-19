#include<cstdio>
#include<queue>
#include<iostream>
#include<cstring>
#include<algorithm>
using namespace std;
#pragma warning(disable:4996)
#define N 2000
#define max (1<<20)
int g[N][N], v[N], n, f[N],dist[N];
int prime(int x)
{
	int sum = 0;
	for (int i = 1; i <= n; i++)
		dist[i] = g[x][i];
	v[x] = 0;
	for (int i = 2; i <= n; i++)
	{
		int inf = max,index;
		for(int j=1;j<=n;j++)
			if (v[j] && dist[j] < inf&&dist[j])
			{
				inf = dist[j];
				index = j;
			}
		v[index] = 0, sum += inf;
		for (int s = 1; s <= n; s++)
		{
			if (v[s] && g[index][s] && dist[s] > g[index][s])
				dist[s] = g[index][s];
		}
	}
	return sum;
}
void init()
{
	memset(v, 1, sizeof(v));
	memset(dist, -1, sizeof(dist));
}
int main()
{
	scanf("%d", &n);
	for(int i=1;i<=n;i++)
		for (int j = 1; j <= n; j++)
		{
			scanf("%d", &g[i][j]);
			if (i != j && g[i][j] == 0)
				g[i][j] = max;
		}
	int y;
	while (scanf("%d", &y), y)
	{
		init();
		printf("%d\n", prime(y));
	}
	return 0;
}
/*
ÎÞÏòÍ¼//14
0 6 1 5 0
6 0 5 0 3
1 5 0 5 6
5 0 5 0 0
0 3 6 0 0
*/