using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace myPuzzle
{
    public partial class Form_Main : Form
    {
        PictureBox[] pictureList = null;//图片列表

        SortedDictionary<string, Bitmap> pictureLocationDict = new SortedDictionary<string, Bitmap>();
        Point[] PointList = null;//图片位置
        //图片控件字典
        SortedDictionary<string, PictureBox> pictureBoxLocationDict = new SortedDictionary<string, PictureBox>();
       int second = 0;//拼图时间

        PictureBox currentPictureBox = null;//拖拽图片

        PictureBox haveTopictureBox = null;//拖拽后必须转移的图片

        Point oldLocation = Point.Empty;//原位置

        Point newLocation = Point.Empty;//新位置

        Point mouseDownPoint = Point.Empty;

        Rectangle rect = Rectangle.Empty;

        bool isDrag = false;//鼠标是否进行了拖拽

        public string originalpicpath;//初始图片位置

        private int ImgNumbers
        {
            get
            {
                return (int)this.NumericUpDown1.Value;
            }
        }//每个方向上要切割的块数
        private int SideLength
        {
            get
            {
                return 600 / this.ImgNumbers;
            }
        }//要切割成的正方形图片边长

        private void InitRandomPictureBox()
        {
            pnl_Picture.Controls.Clear();
            pictureList = new PictureBox[ImgNumbers * ImgNumbers];
            PointList = new Point[ImgNumbers * ImgNumbers];
            for (int i = 0; i < this.ImgNumbers; i++)
            {
                for (int j = 0; j < this.ImgNumbers; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Name = "PictureBox" + (j + i * ImgNumbers + 1).ToString();
                    pic.Location = new Point(j * SideLength, i * SideLength);
                    pic.Size = new Size(SideLength, SideLength);
                    pic.Visible = true;
                    pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                    pic.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
                    pic.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
                    pnl_Picture.Controls.Add(pic);
                    pictureList[j + i * ImgNumbers] = pic;
                    PointList[j + i * ImgNumbers] = new Point(j * SideLength, i * SideLength);
                }
            }
        }//在主窗体动态生成图片框矩阵
        public void Flow(string path, bool disorder)//将图片切割成与图片框矩阵大小、数量相同的图片矩阵
        {
            InitRandomPictureBox();
            Image bm = CutPicture.Resize(path, 600, 600);
            CutPicture.BitMapList = new List<Bitmap>();
            for (int y = 0; y < 600; y += SideLength)
            {
                for (int x = 0; x < 600; x += SideLength)
                {
                    Bitmap temp = CutPicture.Cut(bm, x, y, SideLength, SideLength);
                    CutPicture.BitMapList.Add(temp);
                }
            }
            ImportBitMap(disorder);
        }
        public void ImportBitMap(bool disorder)
        {
            try
            {
                int i = 0;
                foreach (PictureBox item in pictureList)
                {
                    Bitmap temp = CutPicture.BitMapList[i];
                    item.Image = temp;
                    i++;
                }
                if (disorder) ResetPictureLocation();

            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void ResetPictureLocation()
        {
            Point[] temp = DisOrderLocation();
            int i = 0;
            foreach (PictureBox item in pictureList)
            {
                item.Location = temp[i];
                i++;
            }
        }
        public Point[] DisOrderLocation()
        {
            Point[] tempArray = (Point[])PointList.Clone();
            for (int i = tempArray.Length - 1; i > 0; i--)
            {
                Random rand = new Random();
                int p = rand.Next(i);
                Point temp = tempArray[p];
                tempArray[p] = tempArray[i];
                tempArray[i] = temp;
            }
            return tempArray;
        }

        public void InitGame()
        {
            if (!Directory.Exists(Application.StartupPath.ToString()+"\\Picture"))
            {
                Directory.CreateDirectory(Application.StartupPath.ToString() + "\\Picture");
                Properties.Resources._0.Save(Application.StartupPath.ToString() + "\\Picture\\0.jpg");
                Properties.Resources._1.Save(Application.StartupPath.ToString() + "\\Picture\\1.jpg");
                Properties.Resources._2.Save(Application.StartupPath.ToString() + "\\Picture\\2.jpg");
                Properties.Resources._3.Save(Application.StartupPath.ToString() + "\\Picture\\3.jpg");
            }
            Random r = new Random();
            int i = r.Next(4);
            originalpicpath = Application.StartupPath.ToString() + "\\Picture\\" + i.ToString() + ".jpg";
            Flow(originalpicpath, true);
            //if(radioyes.Checked)//挑战模式开始计时
            //{
            //    lab_result.Text = "";
            //    timer1.Start();
            //}

        }
        public Form_Main()
        {
            InitializeComponent();
           // InitRandomPictureBox();
            InitGame();
        }
        public PictureBox GetPictureBoxByLocation(int x,int y)
        {
            PictureBox pic = null;
            foreach(PictureBox item in pictureList)
            {
                if (x > item.Location.X && y > item.Location.Y && item.Location.X + SideLength > x && item.Location.Y + SideLength > y)
                    pic = item;
            }
            return pic;
        }
        public void MoseDown(PictureBox pic, object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldLocation = e.Location;
                rect = pic.Bounds;
            }
        }
        public PictureBox GetPictureBoxByLocation(MouseEventArgs e)
        {
            PictureBox pic = null;
            foreach (PictureBox item in pictureList)
            {
                if (e.Location.X > item.Location.X && e.Location.Y > item.Location.Y && item.Location.X + 100 > e.Location.X && item.Location.Y + 100 > e.Location.X)
                {
                    pic = item;
                }
            }
            return pic;
        }
        /// <summary>
        /// 通过hashcode获取Picture，用mouseeventargs之后获取相对于Picture的坐标不是相对窗体
        /// </summary>
        /// <param name="hascode"></param>
        /// <returns></returns>
        public PictureBox GetPictureBoxByHashCode(string hascode)
        {
            PictureBox pic = null;
            foreach (PictureBox item in pictureList)
            {
                if (hascode == item.GetHashCode().ToString())
                {
                    pic = item;
                }
            }
            return pic;
        }
        private Point getPointToForm(Point p)//
        {
            return this.PointToClient(pictureList[0].PointToScreen(p));
        }

        private void PictureBox_MouseDown(object sender,MouseEventArgs e)
        {
            oldLocation = new Point(e.X, e.Y);
            currentPictureBox = GetPictureBoxByHashCode(sender.GetHashCode().ToString());//GetHashCode().ToString);
            MoseDown(currentPictureBox,sender, e);
        }
         private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                isDrag = true;
                rect.Location = getPointToForm(new Point(e.Location.X - oldLocation.X, e.Location.Y - oldLocation.Y));
                this.Refresh();
            }
        }//移动鼠标
        private void reset()
        {
            mouseDownPoint = Point.Empty;
            rect = Rectangle.Empty;
            isDrag = false;
        }
        private void PictureBox_MouseUp(object sender,MouseEventArgs e)
        {
            oldLocation = new Point(currentPictureBox.Location.X, currentPictureBox.Location.Y);
            if (oldLocation.X + e.X > 600 || oldLocation.Y + e.Y > 600 || oldLocation.X + e.X < 0 || oldLocation.Y + e.Y < 0)
                return;
            haveTopictureBox = GetPictureBoxByLocation(oldLocation.X + e.X, oldLocation.Y + e.Y);
            if (haveTopictureBox == null) ;
            else
            {
                newLocation = new Point(haveTopictureBox.Location.X, haveTopictureBox.Location.Y);
                haveTopictureBox.Location = oldLocation;
                PictureMouseUp(currentPictureBox, sender, e);
                if (Judge())
                {
                    if (radioyes.Checked)
                    {
                        timer1.Stop();
                        second = 0;
                    }
                    lab_result.Text = "";

                    MessageBox.Show("你很棒，已经拼图成功！");
                }
            }
        }//释放鼠标
        public void PictureMouseUp(PictureBox pic,object sender,MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if(isDrag)
                {
                    isDrag = false;
                    pic.Location = newLocation;
                    this.Refresh();
                }
                reset();
            }
        }//
        public bool Judge()
        {
            bool result = true;
            int i = 0;
            foreach(PictureBox item in pictureList)
            {
                if (item.Location != PointList[i])
                    result = false;
                i++;
            }
            return result;
        }//判断拼图是否成功
        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pnl_Picture_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Originalpic_Click(object sender, EventArgs e)
        {
            Form_Original original = new Form_Original();
            original.picpath = originalpicpath;
            original.ShowDialog();
        }
        //查看原图

        private void btn_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog new_picture =new  OpenFileDialog();
            if (new_picture.ShowDialog() == DialogResult.OK)
            {
                lab_result.Text = "";
                originalpicpath = new_picture.FileName;
                CutPicture.picturePath = new_picture.FileName;
                Flow(CutPicture.picturePath, true);
                restart();
            }
        }//试玩新图

        private void btn_Changepic_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = r.Next(4);
            originalpicpath = Application.StartupPath.ToString() + "\\Picture\\" + i.ToString() + ".jpg";
            restart();

        }//切换图片
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void restart()
        {
            if (radioyes.Checked)
            {
                second = 0;
                label_start.Text = "30s计时挑战已用时间";
                CountTime();
            }
            Flow(originalpicpath, true);
            lab_result.Text = "您未完成拼图";
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            restart();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            restart();
        }//图片重置

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void CountTime()
        {
            lab_time.Text = "0";
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            lab_time.Text = second.ToString();
            if(second==30)
            {
                timer1.Stop();
                MessageBox.Show("时间到，拼图失败！");
                second = 0;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lab_isdifficult_Click(object sender, EventArgs e)
        {

        }

        private void radiono_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioyes_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
