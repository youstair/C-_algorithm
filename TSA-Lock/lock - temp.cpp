 /************************/
/*      LCD???????     */
/************************/
#include <stdio.h>
#include <conio.h>
#include "ApiExusb.h"
#pragma comment(lib,"ApiExusb.lib")
char lcd2[16]={0xbf,0xaa};//开锁
char lcd3[16]={0xb9,0xd8};//关锁
char lcd1[16]={0xc3,0xdc,0xc2,0xeb,0xb4,0xed,0xce,0xf3};//密码错误
char CLEAN[16]={0xa1,0xa0,0xa1,0xa0,0xa1,0xa0,0xa1,0xa0,0xa1,0xa0,0xa1,0xa0,0xa1,0xa0,0xa1,0xa0};

char admin1[16]={0xca,0xc7,0xb7,0xf1,0xca,0xb9,0xd3,0xc3,0xba,0xa3,0xb9,0xd8,0xc3,0xdc,0xc2,0xeb};//是否使用海关密码
char admin2[16]={0xca,0xc7,0xa3,0xa8,0xc7,0xeb,0xb0,0xb4,0xa3,0xb1,0xa3,0xa9};//是（请按1）
char admin3[16]={0xb7,0xf1,0xa3,0xa8,0xc7,0xeb,0xb0,0xb4,0xa3,0xb0,0xa3,0xa9};//否（请按0）
char m_key[6]={'1','2','3','4','5','6'};
char input[100];
int n;

bool unlock_1=false;
void clear();
void cmdsetup();
void datasetup();
void attention();
void SreenClean();
void show(bool x);
bool unlock();
void Getinput();

void m_delay();

bool choose_m_key();

void initialize();


void main()                                                    
{
    bool unlock_1=false;
	printf("Press any key to begin!\n\n");
	getch();
	if(!Startup())			/*???豸*/
	{
		printf("ERROR: Open Device Error!\n");
		return;
	}
    printf("press any key to exit\n");
    

    initialize();
     Getinput();
     bool x=unlock();
     show(x);
    // attention();
    system("pause");
	Cleanup();				/*????豸*/
}

bool choose_m_key()
{




}

void attention()
{
	PortWriteByte(0x28b,0x90);
	while(true)
	{
		PortWriteByte(0x28a,1);
		Sleep(200);
		PortWriteByte(0x28a,0);
		Sleep(200);		
	}
}


void m_delay()
{
	byte data;
	PortWriteByte(0x283,0x36);
	PortWriteByte(0x280,1000%256);
	PortWriteByte(0x280,1000/256);
	PortWriteByte(0x283,0x70);
	PortWriteByte(0x281,1000%256);
	PortWriteByte(0x281,1000/256);
	do{
		if(kbhit())
			exit(0);
		PortReadByte(0x288,&data);
	}while(!(data&0x01));
}

void initialize()
{
    SreenClean();
            int i;
       PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
       clear();
       PortWriteByte(0x288,0x88);
       cmdsetup();
       Sleep(10);
       for (i=0;i<2;i++)
          {
            PortWriteByte(0x288,lcd3[i]);
            datasetup();
           };
}

//80 90 88 98
void SreenClean()
{
        
        int i;
          PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
       clear();
       PortWriteByte(0x288,0x80);//80
       cmdsetup();
       Sleep(10);
       for (i=0;i<16;i++)
          {
            PortWriteByte(0x288,CLEAN[i]);
            datasetup();  
           };


       PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
       clear();
       PortWriteByte(0x288,0x90);//90
       cmdsetup();
       Sleep(10);
       for (i=0;i<16;i++)
          {
            PortWriteByte(0x288,CLEAN[i]);
            datasetup();  
           };


       PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
       clear();
       PortWriteByte(0x288,0x88);//88
       cmdsetup();
       Sleep(10);
       for (i=0;i<16;i++)
          {
            PortWriteByte(0x288,CLEAN[i]);
            datasetup();
           };
}

void Getinput()
{
    n=0;
    int j=-1;
    byte data;
    byte i;
      while(!kbhit())
       {
        PortWriteByte(0x28b,0x81);		/*设置8255的A口C口均为输出*/
        PortWriteByte(0x28a,0x0f);	//低四位 赋值全1 
        PortReadByte(0x28a,&data);
        i=data;
        if (i!=0x0f)
          {
            i=data;
            PortWriteByte(0x28b,0x88); //高四位输入，低四位输出
            PortWriteByte(0x28a,0xf0);	//高四位 写1
            PortReadByte(0x28a,&data);// 读C口
            i=i|data;
            if (i==0x77) j=0;
              else if(i==0x7b) j=1;
              else if(i==0x7d) j=2;
              else if(i==0x7e) j=3;
              else if(i==0xb7) j=4;
              else if(i==0xbb) j=5;
              else if(i==0xbd) j=6;
              else if(i==0xbe) j=7;
              else if(i==0xd7) j=8;
              else if(i==0xdb) j=9;
              else if(i==0xdd) j=10;
              else if(i==0xde) j=11;
              else if(i==0xe7) j=12;
              else if(i==0xeb) j=13;
              else if(i==0xed) j=14;
              else if(i==0xee) j=15;
              if(j==15)
                   break;
              if(n<=6||j!=15)
                input[n++]=char(j+int('0'-0));
                else break;
              Sleep(1000);

          }
       }
    printf("\n%d\n",n);
    //    for(int k=0;k<n;k++)
    //    printf("%c   ",input[k]);
     for(int k=0;k<n;k++)
       printf("*");
    if(strcmp(m_key,input)==0) printf("\n开锁成功！\n");
    else printf("\n密码错误，开锁失败\n");
    puts("");
    unlock_1=true;
}

bool unlock()
{
    if(strcmp(m_key,input)==0) return true;
    return false;
}
//C:\Users\s01\Desktop\dyy\dyy\lock.cpp
void show(bool x)
{
    SreenClean();
       if(x)
       {
                int i;
            PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
            clear();
            PortWriteByte(0x288,0x90);
            cmdsetup();
            Sleep(10);
            for (i=0;i<2;i++)
                {
                    PortWriteByte(0x288,lcd2[i]);
                    datasetup();  
                };
            }
            else
       {
                int i;
            //
            if(unlock_1)
            {
                 PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
                clear();
                PortWriteByte(0x288,0x80);
                cmdsetup();
                Sleep(10);
                for (i=0;i<8;i++)
                {
                    PortWriteByte(0x288,lcd1[i]);
                    datasetup();
                };
            }



            PortWriteByte(0x28b,0x80);	/*??8255????0,C?????,A?????*/
            clear();
            PortWriteByte(0x288,0x88);
            cmdsetup();
            Sleep(10);
            for (i=0;i<2;i++)
                {
                    PortWriteByte(0x288,lcd3[i]);
                    datasetup();
                };
                attention();
       }

}
void  clear()
{
     PortWriteByte(0x288,0x0c);	
      cmdsetup();

}


void cmdsetup()
   {
     PortWriteByte(0x289,0x00);
     Sleep(1);	
     PortWriteByte(0x289,0x04);
     Sleep(1);	
     PortWriteByte(0x289,0x00);
     Sleep(1);	
   }
void datasetup()
   {
     PortWriteByte(0x289,0x01);
     Sleep(1);	
     PortWriteByte(0x289,0x05);	
     Sleep(1);
     PortWriteByte(0x289,0x01);	
     Sleep(1);
   }
