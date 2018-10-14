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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }
        //判断输入的编号是否已存在 存在返回true
        bool IsExists()
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Form1 Form1 = new Form1();

            int row = Form1.dataGridView1.Rows.Count;//得到总行数   

            //int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                if (textContactId.Text == Form1.dataGridView1.Rows[i].Cells[0].Value.ToString())
                {   //对比TexBox中的值是否与dataGridView中的值相同（上面这句）    
                    return true;
                }

            }
            return false;
        }
        //判断输入信息是否有效 有效_Flag为true
        bool AllRight()
        {
            bool _Flag = false;
            //int tmp;

            if (
                  !(
                  textContactId.Text == string.Empty
                || textName.Text == string.Empty
                || textAge.Text == string.Empty
                || textPhone.Text == string.Empty
                || textEmail.Text == string.Empty
                || textProfession.Text == string.Empty
                || textAdrees.Text == string.Empty
                )
                )//全部不为空进行下一步判断
            {
                if (
                   double.TryParse(textContactId.Text, out double tmp)//是否为数字
                   && double.TryParse(textAge.Text, out tmp)
                   && double.TryParse(textPhone.Text, out tmp)
                   )//ID age phone均为数字进行下一步
                {
                    if (!IsExists())//判断编号是否存在 不存在执行下一步 存在提示错误
                    {
                        _Flag = true;
                    }
                    else
                    {
                        MessageBox.Show("不能输入相同编号！");
                    }
                }
                else
                {
                    MessageBox.Show("请检查编号年龄手机号是否正确！");
                }
            }
            else
            {
                _Flag = false;
                MessageBox.Show("请输入完整有效信息！", "warning");
            }

            return _Flag;
        }
        private void groupBorder_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StudentInfo contacts = new StudentInfo();

            if (AllRight())
            {
                contacts.ContactId = Int32.Parse(textContactId.Text);
                contacts.Name = textName.Text;
                contacts.Age = Int32.Parse(textAge.Text);
                contacts.Phone = textPhone.Text;
                contacts.Email = textEmail.Text;
                contacts.Profession = textProfession.Text;
                contacts.Adress = textAdrees.Text;

                if (radioMale.Checked)
                    contacts.Gender = "男";
                else if (radioFemale.Checked)
                    contacts.Gender = "女";
                contacts.Birthdate = DateTime.Parse(dateTimePickerBirth.Text);

                if (StudentInfoBLL.AddContactInfo(contacts))
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败!请输入完整有效信息！");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
