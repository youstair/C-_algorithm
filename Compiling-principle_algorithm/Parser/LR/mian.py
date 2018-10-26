import  os
table=[
[ 5,	-1,	-1,	4,	-1,	-1,	1,	2,	3 ],
[ -1,	6,	-1,-1,	-1,	12,	-1,	-1,	-1 ],
[ -1,	22,	7, -1,	22,	22,	-1,	-1,	-1 ],
[ -1,	24,	24,-1,	24,	24,	-1,	-1,	-1 ],
[ 5,	-1,-1,	4,	-1,	-1,	8,	2,	3 ],
[ -1,	26,	26,	-1,	26,	26,	-1,	-1,	-1 ],
[ 5,	-1,	-1,	4,	-1,	-1,	-1,	9,	3 ],
[ 5,	-1,	-1,	4,	-1,	-1,	-1,	-1,	10 ],
[ -1,	6,	-1,	-1,	11,	-1,	-1,	-1,	-1 ],
[ -1,	21,	7,	-1,	21,	21,	-1,	-1,	-1 ],
[ -1,	23,	23,	-1,	23,	23,	-1,	-1,	-1 ],
[ -1,	25,	25,	-1,	25,	25,	-1,	-1,	-1 ],
]
r=[ [ 'E',3 ],[ 'E',1 ],[ 'T',3 ],[ 'T',1 ],[ 'F',3 ],[ 'F',1 ] ]
index_char=[ 'i','+','*','(',')','#','E','T','F' ]
# def get_index_char(i):
#     return index_char.index(i)
status_p=[]
symbol_p=[]
instr_p=[]
def get_out_p(p):
    sr=''
    for i in p :
        sr+=str(i)
    return sr
def Print():
    sr=get_out_p(status_p)
    i=0
    while i<20-len(status_p) :
        sr+=' '
        i+=1
    sr+=get_out_p(symbol_p)
    i=0
    while i<20-len(symbol_p):
        sr+=' '
        i+=1
    sr+=get_out_p(instr_p)
    print(sr)
    return
def goto_char():
    if len(instr_p)==0 :
        print('输入串移进完毕')
        os._exit(0)
    else :
        x=instr_p[-1]
    y=status_p[-1]
    z=index_char.index(x)
    return table[y][z]
def action():
    global  status_p
    global  symbol_p
    global  instr_p
    i=goto_char()
    if i==-1 :
        print('规约出错')
    elif i==12 :
        print('规约成功')
    elif i>=0 and i <=11 :
        status_p.append(i)
        a=instr_p.pop()
        symbol_p.append(a)
        Print()
        action()
    elif i>=21 and i<=26 :
        x=r[i-21][1]
        j=0
        while j<x :
            status_p.pop()
            symbol_p.pop()
            j+=1
        instr_p.append(r[i-21][0])
        action()
def main():
    st = ''
    global  status_p
    global  symbol_p
    global  instr_p
    status_p=[]
    symbol_p=[]
    instr_p=[]
    status_p.append(0)
    symbol_p.append('#')
    print('要分析的文件为input.txt')
    st=read_file_as_str('input.txt')
    order = []
    for i in st:
        order.append(i)
    order.reverse()  # 将列表反转
    st=(''.join(order))
    for i in st :
        if i !=' ' and i !='\t' and i !='\n':
            instr_p.append(i)
    print(index_char.index('F'))
    ssr=''
    ssr1='状态栈'
    ssr+=ssr1
    i=0
    while i<17-len(ssr1):
        ssr+=' '
        i+=1
    ssr1='符号栈'
    ssr+=ssr1
    i=0
    while i<18-len(ssr1):
        ssr+=' '
        i+=1
    ssr+='输入串'
    print(ssr)
    Print()
    action()
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