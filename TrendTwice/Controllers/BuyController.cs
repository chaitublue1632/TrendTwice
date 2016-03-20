using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendTwice.Models;
using TrendTwice.Services;
using TrendTwice.ViewModels;
using TrendTwice.App_Code;

namespace TrendTwice.Controllers
{
    public class BuyController : Controller
    {
        ProductsRepository _repository = new ProductsRepository();
        private dbModel db = new dbModel();
        
        public ActionResult Index(int id)
        {
            if (string.IsNullOrEmpty(HttpHelpers.GetCookie("TrendTwiceSessionId")))
            {
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);
                HttpHelpers.SetCookie("TrendTwiceSessionId", HttpHelpers.GetSessionId(), ts);
            }
            Sale selectedItem = _repository.GetListingById(id);
            return View(selectedItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(int listingId)
        {
            Sale selectedItem = _repository.GetListingById(listingId);
            CheckoutViewModel cvm = new CheckoutViewModel();
            cvm.SaleItem = selectedItem;
            string sessionId = HttpHelpers.GetCookie("TrendTwiceSessionId");
            Checkout existingCheckout = db.Checkout
                                        .Where(x => x.SessionId == sessionId && x.ListingId == listingId)
                                        .FirstOrDefault();
            if (existingCheckout == null)
            {
                Checkout newCheckout = new Checkout
                {
                    ListingId = listingId,
                    UserId = 1,
                    StatusId = 1,
                    Finished = false,
                    TimeStamp = DateTime.Now,
                    SessionId = sessionId
                };
                db.Checkout.Add(newCheckout);
                db.SaveChanges();
                int checkoutId = newCheckout.CheckoutId;
                cvm.Checkout = newCheckout;
            }
            else
            {
                cvm.Checkout = existingCheckout;
            }            
            
            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(CheckoutViewModel checkoutViewModel)
        {
            if (ModelState.IsValid)
            {
                Payments payment = new Payments
                {
                    Amount = checkoutViewModel.CreditCard.Amount,
                    CheckoutId = checkoutViewModel.Checkout.CheckoutId,
                    HasFailed = false,
                    PaymentType = 1
                };
                db.Payments.Add(payment);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View("Checkout", checkoutViewModel);
            }
        }

        [HttpGet]
        public ActionResult Pay()
        {
            return View();
        }
    }
}