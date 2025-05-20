﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ToDoListAPP
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=.;Database=ToDoList_db;Trusted_Connection=True;";
        private int userId; // متغير لتخزين Id المستخدم اللي سجل الدخول
        private string userName; // متغير لتخزين اسم المستخدم

        public Form1(int userId, string firstName, string lastName) // تم تعديل الكونستركتور
        {
            InitializeComponent();
            this.userId = userId; // استقبل Id المستخدم
            this.userName = firstName + " " + lastName; // استقبل الاسم الأول والأخير
            CustomizeUI(); // استدعاء التخصيصات
        }

        public Form1()
        {
            InitializeComponent();
            CustomizeUI();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomizeUI();
            FillCategoryComboBox(); // تعبئة التصنيفات
            FillPriorityComboBox();
            LoadUserTasks(); // قم بتحميل المهام الخاصة بالمستخدم عند تحميل النموذج
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text))
            {
                MessageBox.Show("يرجى إدخال مهمة أولاً.", "تنبيه");
                return;
            }

            string taskText = txtTask.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString();
            string priority = cmbPriority.SelectedItem?.ToString();
            DateTime dueDate = dtpDueDate.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Tasks_t (Description, IsCompleted, Category, Priority, DueDate, UserId) " + // تم إضافة UserId
                                   "VALUES (@desc, 0, @cat, @pri, @due, @userId); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@desc", taskText);
                        cmd.Parameters.AddWithValue("@cat", category ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pri", priority ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@due", dueDate);
                        cmd.Parameters.AddWithValue("@userId", userId); // استخدم userId اللي استقبلناه
                        int insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                        // أضف المهمة إلى ListView
                        var item = new ListViewItem(taskText);
                        item.Tag = insertedId;
                        item.Checked = false;
                        item.SubItems.Add(category);
                        item.SubItems.Add(priority);
                        item.SubItems.Add(dueDate.ToShortDateString());
                        lstTasksShow.Items.Add(item);
                    }
                }

                txtTask.Clear();
                cmbCategory.SelectedIndex = -1;
                cmbPriority.SelectedIndex = -1;
                dtpDueDate.Value = DateTime.Now;
                toolStripStatusLabel1.Text = "✅ تم إضافة المهمة وحفظها في قاعدة البيانات!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ المهمة: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadUserTasks();
        }

        private void LoadUserTasks()
        {
            lstTasksShow.Items.Clear();
            lstTasksShow.Columns.Clear();
            lstTasksShow.Columns.Add("المهمة", 300);
            lstTasksShow.Columns.Add("التصنيف", 100);
            lstTasksShow.Columns.Add("الأولوية", 100);
            lstTasksShow.Columns.Add("تاريخ الاستحقاق", 150);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // جلب المهام الخاصة بالمستخدم فقط
                    string query = "SELECT Id, Description, IsCompleted, Category, Priority, DueDate FROM Tasks_t WHERE UserId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId); // استخدم userId
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["Id"];
                                string description = reader["Description"].ToString();
                                bool isCompleted = Convert.ToBoolean(reader["IsCompleted"]);
                                string category = reader["Category"] == DBNull.Value ? "" : reader["Category"].ToString();
                                string priority = reader["Priority"] == DBNull.Value ? "" : reader["Priority"].ToString();
                                DateTime dueDate = reader["DueDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["DueDate"];

                                var item = new ListViewItem(description);
                                item.Tag = id;
                                item.Checked = isCompleted;
                                item.SubItems.Add(category);
                                item.SubItems.Add(priority);
                                item.SubItems.Add(dueDate.ToShortDateString());
                                lstTasksShow.Items.Add(item);
                            }
                        }
                    }
                }

                toolStripStatusLabel1.Text = "✅ تم تحميل المهام من قاعدة البيانات!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المهام: " + ex.Message);
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasksShow.SelectedItems.Count == 0)
            {
                MessageBox.Show("يرجى تحديد مهمة لحذفها.", "تنبيه");
                return;
            }

            var item = lstTasksShow.SelectedItems[0];
            int taskId = (int)item.Tag;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // حذف المهمة الخاصة بالمستخدم فقط
                    string query = "DELETE FROM Tasks_t WHERE Id = @id AND UserId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);
                        cmd.Parameters.AddWithValue("@userId", userId); // استخدم userId
                        cmd.ExecuteNonQuery();
                    }
                }

                lstTasksShow.Items.Remove(item);
                toolStripStatusLabel1.Text = "✅ تم حذف المهمة.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حذف المهمة: " + ex.Message);
            }
        }

        private void lstTasksShow_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasksShow.SelectedItems.Count == 0) return;

            ListViewItem item = lstTasksShow.SelectedItems[0];
            string currentText = item.Text;

            string newText = Microsoft.VisualBasic.Interaction.InputBox(
                "قم بتعديل وصف المهمة:",
                "تعديل المهمة",
                currentText);

            if (!string.IsNullOrWhiteSpace(newText) && newText != currentText)
            {
                item.Text = newText.Trim();
                toolStripStatusLabel1.Text = "📝 تم تعديل وصف المهمة مؤقتًا، اضغط حفظ لتأكيد التعديلات.";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (ListViewItem item in lstTasksShow.Items)
                    {
                        if (item.Tag == null) continue;

                        int taskId = (int)item.Tag;
                        bool isChecked = item.Checked;
                        string newDescription = item.Text.Trim();
                        string category = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
                        string priority = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";
                        DateTime dueDate = item.SubItems.Count > 3 && DateTime.TryParse(item.SubItems[3].Text, out DateTime parsedDate) ? parsedDate : DateTime.Now;

                        // تحديث المهمة الخاصة بالمستخدم فقط
                        string updateQuery = "UPDATE Tasks_t SET IsCompleted = @isCompleted, Description = @desc, " +
                                             "Category = @cat, Priority = @pri, DueDate = @due WHERE Id = @id AND UserId = @userId";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@isCompleted", isChecked ? 1 : 0);
                            cmd.Parameters.AddWithValue("@desc", newDescription);
                            cmd.Parameters.AddWithValue("@cat", category == "" ? (object)DBNull.Value : category);
                            cmd.Parameters.AddWithValue("@pri", priority == "" ? (object)DBNull.Value : priority);
                            cmd.Parameters.AddWithValue("@due", dueDate);
                            cmd.Parameters.AddWithValue("@id", taskId);
                            cmd.Parameters.AddWithValue("@userId", userId); // استخدم userId
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // إعادة تحميل القائمة بعد الحفظ
                LoadUserTasks();
                toolStripStatusLabel1.Text = "✅ تم حفظ التعديلات بنجاح!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ التعديلات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("هل تريد تسجيل الخروج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }


  


        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void CustomizeUI()
        {
            this.BackColor = Color.LightSteelBlue;

            txtTask.BackColor = Color.WhiteSmoke;
            txtTask.ForeColor = Color.DarkSlateGray;
            txtTask.Font = new Font("Segoe UI", 10);

            StyleButton(btnAddTask, Color.MediumSeaGreen);
            StyleButton(btnRemoveTask, Color.IndianRed);
            StyleButton(btnSave, Color.SteelBlue);
            StyleButton(btnLoad, Color.Goldenrod);
            StyleButton(btnLogout, Color.DarkSlateGray);

            statusStrip1.BackColor = Color.WhiteSmoke;
            toolStripStatusLabel1.ForeColor = Color.DarkSlateGray;

            lstTasksShow.BackColor = Color.White;
            lstTasksShow.ForeColor = Color.DarkSlateGray;
            lstTasksShow.Font = new Font("Segoe UI", 10);
            lstTasksShow.View = View.Details;
            lstTasksShow.CheckBoxes = true;

            if (lstTasksShow.Columns.Count == 0)
            {
                lstTasksShow.Columns.Add("المهمة", 300);
                lstTasksShow.Columns.Add("التصنيف", 100);
                lstTasksShow.Columns.Add("الأولوية", 100);
                lstTasksShow.Columns.Add("تاريخ الاستحقاق", 150);
            }

            lstTasksShow.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstTasksShow.FullRowSelect = true;
            lstTasksShow.MultiSelect = false;

            dtpDueDate.ShowUpDown = true;

            this.Text = "To-Do List App";
            toolStripStatusLabel1.Text = $"مرحبًا، {userName}! 👋";

        }

        private void FillCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("شخصي");
            cmbCategory.Items.Add("دراسة");
            cmbCategory.Items.Add("عمل");
            cmbCategory.Items.Add("أخرى");
            cmbCategory.SelectedIndex = 0; // اختيار أول عنصر تلقائيًا
        }

        private void FillPriorityComboBox()
        {
            cmbPriority.Items.Clear();
            cmbPriority.Items.Add("عالية");
            cmbPriority.Items.Add("متوسطة");
            cmbPriority.Items.Add("منخفضة");
            cmbPriority.SelectedIndex = 1; // اختيار "متوسطة" كقيمة افتراضية
        }





    }
}


   