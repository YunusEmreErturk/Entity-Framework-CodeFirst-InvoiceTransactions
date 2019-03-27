using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirst_Invoice.Entity;

namespace CodeFirst_Invoice
{
    public partial class FormInvoiceDetails : Form
    {
        InvoiceContext db = new InvoiceContext();
        int selectedInvoiceID;
        int selectedProductID;
        public FormInvoiceDetails()
        {
            InitializeComponent();
        }
        public FormInvoiceDetails(int invoiceID)
        {
            InitializeComponent();
            int invoiceId = invoiceID;
            var invoice = db.InvoiceDetailss.Where(x => x.InvoiceID == invoiceId).Select(x => new
            {
                x.product.ProductName,
                x.Unitprice,
                x.Quantity,
                x.VATAmount,
                TotalAmount = x.Quantity * x.Unitprice,
                x.AmountWithVAT
            }).ToList();
            dataGridViewInvoiceDetails.DataSource = invoice;

            int customerID = Convert.ToInt32(db.InvoiceHeaders.Where(x => x.InvoiceID == invoiceId).Select(x => x.CustomerID).FirstOrDefault());
            int countyID = db.Customers.Find(customerID).CountyID;
            int cityID = db.Counties.Find(countyID).CityID;

            txtCustomerName.Text = db.Customers.Find(customerID).CompanyName;
            txtCustomerCounty.Text = db.Counties.Find(countyID).CountyName;
            txtCustomerCity.Text = db.Cities.Find(cityID).CityName;

            GetTotalAmount();
        }


        double totalInvoiceAmount;
        public void GetTotalAmount() //Toplam tutarı yazdıran methodum.
        {
            foreach (DataGridViewRow item in dataGridViewInvoiceDetails.Rows)
            {
                totalInvoiceAmount = Convert.ToDouble(item.Cells["AmountWithVAT"].Value) + totalInvoiceAmount;
            }
            lblTotalAmount.Text = totalInvoiceAmount.ToString() + "$";
            totalInvoiceAmount = 0;
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInvoiceID.Text))
            {
                MessageBox.Show("Please commit invoices ID !");
            }
            else
            {
                int invoiceId = Convert.ToInt32(txtInvoiceID.Text);

                if (db.InvoiceHeaders.Any(x => x.InvoiceID == invoiceId))
                {
                    var invoice = db.InvoiceDetailss.Where(x => x.InvoiceID == invoiceId).Select(x => new
                    {
                        x.ProductID,
                        x.InvoiceID,
                        x.product.ProductName,
                        x.Unitprice,
                        x.Quantity,
                        x.VATAmount,
                        TotalAmount = x.Quantity * x.Unitprice,
                        AmountWithVAT = (x.Quantity * x.Unitprice) * 1.18
                    }).ToList();

                    dataGridViewInvoiceDetails.DataSource = invoice;
                    dataGridViewInvoiceDetails.Columns[0].Visible = false;
                    

                    int customerID = Convert.ToInt32(db.InvoiceHeaders.Where(x => x.InvoiceID == invoiceId).Select(x => x.CustomerID).FirstOrDefault());
                    int countyID = db.Customers.Find(customerID).CountyID;
                    int cityID = db.Counties.Find(countyID).CityID;

                    txtCustomerName.Text = db.Customers.Find(customerID).CompanyName;
                    txtCustomerCounty.Text = db.Counties.Find(countyID).CountyName;
                    txtCustomerCity.Text = db.Cities.Find(cityID).CityName;

                    GetTotalAmount();
                }
                else
                {
                    MessageBox.Show("No invoices");
                }

            }


        }
        public void FillInvoices()
        {
            var invoices = db.InvoiceHeaders.Select(x => new
            {
                x.InvoiceID,
                x.InvoiceDate,
                x.PaymentDate,
                x.customer.CompanyName,
                x.customer.county.city.CityName,
                x.customer.county.CountyName

            }).ToList();
            dataGridViewInvoiceDetails.DataSource = invoices;
        }

        private void btnInvoiceALL_Click(object sender, EventArgs e)
        {
            FillInvoices();
            lblTotalAmount.Text = null;
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            try
            {

            if (dataGridViewInvoiceDetails.ColumnCount !=6)
            {
                InvoiceDetails id = new InvoiceDetails();
                id = db.InvoiceDetailss.Where(x => x.InvoiceID == selectedInvoiceID && x.ProductID == selectedProductID).FirstOrDefault();
                db.InvoiceDetailss.Remove(id);
                db.SaveChanges();
                MessageBox.Show("Succesfull delete Invoice Detail");

                int invoiceId = selectedInvoiceID;

                if (db.InvoiceHeaders.Any(x => x.InvoiceID == invoiceId))
                {
                    var invoice = db.InvoiceDetailss.Where(x => x.InvoiceID == invoiceId).Select(x => new
                    {
                        x.ProductID,
                        x.InvoiceID,
                        x.product.ProductName,
                        x.Unitprice,
                        x.Quantity,
                        x.VATAmount,
                        TotalAmount = x.Quantity * x.Unitprice,
                        AmountWithVAT = (x.Quantity * x.Unitprice) * 1.18
                    }).ToList();

                    dataGridViewInvoiceDetails.DataSource = invoice;
                    dataGridViewInvoiceDetails.Columns[0].Visible = false;
                    dataGridViewInvoiceDetails.Columns[1].Visible = false;

                    int customerID = Convert.ToInt32(db.InvoiceHeaders.Where(x => x.InvoiceID == invoiceId).Select(x => x.CustomerID).FirstOrDefault());
                    int countyID = db.Customers.Find(customerID).CountyID;
                    int cityID = db.Counties.Find(countyID).CityID;

                    txtCustomerName.Text = db.Customers.Find(customerID).CompanyName;
                    txtCustomerCounty.Text = db.Counties.Find(countyID).CountyName;
                    txtCustomerCity.Text = db.Cities.Find(cityID).CityName;

                    GetTotalAmount();
                }
                else
                {
                    MessageBox.Show("No invoices");
                }
            }
            else
            {

                if (dataGridViewInvoiceDetails.SelectedRows.Count == 1)
                {
                    int selectedInvoice = Convert.ToInt32(dataGridViewInvoiceDetails.CurrentRow.Cells["InvoiceID"].Value);
                    InvoiceHeader ih = db.InvoiceHeaders.Find(selectedInvoice);
                    db.InvoiceHeaders.Remove(ih);
                    db.SaveChanges();
                    MessageBox.Show("Delete is successful");
                    FillInvoices();

                }
                else
                {
                    MessageBox.Show("Please make a one selection");
                }

            }

            }
            catch (Exception)
            {

                MessageBox.Show("Please make a Invoice Or InvoiceDetails");
            }


        }

        private void dataGridViewInvoiceDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtInvoiceID.Text = dataGridViewInvoiceDetails.CurrentRow.Cells["InvoiceID"].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection in All invoices!! ");
            }

        }

        private void dataGridViewInvoiceDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedInvoiceID = Convert.ToInt32(dataGridViewInvoiceDetails.CurrentRow.Cells["InvoiceID"].Value);
                selectedProductID = Convert.ToInt32(dataGridViewInvoiceDetails.CurrentRow.Cells["ProductID"].Value);
            }
            catch (Exception)
            {

                selectedInvoiceID = Convert.ToInt32(dataGridViewInvoiceDetails.CurrentRow.Cells["InvoiceID"].Value);
            }
           
        }
    }
}
