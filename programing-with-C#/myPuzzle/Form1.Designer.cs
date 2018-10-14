namespace myPuzzle
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_Picture = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.lab_time = new System.Windows.Forms.Label();
            this.radioyes = new System.Windows.Forms.RadioButton();
            this.radiono = new System.Windows.Forms.RadioButton();
            this.lab_isdifficult = new System.Windows.Forms.Label();
            this.lab_result = new System.Windows.Forms.Label();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Changepic = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_Originalpic = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_Picture);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label_start);
            this.splitContainer1.Panel2.Controls.Add(this.lab_time);
            this.splitContainer1.Panel2.Controls.Add(this.radioyes);
            this.splitContainer1.Panel2.Controls.Add(this.radiono);
            this.splitContainer1.Panel2.Controls.Add(this.lab_isdifficult);
            this.splitContainer1.Panel2.Controls.Add(this.lab_result);
            this.splitContainer1.Panel2.Controls.Add(this.NumericUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Reset);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Changepic);
            this.splitContainer1.Panel2.Controls.Add(this.btn_import);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Originalpic);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(919, 601);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnl_Picture
            // 
            this.pnl_Picture.AutoSize = true;
            this.pnl_Picture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Picture.Location = new System.Drawing.Point(0, 0);
            this.pnl_Picture.Name = "pnl_Picture";
            this.pnl_Picture.Size = new System.Drawing.Size(600, 601);
            this.pnl_Picture.TabIndex = 0;
            this.pnl_Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Picture_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "图形单边切割块数";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(75, 346);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(0, 12);
            this.label_start.TabIndex = 21;
            this.label_start.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Location = new System.Drawing.Point(66, 376);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(0, 12);
            this.lab_time.TabIndex = 20;
            // 
            // radioyes
            // 
            this.radioyes.AutoSize = true;
            this.radioyes.Location = new System.Drawing.Point(132, 486);
            this.radioyes.Name = "radioyes";
            this.radioyes.Size = new System.Drawing.Size(35, 16);
            this.radioyes.TabIndex = 19;
            this.radioyes.Text = "是";
            this.radioyes.UseVisualStyleBackColor = true;
            this.radioyes.CheckedChanged += new System.EventHandler(this.radioyes_CheckedChanged);
            // 
            // radiono
            // 
            this.radiono.AutoSize = true;
            this.radiono.Checked = true;
            this.radiono.Location = new System.Drawing.Point(68, 486);
            this.radiono.Name = "radiono";
            this.radiono.Size = new System.Drawing.Size(35, 16);
            this.radiono.TabIndex = 18;
            this.radiono.TabStop = true;
            this.radiono.Text = "否";
            this.radiono.UseVisualStyleBackColor = true;
            this.radiono.CheckedChanged += new System.EventHandler(this.radiono_CheckedChanged);
            // 
            // lab_isdifficult
            // 
            this.lab_isdifficult.AutoSize = true;
            this.lab_isdifficult.Location = new System.Drawing.Point(66, 450);
            this.lab_isdifficult.Name = "lab_isdifficult";
            this.lab_isdifficult.Size = new System.Drawing.Size(101, 12);
            this.lab_isdifficult.TabIndex = 17;
            this.lab_isdifficult.Text = "是否进入挑战模式";
            this.lab_isdifficult.Click += new System.EventHandler(this.lab_isdifficult_Click);
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Location = new System.Drawing.Point(56, 570);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(77, 12);
            this.lab_result.TabIndex = 5;
            this.lab_result.Text = "您未完成拼图";
            this.lab_result.Click += new System.EventHandler(this.label1_Click);
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.AutoSize = true;
            this.NumericUpDown1.Location = new System.Drawing.Point(185, 398);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.ReadOnly = true;
            this.NumericUpDown1.Size = new System.Drawing.Size(75, 21);
            this.NumericUpDown1.TabIndex = 4;
            this.NumericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // btn_Reset
            // 
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Reset.Location = new System.Drawing.Point(28, 273);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(221, 70);
            this.btn_Reset.TabIndex = 3;
            this.btn_Reset.Text = "图片重置";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Changepic
            // 
            this.btn_Changepic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Changepic.Location = new System.Drawing.Point(28, 186);
            this.btn_Changepic.Name = "btn_Changepic";
            this.btn_Changepic.Size = new System.Drawing.Size(221, 70);
            this.btn_Changepic.TabIndex = 2;
            this.btn_Changepic.Text = "切换新图";
            this.btn_Changepic.UseVisualStyleBackColor = true;
            this.btn_Changepic.Click += new System.EventHandler(this.btn_Changepic_Click);
            // 
            // btn_import
            // 
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_import.Location = new System.Drawing.Point(28, 100);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(221, 70);
            this.btn_import.TabIndex = 1;
            this.btn_import.Text = "试玩新图";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_Originalpic
            // 
            this.btn_Originalpic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Originalpic.Location = new System.Drawing.Point(28, 12);
            this.btn_Originalpic.Name = "btn_Originalpic";
            this.btn_Originalpic.Size = new System.Drawing.Size(221, 70);
            this.btn_Originalpic.TabIndex = 0;
            this.btn_Originalpic.Text = "查看原图";
            this.btn_Originalpic.UseVisualStyleBackColor = true;
            this.btn_Originalpic.Click += new System.EventHandler(this.btn_Originalpic_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 601);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "myPuzzle";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnl_Picture;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Changepic;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_Originalpic;
        private System.Windows.Forms.NumericUpDown NumericUpDown1;
        private System.Windows.Forms.Label lab_result;
        private System.Windows.Forms.RadioButton radioyes;
        private System.Windows.Forms.RadioButton radiono;
        private System.Windows.Forms.Label lab_isdifficult;
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.Label label_start;
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

