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

namespace IST_Pro_1.Presentation
{
    public partial class frmCountryNew : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmCountryNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;
            if(txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }

            if(er == 0)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = IST_Pro_1.Properties.Settings.Default.Connection;
                CN.Open();

                SqlCommand CMD = new SqlCommand();
                CMD.Connection = CN;
                CMD.CommandText = "insert into country(name) values(@name)";
                CMD.Parameters.AddWithValue("@name", txtName.Text);

                try
                {
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Data Saved");
                    txtName.Text = "";
                    txtName.Focus();
                 }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CN.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
