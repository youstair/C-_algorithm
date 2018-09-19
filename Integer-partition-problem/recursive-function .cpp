#include<cstdio>
int f(int n, int m)
{
	if (m == 1 || n == 1) return 1;
	if (m > n) return f(n, n);
	if (m == n) return 1 + f(n, n - 1);
	if (n > m) return f(n - m, m) + f(n, m - 1);
}
int main()
{
	int n, m;
	while (scanf_s("%d%d", &n, &m))
		printf("%d\n", f(n, m));
	return 0;
}