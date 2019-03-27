using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class Customer
    {
        public Customer()
        {
            this.invoiceHeaders = new HashSet<InvoiceHeader>();
        }
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CountyID { get; set; }
        public County county { get; set; }
        public virtual ICollection<InvoiceHeader> invoiceHeaders{ get; set; }
    }
}
