#include "stdafx.h"
#pragma warning(disable:4996)
#include<bits/stdc++.h>
using namespace std;
struct ss
{
	int a[100];
	int len = 0;
};
bool equal(ss a, ss b)
{
	if (a.len != b.len) return false;
	bool judge = false;
	for (int i = 0; i < a.len; i++)
	{
		bool flag = true;
		for (int j = 0; j < a.len; j++)
		{
			if (a.a[i] == b.a[j]) flag = false;
		}
		if (flag)
		{
			judge = true;
			break;
		}
	}
	if (judge) return false;
	return true;
}
ss s[100];
int slen = 0;
int n;
int st[100][100];//默认插入元素为2个，a,b
queue<int>Q;
//集合是否重复
bool find1(ss a)
{
	int len = a.len;
	bool flag = false;
	for (int i = 0; i < slen; i++)
	{
		if (equal(a, s[i]))
		{
			flag = true;
			break;
		}
	}
	if (flag) return true;
	return false;
}
//元素是否重复
bool find2(ss a, int x)
{
	for (int i = 0; i < a.len; i++)
		if (x == a.a[i]) return true;
	return false;
}
//产生初始状态
void insert1(ss &temp, int path)
{
	for (int i = 0; i < temp.len; i++)
	{
		bool fg = false;
		for (int j = 0; j < n; j++)
		{
			if (st[temp.a[i]][j] == path && (!find2(temp, j)))
			{
				temp.a[temp.len] = j;
				temp.len++;
				fg = true;
			}
		}
		if (fg) i = -1;
	}


	for (int i = 0; i < temp.len; i++)
	{
		bool fg = false;
		for (int j = 0; j < n; j++)
		{
			if (st[temp.a[i]][j] == 0 && (!find2(temp, j)))
			{
				temp.a[temp.len] = j;
				temp.len++;
				fg = true;
			}
		}
		if (fg) i = -1;
	}


}
//复制ss对象
void duplicate(ss &a, ss b)
{
	a.len = b.len;
	for (int i = 0; i < b.len; i++)
		a.a[i] = b.a[i];
}
//插入新的集合
void insert2(ss temp)
{
	if (!find1(temp))
	{
		duplicate(s[slen], temp);
		slen++;
	}
}
//根据输入流产生下一状态
void insert3(ss s1, ss &s2, int path)
{
	for (int i = 0; i < s1.len; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (st[s1.a[i]][j] == path && (!find2(s2, j)))
			{
				s2.a[s2.len] = j;
				s2.len++;
				insert1(s2, path);
				return;
			}
		}
	}
}
int main()
{
	while (cin >> n)
	{
		slen = 0;
		for (int i = 0; i<n; i++)
			for (int j = 0; j < n; j++)
			{
				cin >> st[i][j];
			}
		for (int p = 0; p < n; p++)//测试st数组
		{
			for (int t = 0; t < n; t++)
				cout << st[p][t] << ' ';
			puts("");
		}
		puts("");
		s[0].a[0] = 0;
		s[0].len++;
		insert1(s[0], 0);

		while (!Q.empty()) Q.pop();
		Q.push(slen);
		slen++;
		while (!Q.empty())
		{
			ss temp1;
			duplicate(temp1, s[Q.front()]);
			for (int i = 1; i <= 2; i++)
			{
				ss temp0;
				insert3(temp1, temp0, i);
				if (!find1(temp0))
				{
					insert2(temp0);
					Q.push(slen - 1);
				}
			}
			Q.pop();
		}
		cout << slen << endl;
		for (int i = 0; i < slen; i++)
		{
			for (int j = 0; j < s[i].len; j++)
				cout << s[i].a[j] << ' ';
			cout << endl;
		}
	}
	return 0;
}
/*
input_test
4
-1 0 1 -1
-1 -1 -1 0
-1 2 -1 -1
-1 -1 0 -1

input_out
0 1 3 2
2
1 3 2
*/
