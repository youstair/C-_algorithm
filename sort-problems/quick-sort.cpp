#include<iostream>
using namespace std;
int a[100];
void Qsort(int l, int r)
{
	if (l > r) return;
	int tmp = a[l];
	int i = l;
	int j = r;
	while (i<j)
	{
		while (a[j] >= tmp && i < j)
			j--;
		while (a[i] <= tmp && i < j)
			i++;
		if (i < j)
		{
			int r = a[j];
			a[j] = a[i];
			a[i] = r;
		}
	}
	a[l] = a[i];
	a[i] = tmp;
	Qsort(l, i - 1);
	Qsort(i + 1, r);
}
int main()
{
	int n;
	cin >> n;
	for (int i = 0; i < n; i++)
		cin >> a[i];
	Qsort(0, n - 1);
	for (int i = 0; i < n ; i++)
		cout << a[i] << ' ';
	puts("");
	return 0;
}