#include<cstdio>
#include<cstring>
#define ll long long
#pragma warning(disable:4996)
#define N 50005
int a[N], c[N] = {0}, n;
int lowbit(int x)
{
	return x & -x;
}
void change(int x, int p)
{
	while (x <= n)
	{
		c[x] += p;
		x += lowbit(x);
	}
}
ll sum(int x)
{
	ll ans = 0;
	while (x > 0)
	{
		ans += c[x];
		x -= lowbit(x);
	}
	return ans;
}
ll query(int a, int b)
{
	return sum(b) - sum(a-1);
}
int main()
{
	int t,r=1;
	scanf("%d", &t);
	while (r<=t)
	{
		memset(c, 0, sizeof(c));
		printf("Case %d:\n", r++);
		scanf("%d", &n);
		for (int i = 1; i <= n; i++)
		{
			scanf("%d", &a[i]);
			change(i, a[i]);
		}
		char ch[10];
		while (scanf("%s", ch), ch[0] != 'E')
		{
			int a, b;
			scanf("%d%d", &a, &b);
			if (ch[0] == 'Q') printf("%lld\n", query(a, b));
			else if (ch[0] == 'A') change(a, b);
			else if (ch[0] == 'S') change(a, -b);
		}
	}
	return 0;
}