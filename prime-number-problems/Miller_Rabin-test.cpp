#include"stdafx.h"
#include<cstdio>
#define LL long long
 //18λ������154590409516822759
 //19λ������2305843009213693951 (÷ɭ����)
 //19λ������4384957924686954497
LL prime[6] = { 2, 3, 5, 233, 331 };
LL qmul(LL x, LL y, LL mod) { // �˷���ֹ����� ���p * p����LL�Ļ�����ֱ�ӳˣ� O(1)�˷�����ת���ɶ����Ƽӷ�
	return (x * y - (long long)(x / (long double)mod * y + 1e-3) *mod + mod) % mod;
	/*
	LL ret = 0;
	while(y) {
	if(y & 1)
	ret = (ret + x) % mod;
	x = x * 2 % mod;
	y >>= 1;
	}
	return ret;
	*/
}
LL qpow(LL a, LL n, LL mod) {
	LL ret = 1;
	while (n) {
		if (n & 1) ret = qmul(ret, a, mod);
		a = qmul(a, a, mod);
		n >>= 1;
	}
	return ret;
}
bool Miller_Rabin(LL p) {
	if (p < 2) return 0;
	if (p != 2 && p % 2 == 0) return 0;
	LL s = p - 1;
	while (!(s & 1)) s >>= 1;
	for (int i = 0; i < 5; ++i) {
		if (p == prime[i]) return 1;
		LL t = s, m = qpow(prime[i], s, p);
		while (t != p - 1 && m != 1 && m != p - 1) 
		{
			m = qmul(m, m, p);
			t <<= 1;
		}
		if (m != p - 1 && !(t & 1)) return 0;
	}
	return 1;
}
int main()
{
	LL a;
	while (scanf_s("%lld", &a))
	{
		if (Miller_Rabin(a)) puts("1");
		else puts("0");
	}
	return 0;
}
//#include<cstdio>
//int main()
//{
//	printf("%lf\n", 1e9+7);
//	return 0;
//}