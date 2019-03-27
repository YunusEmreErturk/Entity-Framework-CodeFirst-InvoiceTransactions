using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class Unit
    {
        public Unit()
        {
            this.products = new HashSet<Product>();
        }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}
