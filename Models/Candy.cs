using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProject_N01329988.Models
{
    public class Candy
    {
        [Key]
        public int CandyId { get; set; }//primary key
        public string CandyName { get; set; }
        public double CandyPrice { get; set; }//price of each candy in cad
    }
}