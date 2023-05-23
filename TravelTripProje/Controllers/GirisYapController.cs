using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
using System.Web.Security;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin ad)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullanici,false);
                Session["Kullanici"] = bilgi.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}