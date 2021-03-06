// Acm测试.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)

/*
created by youstair
github address:https://github.com/youstair
    about:
	permutation problem
*/
#include<bits/stdc++.h>
using namespace std;
int lt[100];
int n;
void exchange(int &a, int &b)
{
	int c = a;
	a = b;
	b = c;
}
void perm(int k, int m)
{
	if (k == m)
	{
		for (int i = 1; i <=m; i++)
			printf("%d ", lt[i]);
		puts("");
	}
	else
	{
		for (int i = k; i <=m; i++)
		{
			exchange(lt[k], lt[i]);
			perm(k + 1,m);
			exchange(lt[k], lt[i]);
		}
	}
}
int main()
{
	while (~scanf("%d", &n))
	{
		for (int i = 1; i <= n; i++)
			scanf("%d", &lt[i]);
		perm(1, n);
	}
	return 0;
}