using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Invoice.Entity
{//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
    public class InvoiceDetails
    {
        [Key,Column(Order = 0)]
        public int InvoiceID { get; set; }

        [Key,Column(Order = 1)]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Unitprice { get; set; }
        public double VATAmount { get; set; }
        public double AmountWithVAT { get; set; }
        public string Description { get; set; }
        public Product product { get; set; }
        public InvoiceHeader invoiceHeader { get; set; }
    }
}
