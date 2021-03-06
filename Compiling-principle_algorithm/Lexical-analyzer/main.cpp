// Acm测试.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)

/*
created by youstair
	github address:https://github.com/youstair
*/
#include<bits/stdc++.h>
using namespace std;
char prog[1000], ch, token[8];
//文件名
char filename[30];
//文件操作指针
FILE *fpin;
int p = 0, sym = 0,n, line = 1;//p数组下标，sym词法标记，line行号


//  参考课后附录 char *keyword[8]={ "if","then","else","end","repeat","until","read","write" };
//vs 提示 const char 不能用于初始化char*，改用comst char* 型数据

//保留字数组
const char *keyword[8] = { "if","then","else","end","repeat","until","read","write" };

/*
字符种类如下表：
字母    if      then    else    end     repeat  until   read    write
1       3       4       5       6       7       8       9       10
数字		+		-		*		/		=		<		;
11      13      14      15      16      17      18      19


其余sym对应情况：
-2: error处理
-1：空格 换行 制表 花括号
*/




void GetToken()
{
	for (n = 0; n<8; n++)
	{
		token[n] = '\0';
	}
	n = 0;
	ch = prog[p++];
	while (ch == ' '|| ch == '\t')
	{
		/*if (ch == '\n')
			cout << "\n第" << line++ << "行：";*/
		ch = prog[p++];
		sym = -1;
	}
	if ((ch >= 'a'&&ch <= 'z') || (ch >= 'A'&&ch <= 'Z'))
	{
		sym = 1;
		do
		{
			token[n++] = ch;
			ch = prog[p++];
		} while ((ch >= 'a'&&ch <= 'z') || (ch >= 'A'&&ch <= 'Z'));
		//sym = 2;
		for (n = 0; n<8; n++)
		{
			if (strcmp(token, keyword[n]) == 0)
			{
				sym = n + 3;
			}
		}
		p--;
		//return;
	}
	else if (ch == '{')
	{
		do {
			ch = prog[p++];
		} while (ch != '}');
		sym = -1;
		return;
	}
	else if (ch == '\n')
	{
		line++;
	}
	else if (ch >= '0'&&ch <= '9')
	{
		sym = 11;
		do
		{
			token[n++] = ch;
			ch = prog[p++];
		} while (ch >= '0'&&ch <= '9');
		//sym = 12;
		p--;
		return;
	}
	else
	{
		switch (ch)
		{
			case'+':sym = 13; token[0] = ch; break;
			case'-':sym = 14; token[0] = ch; break;
			case'*':sym = 15; token[0] = ch; break;
			case'/':sym = 16; token[0] = ch; break;
			case'=':sym = 17; token[0] = ch; break;
			case'<':sym = 18; token[0] = ch; break;
			case';':sym = 19; token[0] = ch; break;
			default:
			{
				sym = -2;
				cout << (char)ch << "是非法符号，位于第" << line << "行\n";
				break;
			}
		}
	}
}

int main()
{
	int w = 1;
	cout << "字符种类如下表：" << endl;
	cout << "字母串\tif\tthen\telse\tend\trepeat\tuntil\tread\twrite\n1\t3\t4\t5\t6\t7\t8\t9\t10\n";
	cout << "数字\t+\t-\t*\t/\t=\t<\t;\n11\t13\t14\t15\t16\t17\t18\t19\n";
	cout << "请输入源文件名：" << endl;
	while (1)
	{
		cin >> filename;
		if ((fpin = fopen(filename, "r")) != NULL)
		{
			//num = 1;
			break;
		}
		else cout << "文件路径错误！请输入源文件名：";
	}
	p = 0;
	do
	{
		ch = fgetc(fpin);
		prog[p++] = ch;
	} while (ch != EOF);
	ofstream ofile;
	ofile.open("output_file.txt");
	puts("源程序如下:");
	int ls = 1;
	char str[100];
	fpin = fopen(filename, "r");
	while (fgets(str, 100, fpin))
	{
		//printf("%d %s", ls++, str);
		ofile << ls++ << ' ' << str;

	}
	puts("");
	p = 0;
	do {
		GetToken();
		switch (sym)
		{
			case -1:
			case -2:break;
			default:
			{
				if (token != '\0')
				{//cout << "(" << sym << "," << token << ")\n"; 

					ofile << "(" << sym << "," << token << ")\n";

				}
				break;
			}
		}
	} while (p != strlen(prog)-1);
	ofile.close();
	return 0;
}

/*
当待读文件最后一行为空行时，在分析最后一行词法时出现异常输出，这与程序对文件结束符的处理方法相符

input:
input_file.txt


output:

output_file.txt


(1,int)
(1,a)
(17,=)
(11,2)
(19,;)
(19,)
(1,for)
(1,s)
(17,=)
(11,123)
(16,/)
(11,10)
(19,;)
(19,)
(1,out)
(1,sfau)
(17,=)
(11,2)
%是非法符号，位于第3行
(11,2)
(19,;)
(19,)
#是非法符号，位于第4行
(1,cout)
(18,<)
(18,<)
(1,sfau)
(19,;)
*/
