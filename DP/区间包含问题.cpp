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
已知 n 个左闭右开区间 [a,b)，对其进行 m 次询问，求区间[l,r]最多可以包含 n 个区间中的多少个区间，并且被包含的所有区间都不相交。
输入
输入包含多组测试数据，对于每组测试数据：
第一行包含两个整数 n ,m (1≤n≤100000,1≤m≤100) 。
接下来 n 行每行包含两个整数 a ,b (0≤a<b≤10^9) 。
接下来 m 行每行包含两个整数 l ,r (0≤l<r≤10^9)  。
输出
对于每组测试数据，输出 m 行，每行包含一个整数。
样例输入
4 3
1 3
2 4
1 4
1 2
1 2
1 3
1 4
样例输出
1
1
2
*/


#include<bits/stdc++.h>
#define N 100000+10
using namespace std;
using namespace std;

typedef struct node
{
	int l;
	int r;
}node;
bool cmp(node a, node b)
{
	return a.r < b.r;
}

int main()
{
	std::ios::sync_with_stdio(false);
	int n, m;
	while (cin >> n >> m)
	{
		node *nnum = new node[n];
		node *mnum = new node[m];
		for (int i = 0; i < n; i++)
		{
			cin >> nnum[i].l >> nnum[i].r;
		}
		for (int i = 0; i < m; i++)
		{
			cin >> mnum[i].l >> mnum[i].r;
		}
		sort(nnum, nnum + n, cmp);
		for (int i = 0; i < m; i++)
		{
			int res = 0;
			int k = mnum[i].l; 
			for (int j = 0; j < n; j++)
			{
				if ((nnum[j].l >= k))
				{
					if (nnum[j].r <= mnum[i].r)
					{
						res++;
						k = nnum[j].r; 
					}
					else 
					{
						break;
					}
				}
			}
			cout << res << endl;
		}
		delete[] nnum;
		delete[] mnum;
	}
	return 0;
}