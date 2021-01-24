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
    public partial class ChangeInfoForm : Form
    {
        public String conString = @"Data Source=LAPTOP-GTKGDTGS\NIKITASERVER;Initial Catalog=Session1_10;Integrated Security=True";

        private SqlConnection connection;
        private DataSet dataSet;
        private SqlDataAdapter dataAdapter;

        public ChangeInfoForm()
        {
            InitializeComponent();

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
            try
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand($"SELECT Email FROM dbo.Users WHERE ID='{AdministratorForm.IDPersonToChange}'", connection);
                EmailBox.Text = command1.ExecuteScalar().ToString();
                SqlCommand command2 = new SqlCommand($"SELECT FirstName FROM dbo.Users WHERE ID='{AdministratorForm.IDPersonToChange}'", connection);
                FirstNameBox.Text = command2.ExecuteScalar().ToString();
                SqlCommand command3 = new SqlCommand($"SELECT LastName FROM dbo.Users WHERE ID='{AdministratorForm.IDPersonToChange}'", connection);
                LastNameBox.Text = command3.ExecuteScalar().ToString();
                SqlCommand command4 = new SqlCommand($"SELECT RoleID FROM dbo.Users WHERE ID='{AdministratorForm.IDPersonToChange}'", connection);
                if(Convert.ToInt32(command4.ExecuteScalar()) == 1)
                {
                    AdminRadio.Checked = true;
                }
                else
                {
                    UserRadio.Checked = true;
                }
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
    }
}
