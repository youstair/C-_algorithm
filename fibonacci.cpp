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
int fib[100];
void fibonacci()
{
	fib[0] = 1;
	fib[1] = 1;
	for (int i = 2; i < 100; i++)
		fib[i] = fib[i - 1] + fib[i - 2];

}
int find_(int i)
{
	return fib[i];
}
int main()
{
	fibonacci();
	int i;
	while (cin >> i)
	{
		cout << find_(i) << endl;
	}

	return 0;
}