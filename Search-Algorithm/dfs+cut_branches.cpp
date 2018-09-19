#include<cstdio>
#include<iostream>
#include<cmath>
using namespace std;
int sx, sy, ex, ey;
const int sp[4][2] = { { 0,1 },{ 1,0 },{0,-1 },{ -1,0 } };
char ch[6][6];
int flag=0;
int n, m, t;
bool visit[6][6];
int path(int x,int y)
{
	return abs((double)x - ex) + abs((double)y - ey); 
}
void dfs(int cx,int cy,int cstep)
{
	if (flag) return;
	if (ch[cx][cy] == 'D'&&cstep == t)
	{
		flag = 1;
		return;
	}
	if (cstep >=t) return;
	int dis =t- (path(cx, cy)+cstep);
	if (dis < 0 || dis & 1) return;
	for (int i = 0; i < 4; i++)
	{
		int tx=cx+sp[i][0];
		int ty=cy+sp[i][1];
		int tstep=cstep+1;
		if (tx>=0&&ty>=0&&tx<n&&ty<m&&ch[tx][ty]!='X'&&!visit[tx][ty])
		{
			visit[tx][ty] = true;
			dfs(tx, ty, tstep);
			visit[tx][ty] = false;
		}
	}
}
int main()
{
	//while (~scanf("%d%d%d", &n, &m, &t))
	while(cin>>n>>m>>t,n+m+t)
	{
		int cnt = 0;
		flag = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				//scanf("%c", &ch[i][j]);
				cin >> ch[i][j];
				visit[i][j] = false;
				if (ch[i][j] == 'S') 
				{
					sx = i, sy = j;
					visit[i][j] = true;
				}
				else if (ch[i][j] == 'D') ex = i, ey = j;
				else if (ch[i][j] == 'X') cnt++;
			}
		}
		if(n*m-cnt>t) dfs(sx, sy, 0);
		if (flag==1) puts("YES");
		else puts("NO");
	}
	return 0;
}
/*
4 4 5
S.X.
..X.
..XD
....

//NO
3 4 5
S.X.
..X.
...D

//YES
0 0 0

*/