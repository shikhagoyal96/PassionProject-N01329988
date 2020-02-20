using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PassionProject_N01329988.Data;
using PassionProject_N01329988.Models;

using System.Diagnostics;
using System.Net;
using System.Data.SqlClient;

namespace PassionProject_N01329988.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        //connecting to the database
        private CandyStoreContext db = new CandyStoreContext();
        //display a list of orders
        public ActionResult list()
        {
            string query = "select * from Orders inner join Candies on Orders.CandyId = Candies.CandyId inner join Customers on Orders.CustomerId = Customers.CustomerID";
            List<Order> order = db.Orders.SqlQuery(query).ToList();
            return View(order);
        }
        //display particular order details
        public ActionResult show(int? id)
        {
            Debug.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.SqlQuery("select * from Orders inner join Candies on Orders.CandyId = Candies.CandyId inner join Customers on Orders.CustomerId = Customers.CustomerID where OrderId=@OrderId", new SqlParameter("@OrderId", id)).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        //add 
        public ActionResult add()
        {
           List <Candy> candy = db.Candys.SqlQuery("select * from Candies").ToList();
            return View(candy);
        }
        //adding new data via post method
        [HttpPost]
        public ActionResult add(int candyid, int qty)
        {
            Debug.WriteLine(candyid);
            string query = "insert into Orders(CandyId, OrderQty) values(@CandyId,@OrderQty)";
            SqlParameter[] sqlparams = new SqlParameter[2];
            //placing the value in the sql query
            sqlparams[0] = new SqlParameter("@CandyId", candyid);
            sqlparams[1] = new SqlParameter("@OrderQty", qty);
            Debug.WriteLine("Problem found...");
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //redirecting to the list page of order model
            return RedirectToAction("list");

        }
        //deleting the existing record
        public ActionResult delete(int id)
        {
            Debug.WriteLine(id);
            string query = "delete from Orders where OrderID=@id";
            //placing the value in the sql query
            SqlParameter parameter = new SqlParameter("@id", id);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, parameter);
            //redirecting to the list page of order model
            return RedirectToAction("list");

        }
    }
}