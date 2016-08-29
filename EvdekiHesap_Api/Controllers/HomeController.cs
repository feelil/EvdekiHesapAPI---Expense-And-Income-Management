using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvdekiHesap_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<ExpenseIncome> sonuc = null;
            using (var db = new EvdekiHesapContext())
            {
                //var sonuc = db.Accounts.Where(x => x.ID == 10).Select(x => new Account { ID = x.ID, Name=x.Name });
                sonuc = (from tbl in db.ExpenseIncomes
                         where tbl.ID == 10
                         select tbl).ToList();

                //foreach (var item in sonuc)
                //{

                //}
            }
            foreach (var item in sonuc)
            {

            }
            return View();
        }
    }
}
