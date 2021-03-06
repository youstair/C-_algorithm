// Acm测试.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)

/*
created by youstair
	github address:https://github.com/youstair
*/

/*
对于有k=(1<<n) 个人的循环日程，设计一个比赛日程表，满足
1.每个选手必须与其他k-1个选手各比赛一次
2.每个选手一天只能比赛一场
3.循环赛一共进行k-1天


对于输入 2次幂矩阵的阶 得到比赛日程表
*/
#include<bits/stdc++.h>
using namespace std;
int s[100][100];
int n;
void tb()
{
	int p = 1;
	p <<= (n);
	for (int i = 1; i <= p; i++) s[1][i] = i;
	int m = 1;
	for (int t = 1; t <= n; t++)
	{
		p >>= 1;
		for(int w=1;w<=p;w++)
			for(int i=m+1;i<=2*m;i++)
				for (int j = m + 1; j <= 2 * m; j++)
				{
					s[i][j + (w - 1)*m * 2] = s[i - m][j + (w - 1)*m * 2 - m];
					s[i][j + (w - 1)*m * 2 - m] = s[i - m][j + (w - 1)*m * 2];
				}
		m <<= 1;

	}
}
int main()
{
	while (~scanf("%d", &n))
	{
		tb();
		for (int i = 1; i <= (1 << n); i++)
		{
			for (int j = 1; j <= (1 << n); j++)
				printf("%d ", s[i][j]);
			puts("");
		}

	}
	return 0;
}
/*
test input:
3
test output:
1 2 3 4 5 6 7 8
2 1 4 3 6 5 8 7
3 4 1 2 7 8 5 6
4 3 2 1 8 7 6 5
5 6 7 8 1 2 3 4
6 5 8 7 2 1 4 3
7 8 5 6 3 4 1 2
8 7 6 5 4 3 2 1
*/