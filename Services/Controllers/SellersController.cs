using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;

namespace Services.Controllers
{
    public class SellersController : Controller
    {
        // GET: Sellers
        public ActionResult Index()
        {
            var seller = SellerManager.GetList();
            return View(seller);
        }
    }
}

