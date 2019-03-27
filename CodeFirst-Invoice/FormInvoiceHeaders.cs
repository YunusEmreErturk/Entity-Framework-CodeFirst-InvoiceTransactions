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
    public partial class FormInvoiceHeaders : Form
    {
        InvoiceContext db = new InvoiceContext();
        int CountyID;//Secilen  uyeninin county ve citysi gelmesi için countyID yi cekmem lazımdı o yüzden böyle bir variable kullandım.
        int selectedID;//datagridview'dan secilen satırdaki productid yi tutmak için kullandım.
        List<SelectedProduct> productList = new List<SelectedProduct>(); // Onemli. Oncelikle guvenlik amacıyla veritabanına yollamadan fatura detaylarını bir listede tutuyorum.En son eklerken bir hata olması durumunda database'e yanlış verilerin gitmemesi için !
        public void FillComboBoxCustomers() // customerların comboxa gelmesi
        {
            var customer = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName
            }).ToList();
            comboBoxCustomer.DisplayMember = "CompanyName";
            comboBoxCustomer.ValueMember = "CustomerID";
            comboBoxCustomer.DataSource = customer;
        }
        int selectedProductID;
        public void FillComboBoxProductsLoad() //form ilk yüklendiginde comboboxa tum productların cekılmesi 
        {
            selectedProductID = Convert.ToInt32(comboBoxProductName.SelectedValue);
            var product = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.unit.UnitName
            }).ToList();
            comboBoxProductName.DisplayMember = "ProductName";
            comboBoxProductName.ValueMember = "ProductID";
            comboBoxProductName.DataSource = product;

            foreach (var item in product)
            {
                txtProductUnitPrice.Text = item.UnitPrice.ToString();
                txtProductUnits.Text = item.UnitName.ToString();
            }
        }
        public void FillComboBoxProductsFiltre() // product secildiginde secili productun bilgileri textlere geliyor
        {
            selectedProductID = Convert.ToInt32(comboBoxProductName.SelectedValue);
            var product = db.Products.Find(selectedProductID);
            txtProductUnitPrice.Text = product.UnitPrice.ToString();
            txtProductUnits.Text = db.Units.Find(product.UnitID).UnitName;
            txtVatAmount.Text = "0,18"; // kdvyi sabit olarak 0.18 kabul ettim.
        }
        public void FillDataGridView()//datagridview'in ekleme ve silme işlemlerinden sonra yuklenmesi için kullandım.
        {
            dataGridViewInvoice.DataSource = productList.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.VATAmount,
                x.Quantity,
                x.TotalAmount
            }).ToList();
            dataGridViewInvoice.Columns[0].Visible = false; // kullanıcının productid yi görmesi gerekmez.
        }
        public void ClearDataGridView() // listemi ve datagridviewi temizlemek için kullandım
        {
            dataGridViewInvoice.Columns.Clear();
            productList.Clear();
        }


        public void FillComboBoxCustomerCities()//secilen customera gore sehrini ve ilcesini getirdim.
        {
            
            int selectedCustomerID = Convert.ToInt32(comboBoxCustomer.SelectedValue); 
            var customerCountyID = db.Customers.Where(y => y.CustomerID == selectedCustomerID);
            foreach (var item in customerCountyID)
            {
                CountyID = item.CountyID;
            }
            var city = db.Counties.Where(y => y.CountyID == CountyID).Select(x => new
            {
                x.CountyID,
                x.CountyName,
                x.CityID,
                x.city.CityName

            }).ToList();
            comboBoxCustomerCounty.DisplayMember = "CountyName";
            comboBoxCustomerCounty.ValueMember = "CountyID";
            comboBoxCustomerCounty.DataSource = city;

            comboBoxCustomerCity.DisplayMember = "CityName";
            comboBoxCustomerCity.ValueMember = "CityID";
            comboBoxCustomerCity.DataSource = city;
        }
        double totalInvoiceAmount;//Toplam fatura tutarını yazdırmak için local olmayan bir degısken tanımladım.
        public void GetTotalAmount() //Toplam tutarı yazdıran methodum.
        {    
            foreach (DataGridViewRow item in dataGridViewInvoice.Rows)
            { 
                totalInvoiceAmount = Convert.ToDouble(item.Cells["TotalAmount"].Value) + totalInvoiceAmount;
            }
            lblTotalAmount.Text = totalInvoiceAmount.ToString()+"$";
            totalInvoiceAmount = 0;
        }

        public FormInvoiceHeaders()
        {
            InitializeComponent();
        }

        private void FormInvoiceHeaders_Load(object sender, EventArgs e)
        {
            //Form yuklendıgınde comboboxlarımın dolu gelmesini yazdıgım methodları cagırarak sagladim.
            FillComboBoxCustomers();
            FillComboBoxProductsLoad(); 
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxCustomerCities();//degisen customera gore city ve countylerini getirdim.
        }

        private void comboBoxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            FillComboBoxProductsFiltre(); // degisen productlara gore birim ve fiyatlarını getirdim.
            
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //listeme urun ekliyorum ve datagridviewda gosteriyorum
        
            if (productList.Any(x => x.ProductID == Convert.ToInt32(comboBoxProductName.SelectedValue)))
            {
                MessageBox.Show("ayniurunden var adet için guncelleyebilirsiniz.");
            }
            else
            {

                if (numericUpDownQuantity.Value>0)
                {
                    productList.Add(new SelectedProduct()
                    {
                        ProductID = Convert.ToInt32(comboBoxProductName.SelectedValue),
                        ProductName = comboBoxProductName.Text,
                        UnitPrice = Convert.ToDouble(txtProductUnitPrice.Text),
                        Quantity = Convert.ToInt32(numericUpDownQuantity.Value),
                        VATAmount = Convert.ToDouble(txtVatAmount.Text),
                        TotalAmount = (Convert.ToDouble(txtProductUnitPrice.Text) * Convert.ToInt32(numericUpDownQuantity.Value)) * (1.18)
                    });
                    FillDataGridView();
                    GetTotalAmount();
                }
                else
                {
                    MessageBox.Show("Quantity is must be 0 >");
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //listemden urun siliyorum.
            try
            {
                var product = productList.Where(x => x.ProductID == selectedID).FirstOrDefault();
                productList.Remove(product);
                FillDataGridView();
            }
            catch (Exception)
            {

                MessageBox.Show("Please make a selection !");
            }
        }

        private void dataGridViewInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview'daki secili urunun idsini alıyorum ve bilgilerini getiriyorum.
            selectedID =Convert.ToInt32(dataGridViewInvoice.CurrentRow.Cells["ProductID"].Value);
            var product = productList.Where(x => x.ProductID == selectedID).FirstOrDefault();
            comboBoxProductName.SelectedValue = selectedID;
            numericUpDownQuantity.Value = product.Quantity;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //listeye eklenen urun yanlıs adet vb eklenirse guncelleme yaptırıyorum.
            try
            {
                var product = productList.Where(x => x.ProductID == selectedID).FirstOrDefault();
                if (selectedID==Convert.ToInt32(comboBoxProductName.SelectedValue))
                {
                    product.Quantity = Convert.ToInt32(numericUpDownQuantity.Value);
                    product.TotalAmount = (Convert.ToDouble(txtProductUnitPrice.Text) * Convert.ToInt32(numericUpDownQuantity.Value)) * (1.18);
                }
                else
                {
                    product.ProductID = Convert.ToInt32(comboBoxProductName.SelectedValue);
                    product.ProductName = comboBoxProductName.Text;
                    product.UnitPrice = Convert.ToDouble(txtProductUnitPrice.Text);
                    
                }
                FillDataGridView();
            }
            catch (Exception)
            {
                MessageBox.Show("Updatede hata var bul");

            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
        }

        public void InvoiceSave()
        {
            //asil faturayı kaydederken önce bir header acıcam sonra bu headera detay ekleyecem.
            InvoiceHeader invoiceHeader = new InvoiceHeader();
            invoiceHeader.CustomerID =Convert.ToInt32(comboBoxCustomer.SelectedValue);
            invoiceHeader.PaymentDate = dateTimePickerPaymentDate.Value;
            invoiceHeader.DeliveryNote =Convert.ToInt32(txtDeliveryNote.Text);
            invoiceHeader.TotalAmount = 0;
            invoiceHeader.InvoiceDate = DateTime.Now;
            db.InvoiceHeaders.Add(invoiceHeader);
            db.SaveChanges();
            lblInvoiceNo.Text = invoiceHeader.InvoiceID.ToString();
        }
        public void InvoiceDetailSave()
        {
            //listedeki urunlerın invoicedetaya eklenmesi.
            foreach (SelectedProduct item in productList)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails();
                invoiceDetails.InvoiceID = Convert.ToInt32(lblInvoiceNo.Text);
                invoiceDetails.ProductID = item.ProductID;
                invoiceDetails.Quantity = item.Quantity;
                invoiceDetails.VATAmount = item.VATAmount;
                invoiceDetails.Unitprice = item.UnitPrice * item.Quantity;
                invoiceDetails.AmountWithVAT = (item.UnitPrice * item.Quantity) * (1 + Convert.ToDouble(item.VATAmount));
                db.InvoiceDetailss.Add(invoiceDetails);
            }
            db.SaveChanges();
            MessageBox.Show("Successfully Added.");
            
        }
   

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            //sırasıyla methodları cagırıyorum ve ekliyorum.Her ihtimale karsı transaction kullandım herhangi bir hatada rolback edilsin db bozulmasın diye..
            System.Data.Entity.DbContextTransaction tran = db.Database.BeginTransaction();
            try
            {
                InvoiceSave();
                InvoiceDetailSave();
                tran.Commit();
                FormInvoiceDetails frm = new FormInvoiceDetails(Convert.ToInt32(lblInvoiceNo.Text));
                frm.Show();
                

            }
            catch (Exception)
            {
                tran.Rollback();
                MessageBox.Show("Delivery Note is not nul !!");
            }
        }

       
    }
}
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 