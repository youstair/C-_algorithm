using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
namespace SimpleMDIExample
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }//初始加载
        bool Ischange = false;
        private void FormMain_Load(object sender, EventArgs e)
        {
            //获取系统字体，并将字体名称显示在下拉框中
            Font_toolStripComboBox.Items.Clear();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamily = installedFontCollection.Families;
            // foreach (FontFamily ff in fontFamily)//指导书中对字体的加载
            // Font_toolStripComboBox.Items.Add(ff.GetName(1));
            int fontnumber = fontFamily.Length;
            for(int i=0;i<fontnumber;i++)
            {
                string FontName = fontFamily[i].Name;
                Font_toolStripComboBox.Items.Add(FontName);
            }//查阅相关资料后的实现


        //    //系统字体大小  
        //    string[] sizearray = enum.getnames(typeof(system.web.ui.webcontrols.fontsize));
        //int size_len = sizearray.length;
        //    for (int i = 0; i<size_len; i++)
        //    {
        //    string size_name = sizeArray[i];
        //        Font_size_ComboBox.Items.Add(size_name);
        //    }
        //        //this.rblSize.DataSource = sizeArray;
        //        ////this.rblSize.SelectedIndex = -1;
        //        //this.rblSize.DataBind();

            LayoutMdi(MdiLayout.Cascade);
            Text = "多文档文本编辑器";
            WindowState = FormWindowState.Maximized;

        }

        private void 窗口层叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
            this.窗口层叠ToolStripMenuItem.Checked = true;
            this.垂直平铺ToolStripMenuItem.Checked = false;
            this.水平平铺ToolStripMenuItem.Checked = false;
            _MdiStyle = 0;
        }

        private void 水平平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
            this.窗口层叠ToolStripMenuItem.Checked = false;
            this.垂直平铺ToolStripMenuItem.Checked = false;
            this.水平平铺ToolStripMenuItem.Checked = true;
            _MdiStyle = 1;
        }

        private void 垂直平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
            this.窗口层叠ToolStripMenuItem.Checked = false;
            this.垂直平铺ToolStripMenuItem.Checked = true;
            this.水平平铺ToolStripMenuItem.Checked = false;
            _MdiStyle = 2;
        }
        
        private void New_tSBtn_Click(object sender, EventArgs e)
        {
            Newfiles();
            //switch (_MdiStyle)
            //{
            //    case 0: LayoutMdi(MdiLayout.Cascade); break;
            //    case 1: LayoutMdi(MdiLayout.TileHorizontal); break;
            //    case 2: LayoutMdi(MdiLayout.TileVertical); break;
            //}
        } //新建按钮

        private void Open_tSBtn_Click(object sender, EventArgs e)
        {
            Openfiles();
        } //打开文档

        private void Save_tSBtn_Click(object sender, EventArgs e)
        {
            Savefiles();
        }//保存文档
        
        private void Close_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Closefiles();
        }//关闭文档
        
        private void Font_toolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
            {
                RichTextBox Temp_RichTextBox = new RichTextBox();
                int RtbStart = ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.SelectionStart;
                int RtbLen = ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.SelectionLength;
                int Temp_RtbStart = 0;

                Font font = ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.SelectionFont;
                if (RtbLen <= 0 && null != font)
                {
                    ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.Font = new Font(Font_toolStripComboBox.Text, font.Size, font.Style);
                    return;
                }
                Temp_RichTextBox.Rtf = ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.SelectedRtf;
                for(int i = 0; i < RtbLen; i++)
                {
                    Temp_RichTextBox.Select(Temp_RtbStart + i, 1);
                    Temp_RichTextBox.SelectionFont = new Font(Font_toolStripComboBox.Text,
                        Temp_RichTextBox.SelectionFont.Size, Temp_RichTextBox.SelectionFont.Style);
                }
                Temp_RichTextBox.Select(Temp_RtbStart, RtbLen);
                ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.SelectedRtf = Temp_RichTextBox.SelectedRtf;
                ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.Select(Temp_RtbStart, RtbLen);
                ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.Focus();
                Temp_RichTextBox.Dispose();

            }
        }//字体

       
        //}//设置改变字体属性的方法
        private void ChangeRTBFontstyle(RichTextBox _RTB, FontStyle _Style)
        {
            if (this.MdiChildren.Count() > 0)
            {
                if (_RTB.SelectedText != "")
                {
                    Font oldfont = _RTB.SelectionFont;
                    if (oldfont != null)
                    {
                        if (oldfont.Bold || oldfont.Italic || oldfont.Underline)
                            _RTB.SelectionFont
                                = new Font(oldfont, oldfont.Style ^ _Style);
                        else _RTB.SelectionFont
                                = new Font(oldfont, oldfont.Style | _Style);
                    }

                }
                else
                {
                    Font oldfont = ((FormDoc)ActiveMdiChild).Doc_richTextBox.SelectionFont;
                    if (oldfont.Bold || oldfont.Italic || oldfont.Underline)
                        ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.Font
                            = new Font(oldfont, oldfont.Style ^ _Style);
                    else ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.Font
                            = new Font(oldfont, oldfont.Style | _Style);
                }
            }
        }
       
        private void Bold_tSBtn_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
                ChangeRTBFontstyle(((FormDoc)this.ActiveMdiChild).Doc_richTextBox, FontStyle.Bold);
        }//粗体
        
        private void Italic_toolStripButton_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
                ChangeRTBFontstyle(((FormDoc)this.ActiveMdiChild).Doc_richTextBox, FontStyle.Italic);
        }//斜体
        
        private void Underline_toolStripButton_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
                ChangeRTBFontstyle(((FormDoc)this.ActiveMdiChild).Doc_richTextBox, FontStyle.Underline);
        }//下划线

        private void New_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newfiles();
        }//

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            Openfiles();
        }//打开文档

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            Newfiles();
        }//新建文档

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            Savefiles();
        }//保存文档
        private void Openfiles()//打开文件原函数
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RTF格式(*.rtf)|*.rtf|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //新建一个窗口
                    Newfiles();
                    _Num--;

                    if (openFileDialog.FilterIndex == 1)
                        ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.LoadFile
                            (openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    else
                        ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.LoadFile
                            (openFileDialog.FileName, RichTextBoxStreamType.PlainText);

                    ((FormDoc)this.ActiveMdiChild).Text = openFileDialog.FileName;

                }
                catch
                {
                    MessageBox.Show("打开失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Newfiles()
        {
            FormDoc formDoc = new FormDoc();
            formDoc.MdiParent = this;
            formDoc.Text = "文档" + _Num;
            formDoc.WindowState = FormWindowState.Maximized;
            formDoc.Show();
            formDoc.Activate();
            _Num++;
        }//新建文件原函数
        private  void Savefiles()//保存文件原函数
        {
            //保存文档
                //判断新文件还是打开已有文档
                //正则匹配
                string DocFirst = @"^文档";
                Regex myRegex = new Regex(DocFirst);
                if (this.MdiChildren.Count() > 0)
                {
                    if (myRegex.IsMatch(((FormDoc)this.ActiveMdiChild).Text))
                    {

                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "RTF格式(*.rtf)|*.rtf|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
                        };
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if (saveFileDialog.FilterIndex == 1)
                                    ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.
                                        SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                                else
                                    ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.
                                        SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);

                                MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            catch
                            {
                                MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        saveFileDialog.Dispose();
                    }
                    else
                    {
                        try
                        {
                            ((FormDoc)this.ActiveMdiChild).Doc_richTextBox.
                            SaveFile(((FormDoc)this.ActiveMdiChild).Text, RichTextBoxStreamType.RichText);
                            MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        catch
                        {
                            MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }


        }
        private void Closefiles()//关闭文件原函数
        {
            if (this.MdiChildren.Count() > 0)
            {
                if (MessageBox.Show("确定退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (MessageBox.Show("是否保存当前更改?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        Savefiles();
                    foreach (FormDoc fd in this.MdiChildren)
                        fd.Close();
                    Application.Exit();
                }
            }
        }

        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openfiles();
        }

        private void Save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Savefiles();
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void 剪切UToolStripButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^x");//键盘映射
        }

        private void 复制CToolStripButton_Click(object sender, EventArgs e)
        {
            //SendKeys.Send("^c");
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.Copy();
        }

        private void 粘贴PToolStripButton_Click(object sender, EventArgs e)
        {
           // SendKeys.Send("^v");
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.Paste();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^z");
        }//撤销

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //SendKeys.Send("^y");
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.Redo();
        }//重做

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }//左对齐

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }//右对齐
        private bool FindMyText(string text)
        {
            bool returnValue = false;

            if (text.Length > 0&& ((FormDoc)ActiveMdiChild)!=null)
            {
                int indexToText = ((FormDoc)ActiveMdiChild).Doc_richTextBox.Find(text);

                if (indexToText >= 0)
                {
                    ((FormDoc)ActiveMdiChild).Doc_richTextBox.Select(indexToText, text.Length);
                   // ((FormDoc)ActiveMdiChild).Doc_richTextBox.Focus();
                    returnValue = true;
                }
            }
            else
            {
                MessageBox.Show("请打开有效文件");
            }

            return returnValue;
        }//定义搜索函数
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Ischange = false;
            if(toolStripComboBox1.Text!="")
                Ischange = true;
        }//搜索框内容发生改变

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Ischange)
            {
                if (!FindMyText(toolStripComboBox1.Text))
                    MessageBox.Show("查找失败！");
            }
            else MessageBox.Show("请输入搜索内容！");
        }//搜索按钮

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ((FormDoc)ActiveMdiChild).Doc_richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }//居中

    }
}
