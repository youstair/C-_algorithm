namespace Mycontacs
{
    partial class FormAdd
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
            this.buttonAdd = new System.Windows.Forms.Button();
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
            this.dateTimePickerBirth.Value = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBirth.ValueChanged += new System.EventHandler(this.dateTimePickerBirth_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(342, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 39);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(342, 38);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(86, 39);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(170, 95);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(35, 16);
            this.radioFemale.TabIndex = 18;
            this.radioFemale.Text = "女";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Checked = true;
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
            this.labelProfession.Location = new System.Drawing.Point(32, 275);
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
            this.textProfession.Location = new System.Drawing.Point(91, 272);
            this.textProfession.Name = "textProfession";
            this.textProfession.Size = new System.Drawing.Size(197, 21);
            this.textProfession.TabIndex = 8;
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
            this.textAdrees.Location = new System.Drawing.Point(91, 233);
            this.textAdrees.Multiline = true;
            this.textAdrees.Name = "textAdrees";
            this.textAdrees.Size = new System.Drawing.Size(197, 25);
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
            this.textContactId.Size = new System.Drawing.Size(197, 21);
            this.textContactId.TabIndex = 0;
            // 
            // groupBorder
            // 
            this.groupBorder.Controls.Add(this.dateTimePickerBirth);
            this.groupBorder.Controls.Add(this.buttonCancel);
            this.groupBorder.Controls.Add(this.buttonAdd);
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
            this.groupBorder.Location = new System.Drawing.Point(2, 3);
            this.groupBorder.Name = "groupBorder";
            this.groupBorder.Size = new System.Drawing.Size(439, 441);
            this.groupBorder.TabIndex = 2;
            this.groupBorder.TabStop = false;
            this.groupBorder.Text = "添加学生信息";
            this.groupBorder.Enter += new System.EventHandler(this.groupBorder_Enter);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 456);
            this.Controls.Add(this.groupBorder);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.groupBorder.ResumeLayout(false);
            this.groupBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
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
        public System.Windows.Forms.TextBox textContactId;
        private System.Windows.Forms.GroupBox groupBorder;
    }
}