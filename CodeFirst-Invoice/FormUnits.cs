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
    public partial class FormUnits : Form
    {
        int selectedUnitID;
        Unit selectedUnit;
        InvoiceContext db = new InvoiceContext();
        public FormUnits()
        {
            InitializeComponent();
        }

        public void FillUnit()
        {
            var unit = db.Units.Select(x => new
            {
                x.UnitID,
                x.UnitName

            }).ToList();
            dataGridViewUnits.DataSource = unit;
        }
     
        private void Units_Load(object sender, EventArgs e)
        {
            FillUnit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("Unit Name is not null !!");
            }
            else
            {
                Unit unit = new Unit();
                unit.UnitName = txtUnitName.Text;
                db.Units.Add(unit);
                db.SaveChanges();
                FillUnit();
            }
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewUnits.SelectedRows.Count >= 2)
            {
                MessageBox.Show("Please make a one selection");
            }
            else if (dataGridViewUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Plase make selection");
            }
            else
            {
                if (string.IsNullOrEmpty(txtUnitName.Text))
                {
                    MessageBox.Show("City Name is not null !!");
                }
                else
                {
                    selectedUnit = db.Units.Find(selectedUnitID);
                    selectedUnit.UnitName = txtUnitName.Text;
                    db.SaveChanges();
                    FillUnit();
                }
            }
        }

        private void dataGridViewUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedUnitID =Convert.ToInt32(dataGridViewUnits.CurrentRow.Cells["UnitID"].Value);
            selectedUnit = db.Units.Find(selectedUnitID);

            txtUnitName.Text = dataGridViewUnits.CurrentRow.Cells["UnitName"].Value.ToString();

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUnits.SelectedRows.Count == 1)
            {
                db.Units.Remove(selectedUnit);
                db.SaveChanges();
                MessageBox.Show("Delete Successful");
                FillUnit();
            }
            else if (dataGridViewUnits.SelectedRows.Count == 0)
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
            if (dataGridViewUnits.SelectedRows.Count >= 2)
            {
                foreach (DataGridViewRow item in dataGridViewUnits.SelectedRows)
                {
                    selectedUnit = db.Units.Find(item.Cells["UnitID"].Value);
                    db.Units.Remove(selectedUnit);
                }
                db.SaveChanges();
                MessageBox.Show("Multi Delete is Successful");
                FillUnit();
            }
            else if (dataGridViewUnits.SelectedRows.Count == 1)
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