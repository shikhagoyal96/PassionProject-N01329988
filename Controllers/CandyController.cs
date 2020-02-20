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
    public class CandyController : Controller
    {
        // GET: Candy
        //connecting to the database
        private CandyStoreContext db = new CandyStoreContext();
       //displaying thelist of candy
        public ActionResult listCandy()
        {
            List<Candy> candies = db.Candys.SqlQuery("select * from Candies").ToList();
                return View(candies);
        }
        //displaying a particuler candy details
        public ActionResult showCandy(int? id)
        {
            Debug.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candies = db.Candys.SqlQuery("select * from Candies where CandyId=@CandyId", new SqlParameter("@CandyId", id)).FirstOrDefault();
            if(candies == null)
            {
                return HttpNotFound();
            }
            return View(candies);
        }
        //add new candy via POST method
        [HttpPost]
        public ActionResult addCandy(string CandyName, double CandyPrice)
        {
            Debug.WriteLine(CandyName, CandyPrice);
            string query = "insert into Candies(CandyName, candyPrice) values(@CandyName, @CandyPrice)";
            SqlParameter[] sqlparams = new SqlParameter[2];
            //placing the 2 values in the sql query
            sqlparams[0] = new SqlParameter("@CandyName", CandyName);
            sqlparams[1] = new SqlParameter("@CandyPrice", CandyPrice);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //redirecting to the list page of candy model
            return RedirectToAction("listCandy");

        }
        //add new candy
        public ActionResult addCandy()
        {
           //List<Candy> candy = db.Candys.SqlQuery("select * from Candies").ToList();
           return View();
            
        }
        
        //update the selected candy details
        public ActionResult updateCandy(int id)
        {
            Debug.WriteLine(id);
            Candy selectedcandy = db.Candys.SqlQuery("select * from Candies where CandyId = @id", new SqlParameter("@id", id)).FirstOrDefault();
            return View(selectedcandy);
        }
        //update the selected candy details via POST method
        [HttpPost]
        public ActionResult updateCandy(int id, string CandyName)
        {
            Debug.WriteLine(id, CandyName);
            string query = "update Candies set CandyName=@CandyName where CandyId=@id";

            SqlParameter[] parameters = new SqlParameter[2];
            //placing the 2 values in the sql query
            parameters[0] = new SqlParameter("@CandyName", CandyName);
            parameters[1] = new SqlParameter("@id", id);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, parameters);
            //redirecting to the list page of candy model
            return RedirectToAction("listCandy");
        }
        //deleting the selected candy from the database
        public ActionResult Delete(int id)
        {
            string query = "delete from Candies where CandyId=@id";
            SqlParameter sqlparam = new SqlParameter("@id", id);
            //executing the sql query
            db.Database.ExecuteSqlCommand(query, sqlparam);
             //redirecting to the list page of candy model
            return RedirectToAction("listCandy");
        }
        
    }
}