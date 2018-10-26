#include<cstdio>
#include<cstring>
#define N 1200
int m, n;
int w[N], v[N], value[N];
int main()
{
	int t;
	scanf("%d", &t);
	while (t--)
	{
		scanf("%d%d", &n, &m);
		for (int i = 0; i < n; i++)
			scanf("%d", &w[i]);
		for (int i = 0; i < n; i++)
			scanf("%d", &v[i]);
		memset(value, 0, sizeof(value));
		for (int i = 0; i < n; i++)
			for (int j = m; j >= v[i]; j--)
				if (value[j - v[i]] + w[i] > value[j])
					value[j] = value[j - v[i]] + w[i];
		printf("%d\n", value[m]);
	}
	return 0;
}