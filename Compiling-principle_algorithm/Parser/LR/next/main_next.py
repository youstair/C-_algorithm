import  os

table=[]

r=[
['program',1],
['block',3],
['stmts',2],
['stmt',4],
['stmt',5],
['stmt',1],
['E',3],
['E',1],
['bool',3],
['bool',3],
['bool',1],
['T',1],
['T',1],
['stmts',1]
]

index_char=[ '{','}','id','=','num',';','while','(',')','<=','+','>=','#','block','stmts','stmt','E','T','bool']
# def get_index_char(i):
#     return index_char.index(i)
status_p=[]
symbol_p=[]
instr_p=[]


def get_input():
    ls=[]
    lists=''
    j=''
    with open('input_file_next.txt') as temps:
        lists = str(temps.readlines())
    for i in lists:
        if i!=' ':
            j+=i
        else:
            ls.append(j)
            j=''
    ls.append('}')
    return ls
def get_table():
    global table
    with open('table.txt') as temps:
        lists = temps.readlines()
    for line in lists:
        temp = []
        temp1 = ''
        for i in range(0, len(line)):
            if line[i] == '\t' or line[i]=='\n':
                temp.append(temp1)
                temp1 = ''
            else:
                temp1 += line[i]
        table.append(temp)
    for i in table:
        print(i)

def get_out_p(p):
    sr=''
    for i in p :
        sr+=str(i)
    return sr
def Print():
    sr1=get_out_p(status_p)
    sr2=get_out_p(symbol_p)
    sr3=get_out_p(instr_p)
    print('%-40s%-40s%-40s' % (sr1,sr2,sr3))
    return
def goto_char():
    global li
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
    i=int(i)
    if i==-1 :
        print('规约出错')
    elif i==233 :
        print('规约成功')
    elif i>=0 and i <100 :
        status_p.append(i)
        a=instr_p.pop()
        symbol_p.append(a)
        Print()
        action()
    elif i>=100 and i<=200 :
        x=r[i-100][1]
        j=0
        while j<x :
            status_p.pop()
            symbol_p.pop()
            j+=1
        instr_p.append(r[i-100][0])
        action()
def main():
    st = ''
    global  status_p
    global  symbol_p
    global  instr_p
    get_table()
    # for i in table:
    #     print(i)
    status_p=[]
    symbol_p=[]
    instr_p=[]
    status_p.append(0)
    symbol_p.append('#')
    print('要分析的文件为input.txt')
    st=get_input()
    st.append('#')
    st[0]='{'
    print(st)
    # order = []
    # for i in st:
    #     order.append(i)
    # order.reverse()  # 将列表反转
    # st=(''.join(order))
    # for i in st :
    #     if i !=' ' and i !='\t' and i !='\n':
    #         instr_p.append(i)
    i=len(st)
    i-=1
    while i>=0:
        instr_p.append(st[i])
        i-=1
    print(instr_p)
    # print(index_char.index('T'))
    ssr1='状态栈'
    ssr2='符号栈'
    ssr3='输入串'
    print('%-38s%-38s%-38s' % (ssr1, ssr2, ssr3))
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