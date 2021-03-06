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
4、由于实际情况中源程序一般具有特殊缩进，为了使程序能更加适应实际情况，在此将源文件作为输入，并将其简单转换为临时文件temp，然后将temp送入语法分析器

*/
#include<bits/stdc++.h>
FILE *fpin;//文件流
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
ofstream ifile;//重定向语法分析结果
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
	ch = fgetc(fpin);
	while (isalpha(ch) || isdigit(ch))
	{
		word[i++] = ch;
		ch = fgetc(fpin);
	}
	ungetc(ch, fpin);
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
	ch = fgetc(fpin);
	while (isalpha(ch) || isdigit(ch))
	{
		word[i++] = ch;
		ch = fgetc(fpin);
	}
	ungetc(ch, fpin);
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
	char ch = fgetc(fpin);
	int i = 0;
	while (1)
	{
		if (ch == '*')
		{
			ch = fgetc(fpin);
			if (ch == '/') break;  //是 /*....*/直接跳出循环
			else       //  是/**的情况
			{
				ungetc(ch, fpin);
				word[i++] = ch;
			}
		}
		else word[i++] = ch;  //word数组存放注释内容
		ch = fgetc(fpin);
	}
	strcpy(notetable[note_num++], word);
}
void otherchar()
{
	char ch = lookahead;
	switch (ch)
	{
	case'!': {
		ch = fgetc(fpin);
		if (ch == '=')
		{
			strcpy(otherchartable[otherchar_num++], "!=");
			strcpy(finaltable[final_num], "!=");
			finaltableint[final_num++] = 3;
		}
		else
		{
			ungetc(ch, fpin);
			error();
		}
	}
			 break;
	case'=':
	{
		ch = fgetc(fpin);
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
			ungetc(ch, fpin);
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
		ch = fgetc(fpin);
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
		ch = fgetc(fpin);
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
	ifile.open("output.txt");
	ifile << "语法分析结果如下\n";

	for (int i = 0; i < final_num; i++)
		ifile << ' ' << finaltable[i] << ' ';

	ifile<<"\n语法分析过程如下：\n";

}
void program()
{
	ifile<<("program-->block\n");
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
	ifile<<("block-->{stmts}\n");
	match("{");
	stmts();
	match("}");
}
void stmts()
{
	if (flagerror == 1) return;
	if (finaltableint[finalnum] == 10)  //第二个符号是"}"
	{
		ifile<<("stmts-->null\n"); return;
	}
	ifile<<("stmts-->stmt stmts\n");
	stmt();
	stmts();
}
void stmt()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 1:
		ifile<<("stmt-->id=expr;\n");
		match("id");
		match("=");
		expr();
		match(";");
		break;
	case 100:
		match("if");
		match("(");
		Bool();
		match(")");
		stmt();
		if (strcmp1(finaltable[finalnum], "else") == 0)
		{
			ifile<<("stmt-->if(bool) stmt else stmt\n");
			match("else");
			stmt();
			break;
		}
		else
		{
			ifile<<("stmt->{if(bool) stmt\n");
			break;
		}
	case 400:
		ifile<<("stmt-->while(bool) stmt\n");
		match("while");
		match("(");
		Bool();
		match(")");
		stmt();
		break;
	case 500:
		ifile<<("stmt-->do stmt while(bool)\n");
		match("do");
		stmt();
		match("while");
		match("(");
		Bool();
		match(")");
		break;
	case 800:
		ifile<<("stmt-->break\n");
		match("break");
	default:
		ifile<<("stmt-->block\n");
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
		ifile<<("bool-->expr<expr\n");
		match("<");
		expr();
		break;
	case 16:
		ifile<<("bool-->expr<=expr\n");
		match("<=");
		expr();
		break;
	case 15:
		ifile<<("bool-->expr>expr\n");
		match(">");
		expr();
		break;
	case 14:
		ifile<<("bool-->expr>=expr\n");
		match(">=");
		expr();
		break;
	default:
		ifile<<("bool-->expr\n");
		expr();
		break;
	}
}
void expr()
{
	if (flagerror == 1) return;
	ifile<<("expr-->term expr1\n");
	term();
	expr1();
}
void expr1()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 13:
		ifile<<("expr1-->+ term expr1");
		match("+");
		term();
		expr1();
		break;
	case 19:
		ifile<<("expr1-->- term expr1");
		match("-");
		term();
		expr1();
		break;
	default:
		ifile<<("expr1-->null\n");
		return;
	}
}
void term()
{
	if (flagerror == 1) return;
	ifile<<("term-->factor term1\n");
	factor();
	term1();
}
void term1()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 18:
		ifile<<("term1-->*factor term1\n");
		match("*");
		factor();
		term1();
		break;
	case 2:
		ifile<<("term1-->/factor term1\n");
		match("/");
		factor();
		term1();
		break;
	default:
		ifile<<("term1-->null\n");
		return;
	}
}
void factor()
{
	if (flagerror == 1) return;
	switch (finaltableint[finalnum])
	{
	case 6:
		ifile<<("factor-->(expr)\n");
		match("(");
		expr();
		match(")");
		break;
	case 1:
		ifile<<("factor-->id\n");
		match("id");
		break;
	case 99:
		ifile<<("factor-->num\n");
		match("num");
		break;
	default:
		flagerror = 1;
		break;
	}
}

char filename[30];
char prog[1000];
int p = 0;

void init()
{
	initialize();

	while (lookahead = fgetc(fpin))
	{
		if (lookahead == '#') break;
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
			lookahead = fgetc(fpin);
			if (lookahead == '*')
			{
				note();
				initialize();
			}
			else
			{
				ungetc(lookahead, fpin); //把一个字符退回到输入流中
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
			ifile<<("语法分析完成！\n");
	}
}
int main()
{
	printf("请输入文件名：\n");
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
	char th;
	do
	{
		th = fgetc(fpin);
		prog[p++] = th;
	} while (th != EOF);
	ofstream ofile;
	ofile.open("temp.txt");
	for (int i = 0; i < p - 1; i++)
		if (prog[i] != '\n') ofile << prog[i];
	ofile << '#';
	ofile.close();
	fpin = fopen("temp.txt", "r");
	init();
	ifile.close();
	return 0;
}