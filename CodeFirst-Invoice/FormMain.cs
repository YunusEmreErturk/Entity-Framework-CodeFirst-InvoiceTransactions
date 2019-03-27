using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormCities frm = new FormCities();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormUnits frm = new FormUnits();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormProducts frm = new FormProducts();
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormCounties frm = new FormCounties();
            frm.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomers frm = new FormCustomers();
            frm.Show();
        }

        private void createNewInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoiceHeaders frm = new FormInvoiceHeaders();
            frm.Show();
        }

        private void ınvoiceViewQueryEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoiceDetails frm = new FormInvoiceDetails();
            frm.Show();
        }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 