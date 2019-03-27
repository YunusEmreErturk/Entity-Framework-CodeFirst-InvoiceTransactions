namespace CodeFirst_Invoice
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CodeFirst_Invoice.Entity;
    //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
    public class InvoiceContext : DbContext
    {
      
        public InvoiceContext()
            : base("name=InvoiceContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetailss { get; set; }

        //@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 

    }


}
