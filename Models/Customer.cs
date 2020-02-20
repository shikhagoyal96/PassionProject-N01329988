using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProject_N01329988.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }//primary key
        public string CustomerName { get; set; }

        public int CustomerContact { get; set; }

        
    }
}