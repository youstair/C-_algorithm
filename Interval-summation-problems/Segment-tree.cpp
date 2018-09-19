// C++.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)
#include<cstdio>
#define N 50000+5
#define ll long long
struct ss
{
	int l, r, w;
};
ss tree[N * 4];
void build(int root,int a,int b)
{
	tree[root].l = a, tree[root].r = b;
	if (a==b)
	{
		scanf("%d", &tree[root].w);
		return;
	}
	int mid = (a+b) / 2;
	build(2 * root,a,mid);
	build(2 * root + 1,mid+1,b);
	tree[root].w = tree[2 * root].w + tree[2 * root + 1].w;
}
void changeOne(int root,int t,int k)
{
	int l = tree[root].l, r = tree[root].r;
	if (l == r && r == t)
	{
		tree[root].w += k;
		return;
	}
	int mid = (l + r) / 2;
	if (t <= mid) changeOne(root * 2, t, k);
	else changeOne(root * 2 + 1, t, k);
	tree[root].w = tree[root * 2].w + tree[root * 2 + 1].w;
}
ll ans = 0;
void sum(int a, int b, int root)
{
	int l = tree[root].l, r = tree[root].r;
	int mid = (l + r) / 2;
	if (a <= l && b >= r)
	{
		ans += tree[root].w;
		return ;
	}
	if (a <= mid && b > mid)
	{
		sum(a, mid,root*2);
		sum(mid + 1,b,root*2+1);
		return;
	}
	if (b <= mid)
	{
		sum(a, b, root * 2);
		return;
	}
	if (a > mid)
	{
		sum(a, b, root * 2 + 1);
		return;
	}
}
int main()
{
	int n,t,z=1;
	scanf("%d", &t);
	while (t--)
	{
		while (scanf("%d", &n))
		{
			build(1, 1, n);
			char s[10];
			while (scanf("%s", s), s[0] != 'E')
			{
				int x, y;
				scanf("%d%d", &x, &y);
				if (s[0] == 'A') changeOne(1, x, y);
				else if (s[0] == 'S') changeOne(1, x, -y);
				else if (s[0] == 'Q')
				{
					ans = 0;
					sum(x, y, 1);
					//printf("result= %lld\n", ans);
					printf("Case %d:\n%lld\n", z++, ans);
				}
			}
		}
	}
	return 0;
}
