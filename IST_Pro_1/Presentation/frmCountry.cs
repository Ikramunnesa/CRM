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
    public partial class frmCountry : Form
    {
        public frmCountry()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCountryNew countryNew = new frmCountryNew();
            countryNew.ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = IST_Pro_1.Properties.Settings.Default.Connection;
            CN.Open();

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = CN;
            CMD.CommandText = "select id, name from country";

            if(txtSearch.Text != "")
            {
                CMD.CommandText += " where name like @name";
                CMD.Parameters.AddWithValue("@name", "%" +txtSearch.Text + "%");
            }


            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DA.Fill(DS);
            CN.Close();

            dgvData.DataSource = DS.Tables[0];
        }
    }
}
