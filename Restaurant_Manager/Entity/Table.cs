using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restaurant_Manager.Entity
{
    public class Table
    {

        public int Id { get; set; }
        public int Number { get; set; }     
        public int Seats { get; set; }       
        public string Status { get; set; } = "вільний"; 

        public ICollection<Order>? Orders { get; set; }


    }
}
