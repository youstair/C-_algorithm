namespace Mycontacs
{
    partial class FormSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.textBox_Searchtext = new System.Windows.Forms.TextBox();
            this.label_Search = new System.Windows.Forms.Label();
            this.cB_Search_Item = new System.Windows.Forms.ComboBox();
            this.dGV_Search = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Location = new System.Drawing.Point(666, 9);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(585, 9);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 32);
            this.btn_search.TabIndex = 12;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // textBox_Searchtext
            // 
            this.textBox_Searchtext.Location = new System.Drawing.Point(262, 16);
            this.textBox_Searchtext.Name = "textBox_Searchtext";
            this.textBox_Searchtext.Size = new System.Drawing.Size(317, 21);
            this.textBox_Searchtext.TabIndex = 11;
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Location = new System.Drawing.Point(76, 19);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(53, 12);
            this.label_Search.TabIndex = 10;
            this.label_Search.Text = "查找项目";
            // 
            // cB_Search_Item
            // 
            this.cB_Search_Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Search_Item.FormattingEnabled = true;
            this.cB_Search_Item.Items.AddRange(new object[] {
            "学生编号",
            "学生姓名"});
            this.cB_Search_Item.Location = new System.Drawing.Point(135, 17);
            this.cB_Search_Item.Name = "cB_Search_Item";
            this.cB_Search_Item.Size = new System.Drawing.Size(121, 20);
            this.cB_Search_Item.TabIndex = 9;
            // 
            // dGV_Search
            // 
            this.dGV_Search.AllowUserToOrderColumns = true;
            this.dGV_Search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_Search.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dGV_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_Search.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("等线", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_Search.DefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_Search.GridColor = System.Drawing.SystemColors.Control;
            this.dGV_Search.Location = new System.Drawing.Point(12, 47);
            this.dGV_Search.Name = "dGV_Search";
            this.dGV_Search.ReadOnly = true;
            this.dGV_Search.RowHeadersVisible = false;
            this.dGV_Search.RowTemplate.Height = 23;
            this.dGV_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_Search.Size = new System.Drawing.Size(1100, 521);
            this.dGV_Search.TabIndex = 8;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 566);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.textBox_Searchtext);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.cB_Search_Item);
            this.Controls.Add(this.dGV_Search);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox textBox_Searchtext;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.ComboBox cB_Search_Item;
        private System.Windows.Forms.DataGridView dGV_Search;
    }
}