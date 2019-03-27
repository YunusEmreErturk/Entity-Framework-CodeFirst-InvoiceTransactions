using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class County
    {
        public County()
        {
            this.customers = new HashSet<Customer>();
        }
        public int CountyID { get; set; }
        public string CountyName { get; set; } 
        public int CityID { get; set; }
        public City city { get; set; }
        public virtual ICollection<Customer> customers { get; set; }
    }
}
