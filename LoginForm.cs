using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLines
{
    public partial class LoginForm : Form
    {

        public String conString = @"Data Source=LAPTOP-GTKGDTGS\NIKITASERVER;Initial Catalog=Session1_10;Integrated Security=True";

        private SqlConnection connection;
        public LoginForm()
        {
            InitializeComponent();
        }

        int loginStatus = 0;
        int totalSeconds = 10;
        public static int currentUserID;
        public static int currentSessionID;
        public static DateTime currentSessionStartTime;
        private void LoginButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT ID FROM dbo.Users WHERE Email = '{UsernameBox.Text}'", connection);
                SqlCommand command2 = new SqlCommand($"SELECT ID FROM dbo.Users WHERE Password = '{PasswordBox.Text}'", connection);
                int i = Convert.ToInt32(command.ExecuteScalar());
                int j = Convert.ToInt32(command2.ExecuteScalar());
                if (i == 0 || j == 0 || (i != j))
                {
                    MessageBox.Show("Username or password is wrong!");
                    loginStatus += 1;
                }
                else
                {
                    SqlCommand command3 = new SqlCommand($"SELECT Active FROM dbo.Users WHERE Email = '{UsernameBox.Text}'", connection);
                    SqlCommand command4 = new SqlCommand($"SELECT ID FROM dbo.Users WHERE Email = '{UsernameBox.Text}'", connection);
                    currentUserID = Convert.ToInt32(command4.ExecuteScalar());
                    int k = Convert.ToInt32(command3.ExecuteScalar());
                    if (k != 0)
                    {
                        SqlCommand command5 = new SqlCommand($"SELECT RoleID FROM dbo.Users WHERE Email = '{UsernameBox.Text}'", connection);
                        int IDRole = Convert.ToInt32(command5.ExecuteScalar());
                        if (IDRole == 1)
                        {
                            SqlCommand command6 = new SqlCommand($"SELECT COUNT (*) FROM dbo.Sessions", connection);
                            int id = Convert.ToInt32(command6.ExecuteScalar()) + 1;
                            
                            SqlCommand command7 = new SqlCommand(String.Format("INSERT INTO dbo.Sessions (ID, UserID, SessionDate, LoginTime) VALUES ('{0}', '{1}', '{2}', '{3}')", id, currentUserID, DateTime.Today.ToString(), DateTime.Now.ToString("HH:mm:ss")), connection);
                            command7.ExecuteNonQuery();
                            
                            SqlCommand command8 = new SqlCommand($"SELECT MAX(ID) FROM dbo.Sessions", connection);
                            currentSessionID = Convert.ToInt32(command8.ExecuteScalar());
                            
                            SqlCommand command9 = new SqlCommand($"SELECT LoginTime FROM dbo.Sessions WHERE ID={currentSessionID}", connection);
                            currentSessionStartTime = DateTime.Parse(command9.ExecuteScalar().ToString());

                            this.Hide();
                            AdministratorForm administratorForm = new AdministratorForm();
                            administratorForm.Show();
                            
                        }
                        if (IDRole == 2)
                        {
                            SqlCommand command6 = new SqlCommand($"SELECT COUNT (*) FROM dbo.Sessions", connection);
                            int id = Convert.ToInt32(command6.ExecuteScalar()) + 1;

                            SqlCommand command7 = new SqlCommand(String.Format("INSERT INTO dbo.Sessions (ID, UserID, SessionDate, LoginTime) VALUES ('{0}', '{1}', '{2}', '{3}')", id, currentUserID, DateTime.Today.ToString(), DateTime.Now.ToString("HH:mm:ss")), connection);
                            command7.ExecuteNonQuery();

                            SqlCommand command8 = new SqlCommand($"SELECT MAX(ID) FROM dbo.Sessions", connection);
                            currentSessionID = Convert.ToInt32(command8.ExecuteScalar());

                            SqlCommand command9 = new SqlCommand($"SELECT LoginTime FROM dbo.Sessions WHERE ID={currentSessionID}", connection);
                            currentSessionStartTime = DateTime.Parse(command9.ExecuteScalar().ToString());

                            this.Hide();
                            UserForm userForm = new UserForm();
                            userForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Administrator block you!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if (loginStatus >= 3)
            {
                timer1.Enabled = true;
                LoginButton.Enabled = false;
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private int _ticks;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                if (totalSeconds > 9)
                {
                    label3.Text = "00:" + totalSeconds.ToString();
                }
                else
                {
                    label3.Text = "00:0" + totalSeconds.ToString();
                }
                totalSeconds--;
            }
            else
            {
                timer1.Stop();
                LoginButton.Enabled = true;
                label3.Visible = false;
                label4.Visible = false;
                totalSeconds = 10;
                loginStatus = 0;
            }
        }
    }
}
