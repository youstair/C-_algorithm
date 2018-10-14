namespace Mycontacs
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripBackUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripRestore = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("等线", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(983, 585);
            this.dataGridView1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripDelete,
            this.toolStripSearch,
            this.toolStripEdit,
            this.toolStripBackUp,
            this.toolStripRestore});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(60, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(983, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.AutoSize = false;
            this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
            this.toolStripAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(50, 50);
            this.toolStripAdd.Text = "添加";
            this.toolStripAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.AutoSize = false;
            this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
            this.toolStripDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(50, 50);
            this.toolStripDelete.Text = "删除";
            this.toolStripDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.AutoSize = false;
            this.toolStripSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSearch.Image")));
            this.toolStripSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(50, 50);
            this.toolStripSearch.Text = "查找";
            this.toolStripSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripSearch.Click += new System.EventHandler(this.toolStripSearch_Click);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.AutoSize = false;
            this.toolStripEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEdit.Image")));
            this.toolStripEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Size = new System.Drawing.Size(50, 50);
            this.toolStripEdit.Text = "编辑";
            this.toolStripEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripEdit.Click += new System.EventHandler(this.toolStripEdit_Click);
            // 
            // toolStripBackUp
            // 
            this.toolStripBackUp.AutoSize = false;
            this.toolStripBackUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBackUp.Image")));
            this.toolStripBackUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBackUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBackUp.Name = "toolStripBackUp";
            this.toolStripBackUp.Size = new System.Drawing.Size(50, 50);
            this.toolStripBackUp.Text = "备份";
            this.toolStripBackUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripBackUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBackUp.Click += new System.EventHandler(this.toolStripBackUp_Click);
            // 
            // toolStripRestore
            // 
            this.toolStripRestore.AutoSize = false;
            this.toolStripRestore.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRestore.Image")));
            this.toolStripRestore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRestore.Name = "toolStripRestore";
            this.toolStripRestore.Size = new System.Drawing.Size(50, 50);
            this.toolStripRestore.Text = "恢复";
            this.toolStripRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripRestore.Click += new System.EventHandler(this.toolStripRestore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 635);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripSearch;
        private System.Windows.Forms.ToolStripButton toolStripEdit;
        private System.Windows.Forms.ToolStripButton toolStripBackUp;
        private System.Windows.Forms.ToolStripButton toolStripRestore;
    }
}

