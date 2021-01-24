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
    public partial class AddUserForm : Form
    {

        public String conString = @"Data Source=LAPTOP-GTKGDTGS\NIKITASERVER;Initial Catalog=Session1_10;Integrated Security=True";

        private SqlConnection connection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;
        public AddUserForm()
        {
            InitializeComponent();
            birthDatePicker.MaxDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);

            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM dbo.Offices", connection);
                dataSet = new DataSet();
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
            OfficesComboBox.DataSource = dataSet.Tables["dbo.Offices"];
            OfficesComboBox.DisplayMember = "Title";
            OfficesComboBox.ValueMember = "ID";

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
            label1.Font = new Font(font.Families[0], 8);
            label2.Font = new Font(font.Families[0], 8);
            label3.Font = new Font(font.Families[0], 8);
            label4.Font = new Font(font.Families[0], 8);
            label5.Font = new Font(font.Families[0], 8);
            label6.Font = new Font(font.Families[0], 8);
            EmailBox.Font = new Font(font.Families[0], 8);
            FirstNameBox.Font = new Font(font.Families[0], 8);
            LastNameBox.Font = new Font(font.Families[0], 8);
            PasswordBox.Font = new Font(font.Families[0], 8);
            birthDatePicker.Font = new Font(font.Families[0], 8);
            OfficesComboBox.Font = new Font(font.Families[0], 8);
            SaveButton.Font = new Font(font.Families[0], 8);
            CancelButton.Font = new Font(font.Families[0], 8);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool allCool = true;
            if (EmailBox.Text.Length < 5 || string.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Login is bad");
                allCool = false;
            }
            if (PasswordBox.Text.Length < 3 || PasswordBox.Text.Length > 25 || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Password is bad");
                allCool = false;
            }
            if (FirstNameBox.Text.Length < 2 || FirstNameBox.Text.Length > 20 || string.IsNullOrEmpty(FirstNameBox.Text))
            {
                MessageBox.Show("Name is bad");
                allCool = false;
            }
            if (LastNameBox.Text.Length < 2 || LastNameBox.Text.Length > 30 || string.IsNullOrEmpty(LastNameBox.Text))
            {
                MessageBox.Show("Surname is bad");
                allCool = false;
            }

            for (int i = 0; i < FirstNameBox.Text.Length; i++)
            {
                if (char.IsDigit(FirstNameBox.Text[i]))
                {
                    MessageBox.Show("No digits in Name");
                    allCool = false;
                }
            }
            for (int i = 0; i < LastNameBox.Text.Length; i++)
            {
                if (char.IsDigit(LastNameBox.Text[i]))
                {
                    MessageBox.Show("No digits in Surname");
                    allCool = false;
                }
            }

            connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM dbo.Users WHERE Email = '{EmailBox.Text}'", connection);
                SqlCommand command2 = new SqlCommand($"SELECT COUNT(*) FROM dbo.Users WHERE Password = '{PasswordBox.Text}'", connection);
                int i = Convert.ToInt32(command.ExecuteScalar());
                int j = Convert.ToInt32(command2.ExecuteScalar());

                if (i != 0)
                {
                    MessageBox.Show("That email is used already");
                }
                if (j != 0)
                {
                    MessageBox.Show("That email is used already");
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

            if (allCool == true)
            {
                connection = new SqlConnection(conString);
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand($"SELECT COUNT (*) FROM dbo.Users", connection);
                    int id = Convert.ToInt32(command1.ExecuteScalar()) + 1;
                    SqlCommand command2 = new SqlCommand(String.Format("INSERT INTO dbo.Users (ID, RoleID, Email, Password, FirstName, LastName, OfficeID, Birthdate, Active) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", id, 2, EmailBox.Text, PasswordBox.Text, FirstNameBox.Text, LastNameBox.Text, Convert.ToInt32(OfficesComboBox.SelectedValue), birthDatePicker.Value, 1), connection);
                    command2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
