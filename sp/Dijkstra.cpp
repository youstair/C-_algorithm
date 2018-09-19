#include<cstdio>
#include<queue>
#include<iostream>
#include<cstring>
#include<algorithm>
using namespace std;
#pragma warning(disable:4996)
#define N 2000
#define max (1<<20)
int g[N][N], v[N], n, path[N],dist[N];
void dijastra(int x)
{
	v[x] = 0;
	for (int i = 1; i <= n; i++)
	{
		//if (v[i])
		{
			path[i] = g[x][i];
		}
	}
	for (int s = 2; s <= n; s++)
	{
		int inf = max, k;
		for (int i = 1; i <= n; i++)
			if (v[i] && path[i] < inf)
			{
				inf = path[i];
				k = i;
			}
		v[k] = 0; 
		for (int i = 1; i <= n; i++)
		{
			if (v[i] && path[i] > path[k] + g[k][i])
			{
				path[i] = path[k] + g[k][i];
			}
		}
	}
}
void init()
{
	memset(v, 1, sizeof(v));
	memset(dist, -1, sizeof(dist));
	memset(path, -1, sizeof(path));
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
		dijastra(y);
		for (int i = 1; i <= n; i++)
			if (y != i) printf("%d->%d: %d\n", y, i, path[i]);
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