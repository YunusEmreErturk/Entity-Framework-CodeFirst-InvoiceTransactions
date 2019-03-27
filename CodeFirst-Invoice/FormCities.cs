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
    public partial class FormCities : Form
    {
        InvoiceContext db = new InvoiceContext();
        int selectedCityID;
        City selectedCity;

        public void FillCity()
        {
            var cities = db.Cities.Select(x => new
            {
                x.CityID,
                x.CityName,

            }).ToList();
            dataGridViewCities.DataSource = cities;
        }
        public FormCities()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCityName.Text))
            {
                MessageBox.Show("City Name is not null !!");
            }
            else
            {
                City city = new City();
                city.CityName = txtCityName.Text;
                db.Cities.Add(city);
                db.SaveChanges();
                FillCity();
            }
        }

        private void Cities_Load(object sender, EventArgs e)
        {
            FillCity();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCities.SelectedRows.Count==1)
            {
                db.Cities.Remove(selectedCity);
                db.SaveChanges();
                MessageBox.Show("Delete Successful");
                FillCity();
            }
            else if (dataGridViewCities.SelectedRows.Count==0)
            {
                MessageBox.Show("Please make a selection !");
            }
            else
            {
                MessageBox.Show("Please go to 'Multi Delete'");
            }
            
        }

        private void dataGridViewCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedCityID = Convert.ToInt32(dataGridViewCities.CurrentRow.Cells["CityID"].Value);
            selectedCity = db.Cities.Find(selectedCityID);

            txtCityName.Text = dataGridViewCities.CurrentRow.Cells["CityName"].Value.ToString();
        }

        private void btnMultiDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCities.SelectedRows.Count>=2)
            {
                foreach (DataGridViewRow item in dataGridViewCities.SelectedRows)
                {
                    selectedCity = db.Cities.Find(item.Cells["CityID"].Value);
                    db.Cities.Remove(selectedCity);
                }
                db.SaveChanges();
                MessageBox.Show("Multi Delete is Successful");
                FillCity();
            }
            else if(dataGridViewCities.SelectedRows.Count==1)
            {
                MessageBox.Show("Please go to 'Delete'");
            }
            else
            {
                MessageBox.Show("Plase make a selection !");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCities.SelectedRows.Count>=2)
            {
                MessageBox.Show("Please make a one selection");
            }
            else if (dataGridViewCities.SelectedRows.Count==0)
            {
                MessageBox.Show("Plase make selection");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCityName.Text))
                {
                    MessageBox.Show("City Name is not null !!");
                }
                else
                {
                    selectedCity = db.Cities.Find(selectedCityID);
                    selectedCity.CityName = txtCityName.Text;
                    db.SaveChanges();
                    FillCity();
                }
            }
            
        }
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 