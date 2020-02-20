using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PassionProject_N01329988.Models;

namespace PassionProject_N01329988.Data
{
    public class CandyStoreContext : DbContext
    {
       

        public CandyStoreContext() : base("name=CandyStoreContext")
        {
        }
        //connecting to the 3models
        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Candy> Candys { get; set; }

    }
}