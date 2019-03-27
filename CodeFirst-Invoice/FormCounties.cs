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
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice
{
    
    public partial class FormCounties : Form
    {
        int selectedCountyID;
        County selectedCounty;
        InvoiceContext db = new InvoiceContext();

        public void FillCounty()
        {
            int selectedCityID = Convert.ToInt32(comboBoxCities.SelectedValue);
            var county = db.Counties.Where(y=>y.CityID==selectedCityID).Select(x => new
            {
                x.CountyID,
                x.CountyName,
                x.city.CityName

            }).ToList();
            dataGridViewCounties.DataSource = county;
        }
        public void FillComboBoxCities()
        {
            var city = db.Cities.Select(x => new
            {
                x.CityName,
                x.CityID
            }).ToList();
            comboBoxCities.DisplayMember = "CityName";
            comboBoxCities.ValueMember = "CityID";
            comboBoxCities.DataSource = city;  
        }
        public FormCounties()
        {
            InitializeComponent();
        }

        private void FormCounties_Load(object sender, EventArgs e)
        {
            FillComboBoxCities();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCountyName.Text))
            {
                MessageBox.Show("County Name is not null !!");
            }
            else
            {
                County county = new County();
                county.CountyName = txtCountyName.Text;
                county.CityID =Convert.ToInt32(comboBoxCities.SelectedValue);
                db.Counties.Add(county);
                db.SaveChanges();
                FillCounty();
            }
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCounty();
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCounties.SelectedRows.Count >= 2)
            {
                MessageBox.Show("Please make a one selection");
            }
            else if (dataGridViewCounties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Plase make selection");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCountyName.Text))
                {
                    MessageBox.Show("City Name is not null !!");
                }
                else
                {
                    selectedCounty.CountyName = txtCountyName.Text;
                    selectedCounty.CityID = Convert.ToInt32(comboBoxCities.SelectedValue);
                    db.SaveChanges();
                    FillCounty();
                }
            }
        }

   
        private void dataGridViewCounties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedCountyID = Convert.ToInt32(dataGridViewCounties.CurrentRow.Cells["CountyID"].Value);
            selectedCounty = db.Counties.Find(selectedCountyID);

            txtCountyName.Text = dataGridViewCounties.CurrentRow.Cells["CountyName"].Value.ToString();

            string selectedCityName = dataGridViewCounties.CurrentRow.Cells["CityName"].Value.ToString();
            var a = db.Cities.Where(x => x.CityName == selectedCityName).Select(x => x.CityID).SingleOrDefault();
            comboBoxCities.SelectedValue = a;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCounties.SelectedRows.Count == 1)
            {
                db.Counties.Remove(selectedCounty);
                db.SaveChanges();
                MessageBox.Show("Delete Successful");
                FillCounty();
            }
            else if (dataGridViewCounties.SelectedRows.Count == 0)
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
            if (dataGridViewCounties.SelectedRows.Count >= 2)
            {
                foreach (DataGridViewRow item in dataGridViewCounties.SelectedRows)
                {
                    selectedCounty = db.Counties.Find(item.Cells["CountyID"].Value);
                    db.Counties.Remove(selectedCounty);
                }
                db.SaveChanges();
                MessageBox.Show("Multi Delete is Successful");
                FillCounty();
            }
            else if (dataGridViewCounties.SelectedRows.Count == 1)
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