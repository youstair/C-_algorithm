using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Mycontacs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitContacts();
        }
        void InitContacts()//初始化，获取文件信息
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"//myContacts.xml"))
            {
                dataGridView1.DataSource = StudentInfoBLL.GetAllContactsInfo(StudentInfoBLL.Return_BasePath());
            }
            else
            {
                StudentInfoBLL.CreateXml(StudentInfoBLL.Return_BasePath());
                dataGridView1.DataSource = StudentInfoBLL.GetAllContactsInfo(StudentInfoBLL.Return_BasePath());
            }

            dataGridView1.Columns[0].HeaderText = "学生编号";
            dataGridView1.Columns[1].HeaderText = "学生姓名";
            dataGridView1.Columns[2].HeaderText = "学生性别";
            dataGridView1.Columns[3].HeaderText = "专业";
            dataGridView1.Columns[4].HeaderText = "学生年龄";
            dataGridView1.Columns[5].HeaderText = "出生日期";
            dataGridView1.Columns[6].HeaderText = "手机号码";
            dataGridView1.Columns[7].HeaderText = "电子邮箱";
            dataGridView1.Columns[8].HeaderText = "家庭住址";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.ShowDialog();
            InitContacts();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (
                    MessageBox.Show("确定要删除此学生信息？", "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes
                    )
                {
                    int selectrow = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    //int selectrow = dataGridView1.CurrentCell.RowIndex+1;



                    if (StudentInfoBLL.DeleteContactInfo(selectrow))
                        MessageBox.Show("删除成功！");
                    else
                        MessageBox.Show("删除失败！");

                    InitContacts();
                }
            }
            else
                MessageBox.Show("请选一行后再点击！");
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch();
            formSearch.ShowDialog();
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FormEdit formEdit = new FormEdit
                {
                    contact_ID_edit =
                    Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString())
                };
                formEdit.ShowDialog();
                InitContacts();
            }
            else
                MessageBox.Show("请选中一行后再点击编辑");
        }

        private void toolStripBackUp_Click(object sender, EventArgs e)
        {
            //检查文件是否存在
            if (!(File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"//myContacts_BackUp.xml")))
            {
                StudentInfoBLL.CreateXml(StudentInfoBLL.Return_BackUpPath());
                if (StudentInfoBLL.ChangeXml(StudentInfoBLL.Return_BasePath(), StudentInfoBLL.Return_BackUpPath()))
                {
                    MessageBox.Show("备份成功！");
                }
            }
            else if (MessageBox.Show("已有备份文件，是否覆盖？", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (StudentInfoBLL.ChangeXml(StudentInfoBLL.Return_BasePath(), StudentInfoBLL.Return_BackUpPath()))
                {
                    MessageBox.Show("备份成功");
                }
            }
        }

        private void toolStripRestore_Click(object sender, EventArgs e)
        {
            //检查文件是否存在
            if (!(File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"//myContacts_BackUp.xml")))
            {
                if (MessageBox.Show("恢复失败！暂无备份文件！是否新建备份？", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    StudentInfoBLL.CreateXml(StudentInfoBLL.Return_BackUpPath());
                    if (StudentInfoBLL.ChangeXml(StudentInfoBLL.Return_BasePath(), StudentInfoBLL.Return_BackUpPath()))
                    {
                        MessageBox.Show("备份成功！");
                    }
                }
                //MessageBox.Show("恢复失败！暂无备份文件！");
            }
            else if (StudentInfoBLL.ChangeXml(StudentInfoBLL.Return_BackUpPath(), StudentInfoBLL.Return_BasePath()))
            {
                InitContacts();
                MessageBox.Show("恢复成功！");
            }
        }
    }
}
