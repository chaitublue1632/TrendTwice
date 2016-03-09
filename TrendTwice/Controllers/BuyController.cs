using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendTwice.Models;
using TrendTwice.Services;

namespace TrendTwice.Controllers
{
    public class BuyController : Controller
    {
        ProductsRepository _repository = new ProductsRepository();

        
        public ActionResult Index(int id)
        {
            Sale selectedItem = _repository.GetListingById(id);
            return View(selectedItem);
        }
    }
}