using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrendTwice.Models;
using TrendTwice.ViewModels;

namespace TrendTwice.Controllers
{
    public class DressController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Dress
        public ActionResult Index()
        {
            var dress = db.Dress.Include(d => d.DressCategories).
                                 Include(d => d.DressColors).
                                 Include(d => d.DressConditions).
                                 Include(d => d.DressFabric).
                                 Include(d => d.DressPhotos).
                                 Include(d => d.DressSize);
            return View(dress.ToList());
        }

        // GET: Dress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dress dress = db.Dress.Find(id);
            if (dress == null)
            {
                return HttpNotFound();
            }
            return View(dress);
        }

        // GET: Dress/Create
        public ActionResult Create()
        {
            DressViewModel viewModel = new DressViewModel();
            viewModel.Categories = new SelectList(db.DressCategories, "CategoryId", "Name", viewModel.CategoryId);
            viewModel.Conditions = new SelectList(db.DressConditions, "ConditionId", "Name", viewModel.ConditionId);
            viewModel.Fabrics = new SelectList(db.DressFabric, "FabricId", "Name", viewModel.FabricId);
            viewModel.Colors = new SelectList(db.DressColors, "ColorId", "Name", viewModel.ColorId);
            viewModel.Sizes = new SelectList(db.DressSize, "SizeId", "Name", viewModel.SizeId);
            viewModel.Genders = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text", viewModel.Gender);

            return View(viewModel);
        }

        // POST: Dress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DressViewModel dressModel)
        {

            if (ModelState.IsValid)
            {
                Dress newDress = new Dress
                {
                    CategoryId = dressModel.CategoryId,
                    ConditionId = dressModel.ConditionId,
                    FabricId = dressModel.FabricId,
                    ColorId = dressModel.ColorId,
                    SizeId = dressModel.SizeId,
                    Name = dressModel.Name,
                    Price = dressModel.Price,
                    Gender = dressModel.Gender,
                    PieceCount = dressModel.PieceCount
                };

                db.Dress.Add(newDress);
                db.SaveChanges();

                int identityVal = newDress.Id;

                if(identityVal > 0)
                {
                    Listings newListing = new Listings
                    {
                        Active = true,
                        DressId = identityVal,
                        UserId = 1000,
                        Status = 1,
                        Likes = 0,
                        CreatedDate = DateTime.Now
                    };

                    db.Listings.Add(newListing);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            DressViewModel viewModel = new DressViewModel();
            viewModel.Categories = new SelectList(db.DressCategories, "CategoryId", "Name", viewModel.CategoryId);
            viewModel.Conditions = new SelectList(db.DressConditions, "ConditionId", "Name", viewModel.ConditionId);
            viewModel.Fabrics = new SelectList(db.DressFabric, "FabricId", "Name", viewModel.FabricId);
            viewModel.Colors = new SelectList(db.DressColors, "ColorId", "Name", viewModel.ColorId);
            viewModel.Sizes = new SelectList(db.DressSize, "SizeId", "Name", viewModel.SizeId);
            viewModel.Genders = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text", viewModel.Gender);

            return View(viewModel);
        }

        // GET: Dress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dress dress = db.Dress.Find(id);
            if (dress == null)
            {
                return HttpNotFound();
            }

            DressViewModel viewModel = new DressViewModel();
            viewModel.Categories = new SelectList(db.DressCategories, "CategoryId", "Name", viewModel.CategoryId);
            viewModel.Conditions = new SelectList(db.DressConditions, "ConditionId", "Name", viewModel.ConditionId);
            viewModel.Fabrics = new SelectList(db.DressFabric, "FabricId", "Name", viewModel.FabricId);
            viewModel.Colors = new SelectList(db.DressColors, "ColorId", "Name", viewModel.ColorId);
            viewModel.Sizes = new SelectList(db.DressSize, "SizeId", "Name", viewModel.SizeId);
            viewModel.Genders = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text", dress.Gender);
            viewModel.Id = dress.Id;
            viewModel.CategoryId = dress.CategoryId;
            viewModel.ConditionId = dress.ConditionId;
            viewModel.FabricId = dress.FabricId;
            viewModel.ColorId = dress.ColorId;
            viewModel.Price = dress.Price;
            viewModel.PieceCount = dress.PieceCount;
            viewModel.Gender = dress.Gender;

            return View(viewModel);
        }

        // POST: Dress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DressViewModel dressViewModel)
        {
            if (ModelState.IsValid)
            {
                Dress dress = new Dress
                {
                    Id = dressViewModel.Id,
                    CategoryId = dressViewModel.CategoryId,
                    ConditionId = dressViewModel.ConditionId,
                    FabricId = dressViewModel.FabricId,
                    ColorId = dressViewModel.ColorId,
                    SizeId = dressViewModel.SizeId,
                    Name = dressViewModel.Name,
                    Price = dressViewModel.Price,
                    Gender = dressViewModel.Gender,
                    PieceCount = dressViewModel.PieceCount
                };

                db.Entry(dress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            DressViewModel viewModel = new DressViewModel();
            viewModel.Categories = new SelectList(db.DressCategories, "CategoryId", "Name", viewModel.CategoryId);
            viewModel.Conditions = new SelectList(db.DressConditions, "ConditionId", "Name", viewModel.ConditionId);
            viewModel.Fabrics = new SelectList(db.DressFabric, "FabricId", "Name", viewModel.FabricId);
            viewModel.Colors = new SelectList(db.DressColors, "ColorId", "Name", viewModel.ColorId);
            viewModel.Sizes = new SelectList(db.DressSize, "SizeId", "Name", viewModel.SizeId);
            viewModel.Genders = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text", viewModel.Gender);
            viewModel.Id = dressViewModel.Id;
            return View(viewModel);
        }

        // GET: Dress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dress dress = db.Dress.Find(id);
            if (dress == null)
            {
                return HttpNotFound();
            }
            return View(dress);
        }

        // POST: Dress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dress dress = db.Dress.Find(id);
            db.Dress.Remove(dress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
