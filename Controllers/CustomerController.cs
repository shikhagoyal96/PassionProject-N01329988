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
    public class CustomerController : Controller
    {
        // GET: Customer
        //connecting to the database
        private CandyStoreContext db = new CandyStoreContext();
        //displaying a list of Customer
        public ActionResult list()
        {
            List<Customer> customer = db.Customers.SqlQuery("select * from Customers").ToList();
            return View(customer);
        }
        //displaying the detail of a particular customer
        public ActionResult show(int? id)
        {
            Debug.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.SqlQuery("select * from Customers where CustomerID=@CustomerId", new SqlParameter("@CustomerId", id)).FirstOrDefault();
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
       //adding a new customer details via POST method
        [HttpPost]
        public ActionResult add(string name, int contact)
        {
            Debug.WriteLine(name, contact);

            string query = "insert into Customers(CustomerName, CustomerContact) values(@Name, @Contact)";
            SqlParameter[] sqlparams = new SqlParameter[2];
            //placing the 2 values in the sql query
            sqlparams[0] = new SqlParameter("@Name", name);
            sqlparams[1] = new SqlParameter("@Contact", contact);
            Debug.WriteLine("Poblem..");
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //redirecting to the list page of customer model
            return RedirectToAction("list");
        }
        //getting the details to add new customer
        public ActionResult add()
        {
            return View();
        }
        //updating the details of the existing customer
        public ActionResult update(int id)
        {
            Debug.WriteLine(id);
            Customer customer = db.Customers.SqlQuery("select * from Customers where CustomerID=@CustomerId", new SqlParameter("@CustomerId", id)).FirstOrDefault();
            return View(customer);
        }
        //updating the details of the existing customer via POST method
        [HttpPost]
        public ActionResult update(int id, string name, int contact)
        {
            Debug.WriteLine(name, contact);
            string query = "update Customers set CustomerName=@Name, CustomerContact=@Contact where CustomerID=@id";
            SqlParameter[] parameters = new SqlParameter[3];
            //placing the 3 values in the sql query
            parameters[0] = new SqlParameter("@Name", name);
            parameters[1] = new SqlParameter("@Contact", contact);
            parameters[2] = new SqlParameter("@id", id);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, parameters);
            //redirecting to the list page of customer model
            return RedirectToAction("list");

        }
        //deleting the existing record
        public ActionResult delete(int id)
        {
            Debug.WriteLine(id);
            string query = "delete from Customers where CustomerID=@id";
            //placing the value in the sql query
            SqlParameter parameter = new SqlParameter("@id", id);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, parameter);
            //redirecting to the list page of customer model
            return RedirectToAction("list");

        }
    }
}