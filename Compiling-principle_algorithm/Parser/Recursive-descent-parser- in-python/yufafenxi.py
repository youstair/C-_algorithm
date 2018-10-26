keyword=["if","for","else","while","do","float","int","break" ]
keywordtable=[str]*20
keyword_num=0


idtable=[str]*20
id_num=0


digittable=[str]*20
digit_num=0


notetable=[str]*20
note_num=0


otherchartable=[str]*20
otherchar_num=0 #其他字符数


word=''


finaltable=[str]*100
final_num=0  #终结符数
finaltableint=[int]*100

#终结符下标扫描指针
finalNum=0
flagError=0 #
flag_error=0
lookahead=''
st=''
#文件流模拟指针
fptr=0


#文件流读操作
def Getchar():
    global fptr
    sr=str(st[fptr])
    fptr+=1
    return sr

def unGetchar():
    global fptr
    fptr-=1
    return

def match(t):

    global finalNum
    global flagError
    # print(finaltable,finalNum,final_num)
    if str(t)==str(finaltable[finalNum]):
        finalNum+=1
        # print('match',t,'successed')
    else :
        flagError=1

def alpha():
    global word
    global keyword_num
    global  keywordtable
    global  finaltable
    global final_num
    global  finaltableint
    global  idtable
    global  id_num
    i=1
    flag=0
    ch=lookahead
    word+=ch
    ch=Getchar()
    while ch.isalpha() or ch.isdigit():
        word+=ch
        i+=1
        ch=Getchar()
    unGetchar()
    flag=0
    i=0
    while i<8 :
        if str(word)==str(keyword[i]) :
            flag=1
        i+=1
    if flag==1 :
        keywordtable[keyword_num]=str(word)
        keyword_num+=1
        finaltable[final_num]=str(word)
        if str(word)=='if' :
            finaltableint[final_num]=100
            final_num+=1
        elif str(word)=='for':
            finaltableint[final_num] = 200
            final_num += 1
        elif str(word)=='else':
            finaltableint[final_num] = 300
            final_num += 1
        elif str(word)=='while':
            finaltableint[final_num] = 400
            final_num += 1
        elif str(word)=='do':
            finaltableint[final_num] = 500
            final_num += 1
        elif str(word)=='float':
            finaltableint[final_num] = 600
            final_num += 1
        elif str(word)=='int':
            finaltableint[final_num] = 700
            final_num += 1
        elif str(word)=='break':
            finaltableint[final_num] = 800
            final_num += 1
    else :
        idtable[id_num]=str(word)
        id_num+=1
        finaltable[final_num]='id'
        finaltableint[final_num]=1
        final_num+=1
    return

def digit():
    global word
    global idtable
    global id_num
    global finaltable
    global final_num
    global finaltableint
    global digittable
    global digit_num
    flag=1
    ch=lookahead
    word+=ch
    ch=Getchar()
    while ch.isalpha() or ch.isdigit() :
        word+=ch
        ch=Getchar()
    unGetchar()
    if str(word).isdigit() :
        flag=0
    # while word[i]!='\0' :
    #     if word[i].isalpha()==False :
    #         flag=1
    #     i+=1
    if flag==1 :
        idtable[id_num]=str(word)
        id_num+=1
        finaltable[final_num]='id'
        finaltableint[final_num]=1
        final_num+=1
    else :
        digittable[digit_num]=str(word)
        digit_num+=1
        finaltable[final_num]='num'
        finaltableint[final_num]=99
        final_num+=1
    return

def note():
    global  word
    global  note_num
    global  notetable
    ch=Getchar()
    while 1 :
        if ch=='*' :
            ch=Getchar()
            if ch=='/' :
                break
            else :
                unGetchar()
                word+=ch
        else :
            word+=ch
        ch=Getchar()
    notetable[note_num]=str(word)
    note_num+=1
    return

def other_char():
    global  otherchartable
    global  otherchar_num
    global  finaltableint
    global  finaltable
    global  final_num
    ch=lookahead
    if ch== '!':
        ch=Getchar()
        if ch == '=' :
            otherchartable[otherchar_num]='!='
            otherchar_num+=1
            finaltable[final_num]='!='
            finaltableint[final_num]=3
            final_num+=1
        else :
            unGetchar()
            error()
    elif ch=='=':
        ch=Getchar()
        if ch=='=':
            otherchartable[otherchar_num] = '=='
            otherchar_num += 1
            finaltable[final_num] = '=='
            finaltableint[final_num] = 4
            final_num +=1
        else:
            otherchartable[otherchar_num]='='
            otherchar_num+=1
            finaltable[final_num]='='
            finaltableint[final_num]=5
            final_num+=1
            unGetchar()
    elif ch=='(' :
        otherchartable[otherchar_num] = '('
        otherchar_num += 1
        finaltable[final_num] = '('
        finaltableint[final_num] = 6
        final_num += 1
    elif ch==')':
        otherchartable[otherchar_num] = ')'
        otherchar_num += 1
        finaltable[final_num] = ')'
        finaltableint[final_num] = 7
        final_num += 1
    elif ch==';':
        otherchartable[otherchar_num] = ';'
        otherchar_num += 1
        finaltable[final_num] = ';'
        finaltableint[final_num] = 8
        final_num += 1
    elif ch=='{':
        otherchartable[otherchar_num] = '{'
        otherchar_num += 1
        finaltable[final_num] = '{'
        finaltableint[final_num] = 9
        final_num += 1
    elif ch=='}' :
        otherchartable[otherchar_num] = '}'
        otherchar_num += 1
        finaltable[final_num] = '}'
        finaltableint[final_num] = 10
        final_num += 1
    elif ch =='||' :
        otherchartable[otherchar_num] = '||'
        otherchar_num += 1
        finaltable[final_num] = '||'
        finaltableint[final_num] = 11
        final_num += 1
    elif ch=='&&' :
        otherchartable[otherchar_num] = '&&'
        otherchar_num += 1
        finaltable[final_num] = '&&'
        finaltableint[final_num] = 12
        final_num += 1
    elif ch=='+' :
        otherchartable[otherchar_num] = '+'
        otherchar_num += 1
        finaltable[final_num] = '+'
        finaltableint[final_num] = 13
        final_num += 1
    elif ch =='-' :
        otherchartable[otherchar_num] = '-'
        otherchar_num += 1
        finaltable[final_num] = '-'
        finaltableint[final_num] = 19
        final_num += 1
    elif ch =='>':
        ch=Getchar()
        if ch=='=':
            otherchartable[otherchar_num] = '>='
            otherchar_num += 1
            finaltable[final_num] = '>='
            finaltableint[final_num] =14
            final_num += 1
        else:
            otherchartable[otherchar_num] = '>'
            otherchar_num += 1
            finaltable[final_num] = '>'
            finaltableint[final_num] = 15
            final_num += 1
    elif ch=='<':
        ch = Getchar()
        if ch == '=':
            otherchartable[otherchar_num] = '<='
            otherchar_num += 1
            finaltable[final_num] = '<='
            finaltableint[final_num] = 16
            final_num += 1
        else:
            otherchartable[otherchar_num] = '<'
            otherchar_num += 1
            finaltable[final_num] = '<'
            finaltableint[final_num] = 17
            final_num += 1
    elif ch=='*':
        finaltable[final_num]='*'
        finaltableint[final_num]=18
        final_num+=1
    else: error()
    return

def error():
    global  flag_error
    flag_error=1
    print('出现错误，终止分析')
    return

def initialize():
    global word
    word=''
    return

def init():
    global st
    global lookahead
    global finaltable
    global final_num
    global finaltableint
    global otherchartable
    global otherchar_num
    initialize()
    while 1 :
        lookahead=Getchar()
        if lookahead=='#':
            break
        if lookahead.isalpha():
            alpha()
            initialize()
        elif lookahead.isdigit():
            digit()
            initialize()
        elif lookahead=='\t' or lookahead ==' ':
            continue
        elif lookahead=='\n':
            break
        elif lookahead=='/':
            lookahead=Getchar()
            if lookahead=='*':
                note()
                initialize()
            else :
                unGetchar()
                finaltable[final_num]='/'
                otherchartable[othechar_num]='/'
                otherchar_num+=1
                finaltableint[final_num]=2
                final_num+=1
                initialize()
        else :
            other_char()
            initialize()
    if flag_error==0:
        Print()
        # print('other_char',otherchar_num,otherchartable)
        # print('idtable',id_num,idtable)
        # print('finaltable',final_num,finaltable)
        # print('finaltableint',finaltableint)
        # print('digittable',digit_num,digittable)
        program()
        if finalNum==final_num:
            print('语法分析完成')

def Print():
    global  finaltableint
    finaltableint[final_num]='\0'
    print('语法分析结果如下：')
    i=0
    sr=''
    while i<final_num :
        sr+=finaltable[i]
        i+=1
    print('语法分析过程如下：')
    print(sr)
    return

def program():
    print('program-->block')
    block()
    if flagError==1 :
        error()
    return

def block():
    if flagError==1 :
        error()
        return
    print('block-->{stmts}')
    match('{')
    stmts()
    match('}')

    return

def stmts():

    if flagError==1 : return
    if finaltableint[finalNum]==10 :
        print('stmts-->null')
        return
    print('stmts-->stmt stmts')
    stmt()
    stmts()
    return

def stmt():
    if flagError ==1 : return
    if finaltableint[finalNum]==1 :
        print('stmt-->id=expr;')
        match('id')
        match('=')
        expr();
        match(';')
    elif finaltableint[finalNum]==100 :
        match('if')
        match('(')
        Bool()
        match(')')
        stmt()
        if str(finaltable[finalNum])=='else' :
            print('stmt-->if(bool) stmt else stmt')
            match('else')
            stmt()
        else :
            print('stmt->{if(bool) stmt')
    elif finaltableint[finalNum]==400 :
        print('stmt-->while(bool) stmt')
        match('while')
        match('(')
        Bool()
        match(')')
        stmt()
    elif finaltableint[finalNum]==500 :
        match('do')
        stmt()
        match('while')
        match('(')
        Bool()
        match(')')
    elif finaltableint[finalNum]==800 :
        print('stmt-->break')
        match('break')
    else:
        # print('stmt-->block',finaltable,final_num,finalNum,finaltableint[finalNum])
        print('stmt-->block')
        block()
    return

def Bool():
    if flagError==1 : return
    expr()
    if finaltableint[finalNum]==17 :
        print('bool-->expr<expr')
        match('<')
        expr()
    elif finaltableint[finalNum]==16 :
        print('bool-->expr<=expr')
        match('<=')
        expr()
    elif finaltableint[finalNum]==15 :
        print('bool-->expr>expr')
        match('>')
        expr()
    elif finaltableint[finalNum]==14 :
        print('bool-->expr>=expr')
        match('>=')
        expr()
    else:
        print('bool-->expr')
        expr()
    return

def expr():
    if flagError ==1 : return
    print('expr-->term expr1')
    term()
    expr1()
    return

def expr1():
    if flagError ==1 : return
    if finaltableint[finalNum]==13 :
        print('expr1-->+ term expr1')
        match('+')
        term()
        expr1()
    elif finaltableint[finalNum]==19 :
        print('expr1-->- term expr1')
        match('-')
        term()
        expr1()
    else :
        print('expr1-->null')
    return

def term():
    if flagError==1 : return
    print('term-->factor term1')
    factor()
    term1()
    return

def term1():
    if flagError==1 : return
    if finaltableint[finalNum]==18 :
        print('term1-->*factor term1')
        match('*')
        factor()
        term1()
    elif finaltableint[finalNum]==2 :
        print('term1-->*factor term1')
        match('/')
        factor()
        term1()
    else:
        print('term1-->null')
    return

def factor():
    global  flagError
    if flagError ==1 : return
    if finaltableint[finalNum]==6 :
        print('factor-->(expr)')
        match('(')
        expr()
        match(')')
    elif finaltableint[finalNum]==1 :
        print('factor-->id')
        match('id')
    elif finaltableint[finalNum]== 99 :
        print('factor-->num')
        match('num')
    else:
        flagError=1
    return

def main():
    global  st
    print('输入源文件为 input.txt')
    st=read_file_as_str('input.txt')
    print('输入文件处理为  temp.txt')
    i=0
    while i<len(st):
        if st[i]!='\n':
            save_to_file(st[i])
        i+=1
    save_to_file('#')
    st=read_file_as_str('temp.txt')
    init()
    return

def read_file_as_str(file_path):
    with open(file_path,'r')as A:
        inputStream=str(A.read())
    return inputStream

def save_to_file( contents,file_name='temp.txt'):
    with open(file_name, "a") as f:
        f.write(str(contents))

if __name__=='__main__':
    main()

