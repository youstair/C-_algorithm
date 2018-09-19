#include<cstdio>
#include<queue>
#include<iostream>
#include<cstring>
#include<algorithm>
using namespace std;
#pragma warning(disable:4996)
#define N 2000
#define max (1<<20)
int g[N][N], v[N], n, path[N][N],dist[N];
void floyd()
{
	for(int i=1;i<=n;i++)
		for(int j=1;j<=n;j++)
			for (int s = 1; s <= n; s++)
			{
				if (i!=j&&g[i][s] + g[s][j] < g[i][j])
					g[i][j] = g[i][s] + g[s][j];
			}
}
void floyd0()
{
	for (int k = 1; k <= n; k++) 
	{ //作为循环中间点的k必须放在最外一层循环 
		for (int i = 1; i <=n; i++) 
		{
			for (int j = 1; j <=n; j++) 
			{
				if (g[i][j] > g[i][k] + g[k][j]) 
				{
					g[i][j] = g[i][k] + g[k][j];    //dist[i][j]得出的是i到j的最短路径 
				}
			}
		}
	}
}
void init()
{
	for (int i = 1; i <= n; i++)
		for (int j = 1; j <= n; j++)
			g[i][j] = path[i][j];
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
			path[i][j] = g[i][j];
		}
	int x,y;
	while (scanf("%d%d",&x, &y),x, y)
	{
		init();
		floyd();
		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= n; j++)
				printf("%d ", g[i][j]);
			puts("");
		}
		puts("\n_______________________________\n");
		init();
		floyd0();
		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= n; j++)
				printf("%d ", g[i][j]);
			puts("");
		}
		//printf("%d->%d= %d\n", x, y, g[x][y]);
	}
	return 0;
}
/*
无向图//14
0 6 1 5 0
6 0 5 0 3
1 5 0 5 6
5 0 5 0 0
0 3 6 0 0
*/