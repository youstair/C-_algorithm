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
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }
        //判断输入信息是否有效 有效_Flag为true
        bool AllRight()
        {
            bool _Flag = false;

            if (
                  !(textContactId.Text == string.Empty
                || textName.Text == string.Empty
                || textAge.Text == string.Empty
                || textPhone.Text == string.Empty
                || textEmail.Text == string.Empty
                || textProfession.Text == string.Empty
                || textAdrees.Text == string.Empty
                )
                )
            {
                if (
                   double.TryParse(textContactId.Text, out double tmp)//是否为数字
                   && double.TryParse(textAge.Text, out tmp)
                   && double.TryParse(textPhone.Text, out tmp)
                   )
                {
                    _Flag = true;
                }
                else
                {
                    MessageBox.Show("请检查编号年龄手机号是否正确！");
                }
            }
            else
            {
                _Flag = false;
                MessageBox.Show("请输入完整有效信息！");
            }

            return _Flag;
        }

        private void groupBorder_Enter(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
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

                if (StudentInfoBLL.UpdateContactInfo(contacts))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败!请输入完整有效信息！");
                }
            }
        }
        //标记编辑选中行行数
        public int contact_ID_edit = 1;

        //初始化 获取一行的数据
        private void FormEdit_Load(object sender, EventArgs e)
        {
            Init_Edit();
        }
        public void Init_Edit()
        {
            StudentInfo _Contact = StudentInfoBLL.GetOneContactInfo(contact_ID_edit);
            if (_Contact != null)
            {
                textContactId.Text = _Contact.ContactId.ToString();
                textName.Text = _Contact.Name;
                if (_Contact.Gender == "男")
                {
                    radioMale.Checked = true;
                    radioFemale.Checked = false;
                }
                else if (_Contact.Gender == "女")
                {
                    radioMale.Checked = false;
                    radioFemale.Checked = true;
                }
                textAge.Text = _Contact.Age.ToString();
                dateTimePickerBirth.Text = _Contact.Birthdate.ToString();
                textPhone.Text = _Contact.Phone;
                textEmail.Text = _Contact.Email;
                textAdrees.Text = _Contact.Adress;
                textProfession.Text = _Contact.Profession;
            }

        }

        private void textProfession_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
