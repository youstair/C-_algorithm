#include<cstdio>
#include<queue>
#include<iostream>
using namespace std;
#pragma warning(disable:4996)
#define N 2000
int g[N][N],v[N],n;
queue<int>st;//STL是C++的特性
void bfs(int s)
{
	st.push(s);
	for (int i = 1; i <= n; i++)
		if (v[i] != -1 && g[s][i] != 0) st.push(i);
	while (!st.empty())
	{
		int p = st.front();
		if (v[p] != -1)
		{
			v[p] = -1;
			printf("%d ", p);
		}
		for (int i = 1; i <= n; i++)
			if (g[p][i] && v[i] != -1) st.push(i);
		st.pop();
	}
}
int main()
{
	scanf("%d", &n);
	for (int i = 1; i <= n; i++)
		for (int j = 1; j <= n; j++)
			scanf("%d", &g[i][j]);
	int s;
	while (scanf("%d", &s), s)
	{
		for (int i = 1; i <= n; i++)
			v[i] = i;
		bfs(s);
		puts("");
	}
	return 0;
}
/*
无向图
0 1 0 1 0
1 0 0 0 1
0 0 0 0 1
1 0 0 0 1
0 1 1 1 0
*/