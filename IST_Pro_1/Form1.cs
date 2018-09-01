using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST_Pro_1
{
    public partial class Form1 : Form
    {
        Presentation.frmCountry country = new Presentation.frmCountry();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (country.IsDisposed)
                country = new Presentation.frmCountry();
            country.MdiParent = this;
            country.Show();
            country.BringToFront();
        }
    }
}
