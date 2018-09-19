#include<cstdio>
#include<cstring>
#define max 12000
#pragma warning(disable:4996)
#define inf (1<<20)
int main()
{
	int n;
	scanf("%d", &n);
	while (n--)
	{
		int a, b, c;
		scanf("%d%d%d", &a, &b, &c);
		int N = c, V = b - a;
		int v[1200], w[1200], value[max];
		//memset(value, inf, sizeof(value));
		for (int i = 0; i <= V; i++)
			value[i] = inf;
		value[0] = 0;
		for (int i = 0; i < N; i++)
			scanf("%d%d", &w[i], &v[i]);
		for (int i = 0; i < N; i++)
			for (int j = v[i]; j <= V; j++)
			{
				if (value[j - v[i]] + w[i] < value[j])
					value[j] = value[j - v[i]] + w[i];
			}
		if (value[V] == inf) puts("This is impossible.");
		else
			printf("The minimum amount of money in the piggy-bank is %d.\n", value[V]);
	}
	return 0;
}