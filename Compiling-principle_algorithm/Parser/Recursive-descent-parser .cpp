// Acm测试.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#pragma warning(disable:4996)
/*
created by youstair
	github address:https://github.com/youstair
*/

/*
递归下降分析器，来自编译原理课程作业

参考 编译原理与实现教材
说明：

1、VS2017 并不支持直接对于字符数组变量 const char[] 直接作为形参使用 const char* 型函数，
	解决办法 将const char[] 型转换为 const char*,直接重构函数strcmp()为strcmp1();
2、对于keyword数组，采用const char[] 初始化
3、输入串必须用花括号包含

*/
#include<bits/stdc++.h>
using namespace std;
const char*keyword[] = { "if","for","else","while","do","float","int","break" };
char keywordtable[20][20], re_keywordtable[20][20];
char digittable[20][20], re_digittable[20][20];
char otherchartable[20][20], re_otherchartable[20][20];
char idtable[20][20], re_idtable[20][20];
char notetable[20][20];
char finaltable[100][20];
int finaltableint[100];
char word[20];
void initialize();
void alpha();
void digit();
void error();
void otherchar();
void note();
void print();
void program();
void block();
void stmts();
void stmt();
void Bool();
void expr();
void expr1();
void term();
void term1();
void factor();
//

int digit_num = 0, keyword_num = 0, otherchar_num = 0, id_num = 0, note_num = 0;
int redigit_num = 1, rekeyword_num = 1, reotherchar_num = 1, reid_num = 1;
int final_num = 0, finalnum = 0;  //final_num用于存入终结符号阶段计数，finalnum用于在语法分析阶段计数
int flag_error = 0, flagerror = 0;//flagerror用于标记单词是否发生匹配错误(1为出错),flag_error用于标记整个语法分析过程是否出错
char lookahead;
int strcmp1(const char s[], const char t[])
{
	string s1 = s;
	string t1 = t;
	if (s1 == t1) return 0;
	else return -1;
}
void match(const char t[])
{

	if (strcmp1(finaltable[finalnum], t) == 0)
	{
	}
	else {
		flagerror = 1; return;
	}
	finalnum++;
}
void alpha()
{
	int i = 1, flag;
	char ch = lookahead;
	word[0] = ch;
	ch = getchar();
	while (isalpha(ch) || isdigit(ch))
	{
		word[i++] = ch;
		ch = getchar();
	}
	ungetc(ch, stdin);
	flag = 0;
	for (i = 0; i < 8; i++)
	{
		if (strcmp1(word, keyword[i]) == 0)
			flag = 1;
	}
	if (flag == 1)
	{
		strcpy(keywordtable[keyword_num++], word); //将保留字复制到保留字表
		strcpy(finaltable[final_num], word);// 将保留字复制到终结符号表
		if (strcmp1(word, "if") == 0)
			finaltableint[final_num++] = 100; //if终结符的序号为100
		if (strcmp1(word, "for") == 0)
			finaltableint[final_num++] = 200;
		if (strcmp1(word, "else") == 0)
			finaltableint[final_num++] = 300;
		if (strcmp1(word, "while") == 0)
			finaltableint[final_num++] = 400;
		if (strcmp1(word, "do") == 0)
			finaltableint[final_num++] = 500;
		if (strcmp1(word, "float") == 0)
			finaltableint[final_num++] = 600;
		if (strcmp1(word, "int") == 0)
			finaltableint[final_num++] = 700;
		if (strcmp1(word, "break") == 0)
			finaltableint[final_num++] = 800;
	}
	else  //不是保留字 即为标识符
	{
		strcpy(idtable[id_num++], word);  //将标识符复制到标识符表中
		strcpy(finaltable[final_num], "id"); //终结符号表中存放id
		finaltableint[final_num++] = 1; //标识符的序号为1
	}
}
void initialize()
{
	for (int i = 0; i < 20; i++)
		word[i] = '\0';
}
void digit()
{
	int i = 1, flag;
	char ch = lookahead;
	word[0] = ch;
	ch = getchar();
	while (isalpha(ch) || isdigit(ch))
	{
		word[i++] = ch;
		ch = getchar();
	}
	ungetc(ch, stdin);
	flag = 0;
	for (i = 0; word[i] != '\0'; i++)
	{
		if (word[i]<'0' || word[i]>'9')
			flag = 1;
	}
	if (flag == 1)  //有一个字符不是数字。该字符串放到标识符数组中
	{
		strcpy(idtable[id_num++], word);
		strcpy(finaltable[final_num], "id");
		finaltableint[final_num++] = 1;
	}
	else
	{
		strcpy(digittable[digit_num++], word);
		strcpy(finaltable[final_num], "num");
		finaltableint[final_num++] = 99;  //数字的序号是99
	}
}
void note()
{
	char ch = getchar();
	int i = 0;
	while (1)
	{
		if (ch == '*')
		{
			ch = getchar();
			if (ch == '/') break;  //是 /*....*/直接跳出循环
			else       //  是/**的情况
			{
				ungetc(ch, stdin);
				word[i++] = ch;
			}
		}
		else word[i++] = ch;  //word数组存放注释内容
		ch = getchar();
	}
	strcpy(notetable[note_num++], word);
}
void otherchar()
{
	char ch = lookahead;
	switch (ch)
	{
	case'!': {
		ch = getchar();
		if (ch == '=')
		{
			strcpy(otherchartable[otherchar_num++], "!=");
			strcpy(finaltable[final_num], "!=");
			finaltableint[final_num++] = 3;
		}
		else
		{
			ungetc(ch, stdin);
			error();
		}
	}
			 break;
	case'=':
	{
		ch = getchar();
		if (ch == '=')
		{
			strcpy(otherchartable[otherchar_num++], "==");
			strcpy(finaltable[final_num], "==");
			finaltableint[final_num++] = 4;
		}
		else
		{
			strcpy(otherchartable[otherchar_num++], "=");
			strcpy(finaltable[final_num], "=");
			finaltableint[final_num++] = 5;
			ungetc(ch, stdin);
		}
	}
	break;
	case'(':
		strcpy(otherchartable[otherchar_num++], "(");
		strcpy(finaltable[final_num], "(");
		finaltableint[final_num++] = 6;
		break;
	case')':
		strcpy(otherchartable[otherchar_num++], ")");
		strcpy(finaltable[final_num], ")");
		finaltableint[final_num++] = 7;
		break;
	case';':
		strcpy(otherchartable[otherchar_num++], ";");
		strcpy(finaltable[final_num], ";");
		finaltableint[final_num++] = 8;
		break;
	case'{':
		strcpy(otherchartable[otherchar_num++], "{");
		strcpy(finaltable[final_num], "{");
		finaltableint[final_num++] = 9;
		break;
	case'}':
		strcpy(otherchartable[otherchar_num++], "}");
		strcpy(finaltable[final_num], "}");
		finaltableint[final_num++] = 10;
		break;
	case'||':
		strcpy(otherchartable[otherchar_num++], "||");
		strcpy(finaltable[final_num], "||");
		finaltableint[final_num++] = 11;
		break;
	case'&&':
		strcpy(otherchartable[otherchar_num++], "&&");
		strcpy(finaltable[final_num], "&&");
		finaltableint[final_num++] = 12;
		break;
	case'+':
		strcpy(otherchartable[otherchar_num++], "+");
		strcpy(finaltable[final_num], "+");
		finaltableint[final_num++] = 13;
		break;
	case'-':
		strcpy(otherchartable[otherchar_num++], "-");
		strcpy(finaltable[final_num], "-");
		finaltableint[final_num++] = 19;
		break;
	case'>':
	{
		ch = getchar();
		if (ch == '=')
		{
			strcpy(otherchartable[otherchar_num++], ">=");
			strcpy(finaltable[final_num], ">=");
			finaltableint[final_num++] = 14;
		}
		else
		{
			strcpy(otherchartable[otherchar_num++], ">");
			strcpy(finaltable[final_num], ">");
			finaltableint[final_num++] = 15;
		}
	}
	break;
	case'<':
	{
		ch = getchar();
		if (ch == '=')
		{
			strcpy(otherchartable[otherchar_num++], "<=");
			strcpy(finaltable[final_num], "<=");
			finaltableint[final_num++] = 16;
		}
		else
		{
			strcpy(otherchartable[otherchar_num++], "<");
			strcpy(finaltable[final_num], "<");
			finaltableint[final_num++] = 17;
		}
	}
	break;
	case'*':
		strcpy(finaltable[final_num], "*");
		finaltableint[final_num++] = 18;
		break;
	default:
		error();
		break;
	}
}
void error()
{
	flag_error = 1;
	printf("出现错误，中止分析！\n");
}
void print()
{
	finaltableint[final_num] = '\0';
	printf("词法分析结果如下：\n");
	for (int i = 0; i < final_num; i++)
		printf(" % s", finaltable[i]);
	printf("\n语法分析过程如下：\n");
}
void program()
{
	printf("program-->block\n");
	block();
	if (flagerror == 1)
	{
		error(); return;
	}
}
void block()
{
	if (flagerror == 1)
	{
		error(); return;
	}
	printf("block-->{stmts}\n");
	match("{");
	stmts();
	match( "}");
}
void stmts()
{
	if (flagerror == 1) return;
	if (finaltableint[finalnum] == 10)  //第二个符号是"}"
	{
		printf("stmts-->null\n"); return;
	}
	printf("stmts-->stmt stmts\n");
	stmt();
	stmts();
}
void stmt()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 1:
		printf("stmt-->id=expr;\n");
		match( "id");
		match( "=");
		expr();
		match( ";");
		break;
	case 100:
		match( "if");
		match( "(");
		Bool();
		match( ")");
		stmt();
		if (strcmp1(finaltable[finalnum],   "else") == 0)
		{
			printf("stmt-->if(bool) stmt else stmt\n");
			match( "else");
			stmt();
			break;
		}
		else
		{
			printf("stmt->{if(bool) stmt\n");
			break;
		}
	case 400:
		printf("stmt-->while(bool) stmt\n");
		match( "while");
		match( "(");
		Bool();
		match( ")");
		stmt();
		break;
	case 500:
		printf("stmt-->do stmt while(bool)\n");
		match( "do");
		stmt();
		match( "while");
		match( "(");
		Bool();
		match( ")");
		break;
	case 800:
		printf("stmt-->break\n");
		match( "break");
	default:
		printf("stmt-->block\n");
		block();
		break;
	}
}
void Bool()
{
	if (flagerror == 1) return;
	expr();
	switch (finaltableint[finalnum])
	{
	case 17:
		printf("bool-->expr<expr\n");
		match( "<");
		expr();
		break;
	case 16:
		printf("bool-->expr<=expr\n");
		match( "<=");
		expr();
		break;
	case 15:
		printf("bool-->expr>expr\n");
		match( ">");
		expr();
		break;
	case 14:
		printf("bool-->expr>=expr\n");
		match( ">=");
		expr();
		break;
	default:
		printf("bool-->expr\n");
		expr();
		break;
	}
}
void expr()
{
	if (flagerror == 1) return;
	printf("expr-->term expr1\n");
	term();
	expr1();
}
void expr1()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 13:
		printf("expr1-->+ term expr1");
		match( "+");
		term();
		expr1();
		break;
	case 19:
		printf("expr1-->- term expr1");
		match( "-");
		term();
		expr1();
		break;
	default:
		printf("expr1-->null\n");
		return;
	}
}
void term()
{
	if (flagerror == 1) return;
	printf("term-->factor term1\n");
	factor();
	term1();
}
void term1()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 18:
		printf("term1-->*factor term1\n");
		match( "*");
		factor();
		term1();
		break;
	case 2:
		printf("term1-->/factor term1\n");
		match( "/");
		factor();
		term1();
		break;
	default:
		printf("term1-->null\n");
		return;
	}
}
void factor()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 6:
		printf("factor-->(expr)\n");
		match( "(");
		expr();
		match(")");
		break;
	case 1:
		printf("factor-->id\n");
		match("id");
		break;
	case 99:
		printf("factor-->num\n");
		match("num");
		break;
	default:
		flagerror = 1;
		break;
	}
}
int main()
{
	printf("请输入要分析的语句：\n");
	initialize();
	while (1) {
		lookahead = getchar();
		if (isalpha(lookahead))
		{
			alpha();
			initialize();
		}
		else if (isdigit(lookahead))
		{
			digit();
			initialize();
		}
		else if (lookahead == '\t' || lookahead == ' ')
		{
			continue;
		}
		else if (lookahead == '\n') break;
		else if (lookahead == '/')
		{
			lookahead = getchar();
			if (lookahead == '*')
			{
				note();
				initialize();
			}
			else
			{
				ungetc(lookahead, stdin); //把一个字符退回到输入流中
				strcpy(finaltable[final_num], "/"); //把“/”放入终结符号表
				strcpy(otherchartable[otherchar_num++], "/");//把“/”放入其他符号表
				finaltableint[final_num++] = 2; // "/"的序号是2
				initialize();
			}
		}
		else {
			otherchar();
			initialize();
		}
	}
	if (flag_error == 0)
	{

		print();
		program();
		if (finalnum == final_num)
			printf("语法分析完成！\n");
	}
	return 0;
}
/*
test input:
{t=0;while (t<=100){t=t+1;}}


test output:
{t=0;while (t<=100){t=t+1;}}
词法分析结果如下：
{ id = num ; while ( id <= num ) { id = id + num ; } }
语法分析过程如下：
program-->block
block-->{stmts}
stmts-->stmt stmts
stmt-->id=expr;
expr-->term expr1
term-->factor term1
factor-->num
term1-->null
expr1-->null
stmts-->stmt stmts
stmt-->while(bool) stmt
expr-->term expr1
term-->factor term1
factor-->id
term1-->null
expr1-->null
bool-->expr<=expr
expr-->term expr1
term-->factor term1
factor-->num
term1-->null
expr1-->null
stmt-->block
block-->{stmts}
stmts-->stmt stmts
stmt-->id=expr;
expr-->term expr1
term-->factor term1
factor-->id
term1-->null
expr1-->+ term expr1term-->factor term1
factor-->num
term1-->null
expr1-->null
stmts-->null
stmts-->null
语法分析完成！
*/

