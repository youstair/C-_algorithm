// Acm测试.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)
/*
created by youstair
	github address:https://github.com/youstair
*/

/*
题目描述
zcb喜欢滑雪。他来到了一个滑雪场，这个滑雪场是一个矩形，为了简便，我们用r行c列的矩阵来表示每块地形。为了得到更快的速度，滑行的路线必须向下倾斜。 例如样例中的那个矩形，可以从某个点滑向上下左右四个相邻的点之一。例如24-17-16-1，其实25-24-23…3-2-1更长，事实上这是最长的一条。

输入
第1行:两个数字r，c(1 ≤ r, c ≤ 100)，表示矩阵的行列。第2..r+1行:每行c个数，表示这个矩阵。

输出
仅一行:输出1个整数，表示可以滑行的最大长度。

样例输入
5 5
1 2 3 4 5
16 17 18 19 6
15 24 25 20 7
14 23 22 21 8
13 12 11 10 9
样例输出
25
*/
#include<bits/stdc++.h>
using namespace std;
struct ss
{
	int height;
	int x, y;
};
bool cmp(ss a, ss b)
{
	return a.height < b.height;
}
int abss(int a, int b)
{
	if (a - b >= 0) return a - b;
	return b - a;
}
bool Near(ss a, ss b)
{
	if ((a.x == b.x&&abss(a.y, b.y) == 1) || (a.y == b.y&&abss(a.x, b.x) == 1))
		return true;
	return false;
}
int Max(int a, int b)
{
	if (a >=b) return a;
	return b;
}
int r,c;
ss liner[11000];
int dp[11000];
int main()
{
	while (cin >> r >> c)
	{
		int num = 0,max=-1;
		for(int i=0;i<r;i++)
			for (int j = 0; j < c; j++)
			{
				int p;
				cin >> p;
				liner[num].height = p;
				liner[num].x = i;
				liner[num].y = j;
				num++;
			}
		sort(liner,liner+num, cmp);
		for (int i = 0; i < num; i++)
		{
			dp[i] = 1;
			for (int j = 0; j < i; j++)
			{
				if (Near(liner[i], liner[j]))
				{
					dp[i] = Max(dp[i],dp[j]+1);
				}
			}
			if (dp[i] > max) max = dp[i];
		}
		cout << max<< endl;
	}
	return 0;
}