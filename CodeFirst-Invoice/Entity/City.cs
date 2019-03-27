using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//@Author Yunus Emre Ertürk ===> yemrerturk@gmail.com / www.muhendiserturk.com 
namespace CodeFirst_Invoice.Entity
{
    public class City
    {
        public City()
        {
            this.counties = new HashSet<County>();
        }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<County> counties { get; set; }
    }
}
