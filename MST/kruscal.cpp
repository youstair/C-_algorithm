#include<cstdio>
#include<queue>
#include<iostream>
#include<cstring>
#include<algorithm>
using namespace std;
#pragma warning(disable:4996)
#define N 2000
#define max (1<<20)
int g[N][N], v[N], n, f[N];
struct ss
{
	int s, e, w;
};
ss s[N];
int p = 0;
bool cmp(ss a, ss b)
{
	return a.w < b.w;
}
int find(int x)
{
	if (x != f[x])
		f[x] = find(f[x]);
	return f[x];
}
int kruskal(int x)
{
	int z = 0,sum=0;
	sort(s,s+p, cmp);
	for (int i = 0; i < p; i++)
	{
		int fx =find( s[i].s);
		int fy = find(s[i].e);
		if (fx != fy)
		{
			f[fy] = f[fx];
			sum += s[i].w;
			v[z] = s[i].w;
			z++;
		}
		if (z == n - 1) return sum;
	}
}
void init()
{
	for (int i = 1; i <= n; i++)
		f[i] = i;
	p = 0;
	memset(v, -1, sizeof(v));
}
int main()
{
	scanf("%d", &n);
	init();
	for(int i=1;i<=n;i++)
		for (int j = 1; j <= n; j++)
		{
			scanf("%d", &g[i][j]);
			if (i != j && g[i][j] == 0) g[i][j]=g[j][i] = max;
			if (g[i][j] != 0)
			{
				s[p].s = i, s[p].e = j,s[p].w=g[i][j];
				p++;
			}
		}
	int y;
	while (scanf("%d", &y),y)
	{
		for (int i = 1; i <= n; i++)
			f[i] = i;
		printf("%d\n", kruskal(y));
		for (int i = 0; v[i] != -1; i++)
			printf("%d ", v[i]);
		puts("");
	}
	return 0;
}
/*
ÎÞÏòÍ¼
0 6 1 5 0
6 0 5 0 3
1 5 0 5 6//14
5 0 5 0 0
0 3 6 0 0
*/