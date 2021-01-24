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
    public partial class UserForm : Form
    {
        public String conString = @"Data Source=LAPTOP-GTKGDTGS\NIKITASERVER;Initial Catalog=Session1_10;Integrated Security=True";

        private SqlConnection connection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;
        public UserForm()
        {
            InitializeComponent();
        }

        private void GetTables()
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"SELECT ID, SessionDate, LoginTime, LogoutTime, TimeSpent FROM dbo.Sessions WHERE UserID LIKE '%{LoginForm.currentUserID}%'", connection);
                dataSet = new DataSet();
                DataTable dt = dataSet.Tables.Add("dbo.Sessions");
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dataSet.Tables["dbo.Sessions"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    SqlCommand command = new SqlCommand($"SELECT LogoutTime FROM dbo.Sessions WHERE ID='{ID}'", connection);
                    string k = command.ExecuteScalar().ToString();
                    if (string.IsNullOrEmpty(k) && i != dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
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
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                string startTime = LoginForm.currentSessionStartTime.ToString("HH:mm:ss");
                string endTime = DateTime.Now.ToString("HH:mm:ss");

                TimeSpan timeSpan = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                SqlCommand command1 = new SqlCommand(String.Format("UPDATE dbo.Sessions SET LogoutTime='{0}', TimeSpent='{1}' WHERE ID={2}", DateTime.Now.ToString("HH:mm:ss"), timeSpan, LoginForm.currentSessionID), connection);
                command1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Application.Exit();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            GetTables();
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT FirstName FROM dbo.Users WHERE ID='{LoginForm.currentUserID}'", connection);
                string name = command.ExecuteScalar().ToString();

                SqlCommand command2 = new SqlCommand($"SELECT COUNT(*) FROM dbo.Sessions WHERE LogoutTime IS NULL AND UserID LIKE '%{LoginForm.currentUserID}%'", connection);
                int i = Convert.ToInt32(command2.ExecuteScalar()) - 1;

                HelloLabel.Text = $"Hi, {name}. Welcome to AMONIC Airlines Automation System";
                CrashLabel.Text = $"Number of crushes: {i}";
                TimeUpdater();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        private void TimeLable_Click(object sender, EventArgs e)
        {
            TimeUpdater();
        }

        private void TimeUpdater()
        {
            string startTime = LoginForm.currentSessionStartTime.ToString("HH:mm:ss");
            string endTime = DateTime.Now.ToString("HH:mm:ss");

            TimeSpan timeSpan = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            TimeLable.Text = $"Time spent on system: {timeSpan}. Click to update";
        }
    }
}
