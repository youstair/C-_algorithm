keyword=[ "if","then","else","end","repeat","until","read","write" ]
st=[str]*1000
token=[str]*8
p=0
sym=0
n=0
line=1
def token_control(token):
    sr = ''
    i = 0
    while i < len(token):
        if (token[i] != '\x00'):
            sr += str(token[i])
        i += 1
    return sr
def GetToken():
    global  keyword
    global line
    global n
    global st
    global sym
    global p
    global ch
    global token
    n=0
    while(n<8):
        token[n]='\0'
        n+=1
    n=0

    ch=st[p]
    p+=1
    while(ch==' ' or ch=='\t'):
        ch=st[p]
        p+=1
        sym=-1
    if(str(ch).isalpha()):
        sym=1
        token[n]=ch
        n+=1
        ch=st[p]
        p+=1
        while str(ch).isalpha():
            token[n] = ch
            n += 1
            ch =st[p]
            p += 1
        n=0
        while(n<8):
            if(str(token)==str(keyword[n])):
                sym=n+3
            n+=1
        p-=1
    elif ch=='{':
        ch=st[p]
        p+=1
        while(ch!='}'):
            ch = st[p]
            p += 1
        sym=-1
        return
    elif ch=='\n':
        line+=1
    elif str(ch).isnumeric():
        sym=11
        token[n] = ch
        n += 1
        ch = st[p]
        p += 1
        while str(ch).isnumeric():
            token[n] = ch
            n += 1
            ch = st[p]
            p += 1
        p-=1
        return
    else :
        if ch=='+':
            sym=13
            token[0]=ch
        elif ch=='-':
            sym=14
            token[0]=ch
        elif ch=='*':
            sym=15
            token[0]=ch
        elif ch=='/':
            sym=16
            token[0]=ch
        elif ch=='=':
            sym=17
            token[0]=ch
        elif ch=='<':
            sym=18
            token[0]=ch
        elif ch==';':
            sym=19
            token[0]=ch
        else :
            sym=-2
            print(str(ch),'是非法符号，位于第',line,'行')
def read_file_as_str(file_path):
    with open(file_path,'r')as A:
        inputstream=str(A.read())
    return inputstream
def save_to_file( contents,file_name='output_file.txt'):
    fh = open(file_name, 'w')
    fh.write(str(contents))
    fh.close()
def main():
    global p
    global sym
    global st

    print('字符种类如下表：')
    print('字母串\tif\tthen\telse\tend\trepeat\tuntil\tread\twrite\n1\t3\t4\t5\t6\t7\t8\t9\t10')
    print('数字\t+\t-\t*\t/\t=\t<\t;\n11\t13\t14\t15\t16\t17\t18\t19')
    print('源文件input_file.txt 打印如下：')
    st = read_file_as_str('input_file.txt')
    save_to_file(st)
    print(st)
    p=0
    while 1:
        GetToken()
        if sym==-1 or sym==-2:
            break
        elif str(token)!='\0':
            print('(',sym,',',str(token_control(token)),')')
            break
        else:
            break
    while(p!=len(st)):
        GetToken()
        while(1):
            if sym == -1 or sym == -2:
                break
            elif str(token) != '\0':
                print('(', sym, ',',str(token_control(token)), ')')
            break
if __name__=='__main__':
    main()














