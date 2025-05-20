using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ToDoListAPP
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Server=.;Database=ToDoList_db;Trusted_Connection=True;";

        public LoginForm()
        {
            InitializeComponent();
            CustomizeUI();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CustomizeUI();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("يرجى إدخال البريد الإلكتروني وكلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // توليد هاش لكلمة المرور
                    string hashedPassword = HashPassword(password);

                    string query = "SELECT Id, FirstName, LastName FROM Users_t WHERE Email = @email AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = (int)reader["Id"];
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();

                                // ✅ إخفاء الفورم الحالي ثم فتح Form1 كنافذة رئيسية (مؤقتة) ثم إغلاق LoginForm بعد الانتهاء
                                this.Hide();
                                Form1 form1 = new Form1(userId, firstName, lastName);
                                form1.ShowDialog(); // إبقاء التطبيق مفتوح ما دام Form1 يعمل
                                this.Close(); // عند إغلاق Form1، يغلق LoginForm وتنتهي الجلسة
                            }
                            else
                            {
                                MessageBox.Show("البريد الإلكتروني أو كلمة المرور غير صحيحة.", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تسجيل الدخول: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // دالة لمسح الحقول بعد التسجيل
        private void ClearInputFields()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }

        // دالة لتشفير كلمة المرور باستخدام SHA256 (مهم جداً للأمان)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // تحويل البايت إلى سلسلة نصية سداسية عشرية
                }
                return sb.ToString();
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

            // لون الخلفية
            txtEmail.BackColor = Color.WhiteSmoke;
            txtPassword.BackColor = Color.WhiteSmoke;
            txtFirstName.BackColor = Color.WhiteSmoke;
            txtLastName.BackColor = Color.WhiteSmoke;

            // لون الخط
            txtEmail.ForeColor = Color.DarkSlateGray;
            txtPassword.ForeColor = Color.DarkSlateGray;
            txtFirstName.ForeColor = Color.DarkSlateGray;
            txtLastName.ForeColor = Color.DarkSlateGray;

            // الخط
            txtEmail.Font = new Font("Segoe UI", 10);
            txtPassword.Font = new Font("Segoe UI", 10);
            txtFirstName.Font = new Font("Segoe UI", 10);
            txtLastName.Font = new Font("Segoe UI", 10);

            // تخصيص الأزرار
            StyleButton(btnLogin, Color.MediumSeaGreen);
            StyleButton(btnRegister, Color.SteelBlue);

            // عناوين الحقول
            label1.ForeColor = Color.DarkSlateGray;
            label2.ForeColor = Color.DarkSlateGray;
            label3.ForeColor = Color.DarkSlateGray;
            label4.ForeColor = Color.DarkSlateGray;

            this.Text = "تسجيل الدخول / تسجيل حساب"; // عنوان النموذج
        }

      
        private void btnRegister_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("يرجى إدخال البريد الإلكتروني وكلمة المرور.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // استخدام دالة Hash لتأمين كلمة المرور قبل تخزينها في قاعدة البيانات
                    string hashedPassword = HashPassword(password);

                    string query = "INSERT INTO Users_t (Email, Password, FirstName, LastName) VALUES (@email, @password, @firstName, @lastName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", hashedPassword); // تخزين الـ Hash
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("تم التسجيل بنجاح. يمكنك تسجيل الدخول الآن.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields(); // دالة لمسح الحقول بعد التسجيل الناجح
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التسجيل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
