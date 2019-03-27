using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class Product
    {
        public Product()
        {
            this.invoiceDetails = new HashSet<InvoiceDetails>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double UnitPrice { get; set; }
        public int UnitID { get; set; }
        public Unit unit { get; set; }
        public virtual ICollection<InvoiceDetails> invoiceDetails { get; set; }


    }
}
