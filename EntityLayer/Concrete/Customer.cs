using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public required string CustomerName { get; set; }

        public required string CustomerCity { get; set; }

        public int JobID { get; set; }

        public Job Job { get; set;}
    }
}
