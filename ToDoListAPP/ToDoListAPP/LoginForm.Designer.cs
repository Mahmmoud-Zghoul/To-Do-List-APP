namespace ToDoListAPP
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            btnLogin = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, 19);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "البريد الألكتروني";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(503, 90);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "كلمة السر";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(496, 170);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "الأسم الأول";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(494, 247);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "الأسم الأخير";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(227, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 23);
            txtEmail.TabIndex = 4;
            txtEmail.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(227, 282);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 23);
            txtLastName.TabIndex = 5;
            txtLastName.TextAlign = HorizontalAlignment.Right;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(227, 200);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(330, 23);
            txtFirstName.TabIndex = 6;
            txtFirstName.TextAlign = HorizontalAlignment.Right;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(227, 122);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(330, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(36, 352);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(135, 32);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "انشاء حساب جديد";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(339, 352);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(114, 32);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "تسجيل الدخول";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 320);
            label5.Name = "label5";
            label5.Size = new Size(168, 15);
            label5.TabIndex = 10;
            label5.Text = "مستخدم جديد؟ انشاء حساب جديد";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Form2";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtPassword;
        private Button btnRegister;
        private Button btnLogin;
        private Label label5;
    }
}