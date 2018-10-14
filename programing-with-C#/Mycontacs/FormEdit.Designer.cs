namespace Mycontacs
{
    partial class FormEdit
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
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelProfession = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.labelAdress = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textAge = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textProfession = new System.Windows.Forms.TextBox();
            this.labelBirth = new System.Windows.Forms.Label();
            this.textAdrees = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.textContactId = new System.Windows.Forms.TextBox();
            this.groupBorder = new System.Windows.Forms.GroupBox();
            this.groupBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.Location = new System.Drawing.Point(91, 119);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(197, 21);
            this.dateTimePickerBirth.TabIndex = 21;
            this.dateTimePickerBirth.Value = new System.DateTime(2017, 12, 20, 21, 51, 51, 0);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(412, 82);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 39);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(412, 28);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(86, 39);
            this.buttonUpdate.TabIndex = 19;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(170, 95);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(35, 16);
            this.radioFemale.TabIndex = 18;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "女";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(114, 95);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(35, 16);
            this.radioMale.TabIndex = 17;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "男";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(32, 95);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(53, 12);
            this.labelGender.TabIndex = 16;
            this.labelGender.Text = "学生性别";
            // 
            // labelProfession
            // 
            this.labelProfession.AutoSize = true;
            this.labelProfession.Location = new System.Drawing.Point(32, 267);
            this.labelProfession.Name = "labelProfession";
            this.labelProfession.Size = new System.Drawing.Size(53, 12);
            this.labelProfession.TabIndex = 15;
            this.labelProfession.Text = "专    业";
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(91, 173);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(197, 21);
            this.textPhone.TabIndex = 14;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Location = new System.Drawing.Point(32, 236);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(53, 12);
            this.labelAdress.TabIndex = 13;
            this.labelAdress.Text = "家庭住址";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(32, 203);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(53, 12);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "电子邮箱";
            // 
            // textAge
            // 
            this.textAge.Location = new System.Drawing.Point(91, 146);
            this.textAge.Name = "textAge";
            this.textAge.Size = new System.Drawing.Size(197, 21);
            this.textAge.TabIndex = 10;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(32, 176);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(53, 12);
            this.labelPhone.TabIndex = 9;
            this.labelPhone.Text = "手机号码";
            // 
            // textProfession
            // 
            this.textProfession.Location = new System.Drawing.Point(91, 227);
            this.textProfession.Name = "textProfession";
            this.textProfession.Size = new System.Drawing.Size(197, 21);
            this.textProfession.TabIndex = 8;
            this.textProfession.TextChanged += new System.EventHandler(this.textProfession_TextChanged);
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Location = new System.Drawing.Point(32, 122);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(53, 12);
            this.labelBirth.TabIndex = 7;
            this.labelBirth.Text = "出生日期";
            // 
            // textAdrees
            // 
            this.textAdrees.Location = new System.Drawing.Point(91, 264);
            this.textAdrees.Multiline = true;
            this.textAdrees.Name = "textAdrees";
            this.textAdrees.Size = new System.Drawing.Size(197, 23);
            this.textAdrees.TabIndex = 6;
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(32, 149);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(53, 12);
            this.labelAge.TabIndex = 5;
            this.labelAge.Text = "学生年龄";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(91, 200);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(197, 21);
            this.textEmail.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(32, 68);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "学生姓名";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(91, 65);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(197, 21);
            this.textName.TabIndex = 2;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(32, 41);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(53, 12);
            this.labelNumber.TabIndex = 1;
            this.labelNumber.Text = "学生编号";
            // 
            // textContactId
            // 
            this.textContactId.Location = new System.Drawing.Point(91, 38);
            this.textContactId.Name = "textContactId";
            this.textContactId.ReadOnly = true;
            this.textContactId.Size = new System.Drawing.Size(197, 21);
            this.textContactId.TabIndex = 0;
            // 
            // groupBorder
            // 
            this.groupBorder.Controls.Add(this.dateTimePickerBirth);
            this.groupBorder.Controls.Add(this.buttonCancel);
            this.groupBorder.Controls.Add(this.buttonUpdate);
            this.groupBorder.Controls.Add(this.radioFemale);
            this.groupBorder.Controls.Add(this.radioMale);
            this.groupBorder.Controls.Add(this.labelGender);
            this.groupBorder.Controls.Add(this.labelProfession);
            this.groupBorder.Controls.Add(this.textPhone);
            this.groupBorder.Controls.Add(this.labelAdress);
            this.groupBorder.Controls.Add(this.labelEmail);
            this.groupBorder.Controls.Add(this.textAge);
            this.groupBorder.Controls.Add(this.labelPhone);
            this.groupBorder.Controls.Add(this.textProfession);
            this.groupBorder.Controls.Add(this.labelBirth);
            this.groupBorder.Controls.Add(this.textAdrees);
            this.groupBorder.Controls.Add(this.labelAge);
            this.groupBorder.Controls.Add(this.textEmail);
            this.groupBorder.Controls.Add(this.labelName);
            this.groupBorder.Controls.Add(this.textName);
            this.groupBorder.Controls.Add(this.labelNumber);
            this.groupBorder.Controls.Add(this.textContactId);
            this.groupBorder.Location = new System.Drawing.Point(4, 0);
            this.groupBorder.Name = "groupBorder";
            this.groupBorder.Size = new System.Drawing.Size(531, 332);
            this.groupBorder.TabIndex = 3;
            this.groupBorder.TabStop = false;
            this.groupBorder.Text = "修改学生信息";
            this.groupBorder.Enter += new System.EventHandler(this.groupBorder_Enter);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 330);
            this.Controls.Add(this.groupBorder);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            this.groupBorder.ResumeLayout(false);
            this.groupBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelProfession;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textAge;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textProfession;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.TextBox textAdrees;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textContactId;
        private System.Windows.Forms.GroupBox groupBorder;
    }
}