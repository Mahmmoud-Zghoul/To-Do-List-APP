namespace ToDoListAPP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtTask = new TextBox();
            btnAddTask = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnRemoveTask = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lstTasksShow = new ListView();
            cmbCategory = new ComboBox();
            cmbPriority = new ComboBox();
            dtpDueDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogout = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTask
            // 
            txtTask.Location = new Point(513, 43);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(349, 23);
            txtTask.TabIndex = 0;
            txtTask.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(241, 43);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(188, 23);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "إضافة مهمة";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(255, 410);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 32);
            btnSave.TabIndex = 2;
            btnSave.Text = "حفظ المهام";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(740, 410);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(122, 32);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "تحميل المهام";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnRemoveTask
            // 
            btnRemoveTask.Location = new Point(513, 410);
            btnRemoveTask.Name = "btnRemoveTask";
            btnRemoveTask.Size = new Size(122, 32);
            btnRemoveTask.TabIndex = 4;
            btnRemoveTask.Text = "حذف المهمة المحددة";
            btnRemoveTask.UseVisualStyleBackColor = true;
            btnRemoveTask.Click += btnRemoveTask_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 458);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(884, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "جاهز...";
            // 
            // lstTasksShow
            // 
            lstTasksShow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstTasksShow.BorderStyle = BorderStyle.FixedSingle;
            lstTasksShow.CheckBoxes = true;
            lstTasksShow.FullRowSelect = true;
            lstTasksShow.LabelEdit = true;
            lstTasksShow.Location = new Point(12, 163);
            lstTasksShow.Name = "lstTasksShow";
            lstTasksShow.Size = new Size(850, 214);
            lstTasksShow.TabIndex = 6;
            lstTasksShow.UseCompatibleStateImageBehavior = false;
            lstTasksShow.View = View.Details;
            lstTasksShow.DoubleClick += lstTasksShow_DoubleClick;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "عملي", "دراسي", "شخصي", "أخرى" });
            cmbCategory.Location = new Point(295, 104);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 8;
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "عالية", "متوسطة", "منخفضة" });
            cmbPriority.Location = new Point(109, 107);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(121, 23);
            cmbPriority.TabIndex = 9;
            // 
            // dtpDueDate
            // 
            dtpDueDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpDueDate.Format = DateTimePickerFormat.Custom;
            dtpDueDate.Location = new Point(529, 104);
            dtpDueDate.MinDate = new DateTime(2025, 5, 18, 0, 0, 0, 0);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(200, 23);
            dtpDueDate.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(186, 86);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 11;
            label1.Text = "الأولوية";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 86);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 12;
            label2.Text = "التصنيف";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(637, 86);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 13;
            label3.Text = "تاريخ انجاز المهمة";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 410);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(122, 32);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "تسجيل الخروج";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 480);
            Controls.Add(btnLogout);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDueDate);
            Controls.Add(cmbPriority);
            Controls.Add(cmbCategory);
            Controls.Add(lstTasksShow);
            Controls.Add(statusStrip1);
            Controls.Add(btnRemoveTask);
            Controls.Add(btnAddTask);
            Controls.Add(txtTask);
            Name = "Form1";
            Text = "تطبيق المهام - ToDo List";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTask;
        private Button btnAddTask;
        private Button btnSave;
        private Button btnLoad;
        private Button btnRemoveTask;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ListView lstTasksShow;
        private ComboBox cmbCategory;
        private ComboBox cmbPriority;
        private DateTimePicker dtpDueDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnLogout;
    }
}