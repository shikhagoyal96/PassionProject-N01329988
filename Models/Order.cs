using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PassionProject_N01329988.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }//primary key
       
        public int OrderQty { get; set; }
        public double OrderPay { get; set; }
        //one customer to many orders
        public int CustomerID { get; set; }//foreign key
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        //one order to many candies
        public int CandyId { get; set; }//foreign key
        [ForeignKey("CandyId")]
        public virtual Candy Candy { get; set; }

        
        
    }
}