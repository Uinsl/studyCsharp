namespace bookMS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdBoxText = new System.Windows.Forms.ListBox();
            this.accBoxText = new System.Windows.Forms.ListBox();
            this.Login = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.radioBtnUser = new System.Windows.Forms.RadioButton();
            this.radioBtnAdmin = new System.Windows.Forms.RadioButton();
            this.accInput = new System.Windows.Forms.TextBox();
            this.pwdInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(207, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎图书馆里";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(212, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(213, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "password:";
            // 
            // pwdBoxText
            // 
            this.pwdBoxText.FormattingEnabled = true;
            this.pwdBoxText.ItemHeight = 15;
            this.pwdBoxText.Location = new System.Drawing.Point(375, 230);
            this.pwdBoxText.Name = "pwdBoxText";
            this.pwdBoxText.Size = new System.Drawing.Size(151, 34);
            this.pwdBoxText.TabIndex = 3;
            // 
            // accBoxText
            // 
            this.accBoxText.FormattingEnabled = true;
            this.accBoxText.ItemHeight = 15;
            this.accBoxText.Location = new System.Drawing.Point(375, 181);
            this.accBoxText.Name = "accBoxText";
            this.accBoxText.Size = new System.Drawing.Size(164, 34);
            this.accBoxText.TabIndex = 4;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(217, 330);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 5;
            this.Login.Text = "登录";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(398, 329);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // radioBtnUser
            // 
            this.radioBtnUser.AutoSize = true;
            this.radioBtnUser.Checked = true;
            this.radioBtnUser.Location = new System.Drawing.Point(217, 285);
            this.radioBtnUser.Name = "radioBtnUser";
            this.radioBtnUser.Size = new System.Drawing.Size(58, 19);
            this.radioBtnUser.TabIndex = 7;
            this.radioBtnUser.TabStop = true;
            this.radioBtnUser.Text = "用户";
            this.radioBtnUser.UseVisualStyleBackColor = true;
            // 
            // radioBtnAdmin
            // 
            this.radioBtnAdmin.AutoSize = true;
            this.radioBtnAdmin.Location = new System.Drawing.Point(375, 285);
            this.radioBtnAdmin.Name = "radioBtnAdmin";
            this.radioBtnAdmin.Size = new System.Drawing.Size(73, 19);
            this.radioBtnAdmin.TabIndex = 8;
            this.radioBtnAdmin.Text = "管理员";
            this.radioBtnAdmin.UseVisualStyleBackColor = true;
            // 
            // accInput
            // 
            this.accInput.Location = new System.Drawing.Point(594, 192);
            this.accInput.Name = "accInput";
            this.accInput.Size = new System.Drawing.Size(100, 25);
            this.accInput.TabIndex = 9;
            // 
            // pwdInput
            // 
            this.pwdInput.Location = new System.Drawing.Point(593, 238);
            this.pwdInput.Name = "pwdInput";
            this.pwdInput.Size = new System.Drawing.Size(100, 25);
            this.pwdInput.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pwdInput);
            this.Controls.Add(this.accInput);
            this.Controls.Add(this.radioBtnAdmin);
            this.Controls.Add(this.radioBtnUser);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.accBoxText);
            this.Controls.Add(this.pwdBoxText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox pwdBoxText;
        private System.Windows.Forms.ListBox accBoxText;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RadioButton radioBtnUser;
        private System.Windows.Forms.RadioButton radioBtnAdmin;
        private System.Windows.Forms.TextBox accInput;
        private System.Windows.Forms.TextBox pwdInput;
    }
}

