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
    //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
    public partial class FormCustomers : Form
    {
        int selectedCustomerID;
        Customer selectedCustomer;
        InvoiceContext db = new InvoiceContext();

        public void FillCustomers()
        {
            var customer = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName,
                x.county.city.CityName,
                x.county.CountyName,
                x.Address 
            }).ToList();
            dataGridViewCustomers.DataSource = customer;
        }
        public void FillComboBoxCustomerCities()
        {
            var city = db.Cities.Select(x => new
            {
                x.CityName,
                x.CityID
            }).ToList();
            comboBoxCustomerCity.DisplayMember = "CityName";
            comboBoxCustomerCity.ValueMember = "CityID";
            comboBoxCustomerCity.DataSource = city;
        }

        public void FillComboBoxCustomerCounties()
        {
            int selectedCityID = Convert.ToInt32(comboBoxCustomerCity.SelectedValue);
            var county = db.Counties.Where(y => y.CityID == selectedCityID).Select(x => new
            {
                x.CountyID,
                x.CountyName

            }).ToList();
            comboBoxCustomerCounty.DisplayMember = "CountyName";
            comboBoxCustomerCounty.ValueMember = "CountyID";
            comboBoxCustomerCounty.DataSource = county;
        }
     

        public FormCustomers()
        {
            InitializeComponent();
        }
        //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
        private void Customers_Load(object sender, EventArgs e)
        {
            FillCustomers();
            FillComboBoxCustomerCities();
            
        }

        private void comboBoxCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxCustomerCounties();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Customer Name is not null !!");
            }
            else if (string.IsNullOrEmpty(txtCustomerAddress.Text))
            {
                MessageBox.Show("Customer Address is not null !!");
            }
            else
            {
                Customer customer = new Customer();
                customer.CompanyName = txtCustomerName.Text;
                customer.Address = txtCustomerAddress.Text;
                customer.CountyID =Convert.ToInt32(comboBoxCustomerCounty.SelectedValue);
                db.Customers.Add(customer);
                db.SaveChanges();
                MessageBox.Show("Customer Add is Successful");
                FillCustomers();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count >= 2)
            {
                MessageBox.Show("Please make a one selection");
            }
            else if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Plase make selection");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCustomerName.Text))
                {
                    MessageBox.Show("Customer Name is not null !!");
                }
                else if (string.IsNullOrEmpty(txtCustomerAddress.Text))
                {
                    MessageBox.Show("Customer Address is not null !!");
                }
                else
                {
                    selectedCustomer.CompanyName = txtCustomerName.Text;
                    selectedCustomer.Address = txtCustomerAddress.Text;
                    selectedCustomer.CountyID = Convert.ToInt32(comboBoxCustomerCounty.SelectedValue);
                    db.SaveChanges();
                    MessageBox.Show("Update is Successful");
                    FillCustomers();
                }
            }
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedCustomerID =Convert.ToInt32(dataGridViewCustomers.CurrentRow.Cells["CustomerID"].Value);
            selectedCustomer = db.Customers.Find(selectedCustomerID);

            txtCustomerName.Text = dataGridViewCustomers.CurrentRow.Cells["CompanyName"].Value.ToString();
            txtCustomerAddress.Text = dataGridViewCustomers.CurrentRow.Cells["Address"].Value.ToString();

            string selectedCity = dataGridViewCustomers.CurrentRow.Cells["CityName"].Value.ToString();
            var a = db.Cities.Where(x => x.CityName == selectedCity).Select(x => x.CityID).SingleOrDefault();
            comboBoxCustomerCity.SelectedValue = a;

            string selectedCounty = dataGridViewCustomers.CurrentRow.Cells["CountyName"].Value.ToString();
            var b = db.Counties.Where(x => x.CountyName == selectedCounty).Select(x => x.CountyID).SingleOrDefault();
            comboBoxCustomerCounty.SelectedValue = b;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 1)
            {
                db.Customers.Remove(selectedCustomer);
                db.SaveChanges();
                MessageBox.Show("Delete Successful");
                FillCustomers();
            }
            else if (dataGridViewCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please make a selection !");
            }
            else
            {
                MessageBox.Show("Please go to 'Multi Delete'");
            }
        }

        private void btnMultiDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count >= 2)
            {
                foreach (DataGridViewRow item in dataGridViewCustomers.SelectedRows)
                {
                    selectedCustomer = db.Customers.Find(item.Cells["CustomerID"].Value);
                    db.Customers.Remove(selectedCustomer);
                }
                db.SaveChanges();
                MessageBox.Show("Multi Delete is Successful");
                FillCustomers();
            }
            else if (dataGridViewCustomers.SelectedRows.Count == 1)
            {
                MessageBox.Show("Please go to 'Delete'");
            }
            else
            {
                MessageBox.Show("Plase make a selection !");
            }
        }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 