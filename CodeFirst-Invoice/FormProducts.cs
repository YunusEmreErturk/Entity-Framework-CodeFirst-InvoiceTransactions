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
{//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
    public partial class FormProducts : Form
    {
        int selectedProductID;
        Product selectedProduct;
        InvoiceContext db = new InvoiceContext();

        public void FillProduct()
        {
            var product = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.unit.UnitName,
                x.ProductCode

            }).ToList();
            dataGridViewProducts.DataSource = product;
        }

        public void FillComboBoxProducts()
        {
            var unit = db.Units.Select(x => new
            {
                x.UnitName,
                x.UnitID
            }).ToList();
            comboBoxUnits.DisplayMember = "UnitName";
            comboBoxUnits.ValueMember = "UnitID";
            comboBoxUnits.DataSource = unit;
        }
        public FormProducts()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            FillProduct();
            FillComboBoxProducts();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product Name is not null !!");
            }
            else if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("Product Code is not null !!");
            }
            else if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("Unit Price is not null !!");
            }
            else
            {
                try
                {
                    Product product = new Product();
                    product.ProductName = txtProductName.Text;
                    product.ProductCode = txtProductCode.Text;
                    product.UnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                    product.UnitID =Convert.ToInt32(comboBoxUnits.SelectedValue);
                    db.Products.Add(product);
                    db.SaveChanges();
                    FillProduct();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unite price is be double !!");
                }
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                db.Products.Remove(selectedProduct);
                db.SaveChanges();
                MessageBox.Show("Delete Successful");
                FillProduct();
            }
            else if (dataGridViewProducts.SelectedRows.Count == 0)
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
            if (dataGridViewProducts.SelectedRows.Count >= 2)
            {
                foreach (DataGridViewRow item in dataGridViewProducts.SelectedRows)
                {
                    selectedProduct = db.Products.Find(item.Cells["ProductID"].Value);
                    db.Products.Remove(selectedProduct);
                }
                db.SaveChanges();
                MessageBox.Show("Multi Delete is Successful");
                FillProduct();
            }
            else if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                MessageBox.Show("Please go to 'Delete'");
            }
            else
            {
                MessageBox.Show("Plase make a selection !");
            }
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProductID =Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells["ProductID"].Value);
            selectedProduct = db.Products.Find(selectedProductID);

            txtProductCode.Text = dataGridViewProducts.CurrentRow.Cells["ProductCode"].Value.ToString();
            txtProductName.Text = dataGridViewProducts.CurrentRow.Cells["ProductName"].Value.ToString();
            txtUnitPrice.Text = dataGridViewProducts.CurrentRow.Cells["UnitPrice"].Value.ToString();



            string selectedUnitName = dataGridViewProducts.CurrentRow.Cells["UnitName"].Value.ToString();
            var a = db.Units.Where(x => x.UnitName == selectedUnitName).Select(x => x.UnitID).SingleOrDefault();
            comboBoxUnits.SelectedValue = a;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count >= 2)
            {
                MessageBox.Show("Please make a one selection");
            }
            else if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Plase make selection");
            }
            else
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    MessageBox.Show("Product Name is not null !!");
                }
                else if (string.IsNullOrEmpty(txtProductCode.Text))
                {
                    MessageBox.Show("Product Code is not null !!");
                }
                else if (string.IsNullOrEmpty(txtUnitPrice.Text))
                {
                    MessageBox.Show("Unit Price is not null !!");
                }
                else
                {
                    try
                    {
                        selectedProduct.ProductName = txtProductName.Text;
                        selectedProduct.ProductCode = txtProductCode.Text;
                        selectedProduct.UnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                        selectedProduct.UnitID = Convert.ToInt32(comboBoxUnits.SelectedValue);
                        db.SaveChanges();
                        FillProduct();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unit Price is be double !!");
                    }
                }
            }
        }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 