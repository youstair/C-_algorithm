namespace SimpleMDIExample
{
    partial class FormDoc
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
            this.Doc_richTextBox = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // Doc_richTextBox
            // 
            this.Doc_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Doc_richTextBox.Location = new System.Drawing.Point(0, 0);
            this.Doc_richTextBox.Name = "Doc_richTextBox";
            this.Doc_richTextBox.Size = new System.Drawing.Size(869, 596);
            this.Doc_richTextBox.TabIndex = 0;
            this.Doc_richTextBox.Text = "";
            // 
            // FormDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 596);
            this.Controls.Add(this.Doc_richTextBox);
            this.Name = "FormDoc";
            this.Text = "FormDoc";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox Doc_richTextBox;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}