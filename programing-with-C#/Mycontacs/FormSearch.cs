using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mycontacs
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            dGV_Search.DataSource = StudentInfoBLL.GetAllContactsInfo(StudentInfoBLL.Return_BasePath());

            InitHeadTitle();
        }
        void InitHeadTitle()
        {

            dGV_Search.Columns[0].HeaderText = "学生编号";
            dGV_Search.Columns[1].HeaderText = "学生姓名";
            dGV_Search.Columns[2].HeaderText = "学生性别";
            dGV_Search.Columns[3].HeaderText = "专业";
            dGV_Search.Columns[4].HeaderText = "学生年龄";
            dGV_Search.Columns[5].HeaderText = "出生日期";
            dGV_Search.Columns[6].HeaderText = "手机号码";
            dGV_Search.Columns[7].HeaderText = "电子邮箱";
            dGV_Search.Columns[8].HeaderText = "家庭住址";
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cB_Search_Item.Text == string.Empty)
            {
                dGV_Search.DataSource = StudentInfoBLL.GetAllContactsInfo(StudentInfoBLL.Return_BasePath());
                InitHeadTitle();
            }
            else
            {
                if (textBox_Searchtext.Text != string.Empty)
                {
                    StudentInfo contactSearch = new StudentInfo();
                    switch (cB_Search_Item.SelectedIndex)
                    {
                        case 0: contactSearch.ContactId = Int32.Parse(textBox_Searchtext.Text); break;
                        case 1: contactSearch.Name = textBox_Searchtext.Text; break;
                    }
                    dGV_Search.DataSource = StudentInfoBLL.GetContactsList(contactSearch);
                    InitHeadTitle();
                }
                else
                {
                    MessageBox.Show("请输入要查询的" + cB_Search_Item.Text);
                }
            }
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
