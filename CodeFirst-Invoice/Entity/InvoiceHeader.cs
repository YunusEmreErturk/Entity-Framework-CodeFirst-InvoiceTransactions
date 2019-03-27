using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class InvoiceHeader
    {
        public InvoiceHeader()
        {
            this.invoiceDetails = new HashSet<InvoiceDetails>();
            //this.InvoiceDate= datetime.now;
        }
        [Key]
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int DeliveryNote { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalAmount { get; set; }
        public Customer customer { get; set; }

        public virtual ICollection<InvoiceDetails> invoiceDetails { get; set; }
    }
}
