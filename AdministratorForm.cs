using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLines
{
    public partial class AdministratorForm : Form
    {
        public String conString = @"Data Source=LAPTOP-GTKGDTGS\NIKITASERVER;Initial Catalog=Session1_10;Integrated Security=True";

        private SqlConnection connection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;

        public AdministratorForm()
        {
            InitializeComponent();
            FontsInProject();
            ApplyFonts();
        }
        PrivateFontCollection font;
        private void FontsInProject()
        {
            this.font = new PrivateFontCollection();
            this.font.AddFontFile("Fonts/TeXGyreAdventor-Regular.ttf");
        }
        private void ApplyFonts()
        {
            AddUserButton.Font = new Font(font.Families[0], 8);
            ExitButton.Font = new Font(font.Families[0], 8);
            label1.Font = new Font(font.Families[0], 8);
            OfficesComboBox.Font = new Font(font.Families[0], 8);
            AcceptButton.Font = new Font(font.Families[0], 8);
            ClearButton.Font = new Font(font.Families[0], 8);
            UpdateDBButton.Font = new Font(font.Families[0], 8);
            dataGridView1.Font = new Font(font.Families[0], 8);
            ChangeButton.Font = new Font(font.Families[0], 8);
            EnaDisButton.Font = new Font(font.Families[0], 8);
            //UsernameLabel.Font = new Font(font.Families[0], 8);
            //PasswordLabel.Font = new Font(font.Families[0], 8);
            //UsernameBox.Font = new Font(font.Families[0], 8);
            //PasswordBox.Font = new Font(font.Families[0], 8);
            //LoginButton.Font = new Font(font.Families[0], 8);
            //ExitButton.Font = new Font(font.Families[0], 8);
            //label3.Font = new Font(font.Families[0], 8);
            //label4.Font = new Font(font.Families[0], 8);
        }

        private void GetTables()
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT (FirstName + ' ' + LastName) AS FullName, YEAR(GETDATE())-YEAR(Birthdate) AS Age, Email, dbo.Roles.Title AS Role, dbo.Offices.Title AS Office FROM dbo.Users INNER JOIN dbo.Roles ON dbo.Users.RoleID = dbo.Roles.ID INNER JOIN dbo.Offices ON dbo.Users.OfficeID = dbo.Offices.ID", connection);
                dataSet = new DataSet();
                DataTable dt = dataSet.Tables.Add("dbo.Users");
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dataSet.Tables["dbo.Users"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string email = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    SqlCommand command = new SqlCommand($"SELECT Active FROM dbo.Users WHERE Email='{email}'", connection);
                    int k = Convert.ToInt32(command.ExecuteScalar());
                    if (k == 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
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

            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Offices", connection);
                DataTable dt = dataSet.Tables.Add("dbo.Offices");
                dataAdapter.Fill(dt);
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

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            GetTables();
            OfficesComboBox.DataSource = dataSet.Tables["dbo.Offices"];
            OfficesComboBox.DisplayMember = "Title";
            OfficesComboBox.ValueMember = "ID";
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter($"SELECT (FirstName + ' ' + LastName) AS FullName, YEAR(GETDATE())-YEAR(Birthdate) AS Age, Email, dbo.Roles.Title AS Role, dbo.Offices.Title AS Office FROM dbo.Users INNER JOIN dbo.Roles ON dbo.Users.RoleID = dbo.Roles.ID INNER JOIN dbo.Offices ON dbo.Users.OfficeID = dbo.Offices.ID WHERE dbo.Offices.Title LIKE '%{OfficesComboBox.Text}%'", connection);
                DataTable dt = dataSet.Tables["dbo.Users"];
                dt.Rows.Clear();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dataSet.Tables["dbo.Users"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string email = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    SqlCommand command = new SqlCommand($"SELECT Active FROM dbo.Users WHERE Email='{email}'", connection);
                    int k = Convert.ToInt32(command.ExecuteScalar());
                    if (k == 0)
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            GetTables();
        }

        private void EnaDisButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                string email = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                SqlCommand command = new SqlCommand($"SELECT Active FROM dbo.Users WHERE Email='{email}'", connection);
                byte k = Convert.ToByte(command.ExecuteScalar());
                if (k == 0)
                {
                    k = 1;
                }
                else
                {
                    k = 0;
                }
                SqlCommand command1 = new SqlCommand(String.Format("UPDATE dbo.Users SET Active='{0}' WHERE Email='{1}'", k, email), connection);
                command1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                GetTables();
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();
            form.Show();
        }
        public static int IDPersonToChange;
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                string email = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                SqlCommand command = new SqlCommand($"SELECT ID FROM dbo.Users WHERE Email='{email}'", connection);
                IDPersonToChange = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            ChangeInfoForm form = new ChangeInfoForm();
            form.Show();
        }

        private void UpdateDBButton_Click(object sender, EventArgs e)
        {
            GetTables();
        }
    }
}
