using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrendTwice.Models;
using TrendTwice.Services;

namespace TrendTwice.Controllers
{
    //[RoutePrefix("api")]
    public class ProductsController : Controller
    {
        ProductsRepository _repository = new ProductsRepository();

        [HttpGet]        
        public ActionResult GetAll()
        {
            return View(_repository.GetAllListings());
        }

        [HttpGet]        
        public ActionResult Listing(int id)
        {
            Sale sale = _repository.GetListingById(id);
            if (sale == null)
            {
                return Content("Item not found");
            }

            return View(sale);
        }
    }
}
