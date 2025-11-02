using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Entity
{
    public class Shift
    {

        public int ID { get; set; }
        public int UserId { get; set; }          
        public DateTime Date { get; set; }        
        public string ShiftTime { get; set; } = ""; 
        public string Status { get; set; } = "заплановано"; 

        
        //public User? User { get; set; }

    }
}
