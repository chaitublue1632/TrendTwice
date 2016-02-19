using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrendTwice.Models;

namespace TrendTwice.Controllers
{
    public class DressController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Dress
        public ActionResult Index()
        {
            var dress = db.Dress.Include(d => d.DressCategories).Include(d => d.DressColors).Include(d => d.DressConditions).Include(d => d.DressFabric).Include(d => d.DressPhotos).Include(d => d.DressSize);
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
            ViewBag.CategoryId = new SelectList(db.DressCategories, "CategoryId", "Name");
            ViewBag.ColorId = new SelectList(db.DressColors, "ColorId", "Name");
            ViewBag.ConditionId = new SelectList(db.DressConditions, "ConditionId", "Name");
            ViewBag.FabricId = new SelectList(db.DressFabric, "FabricId", "Name");
            ViewBag.Id = new SelectList(db.DressPhotos, "DressId", "Path");
            ViewBag.SizeId = new SelectList(db.DressSize, "SizeId", "Name");
            ViewBag.Gender = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text");
            return View();
        }

        // POST: Dress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SizeId,ColorId,CategoryId,Price,Gender,FabricId,ConditionId,PieceCount,Name")] Dress dress)
        {
            if (ModelState.IsValid)
            {
                db.Dress.Add(dress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.DressCategories, "CategoryId", "Name", dress.CategoryId);
            ViewBag.ColorId = new SelectList(db.DressColors, "ColorId", "Name", dress.ColorId);
            ViewBag.ConditionId = new SelectList(db.DressConditions, "ConditionId", "Name", dress.ConditionId);
            ViewBag.FabricId = new SelectList(db.DressFabric, "FabricId", "Name", dress.FabricId);
            ViewBag.Id = new SelectList(db.DressPhotos, "DressId", "Path", dress.Id);
            ViewBag.SizeId = new SelectList(db.DressSize, "SizeId", "Name", dress.SizeId);
            ViewBag.Gender = new SelectList(new List<SelectListItem>()
            { new SelectListItem{ Text ="Male", Value = "1"}, new SelectListItem{ Text ="Female", Value = "2"}
            }, "Value", "Text");
            return View(dress);
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
            ViewBag.CategoryId = new SelectList(db.DressCategories, "CategoryId", "Name", dress.CategoryId);
            ViewBag.ColorId = new SelectList(db.DressColors, "ColorId", "Name", dress.ColorId);
            ViewBag.ConditionId = new SelectList(db.DressConditions, "ConditionId", "Name", dress.ConditionId);
            ViewBag.FabricId = new SelectList(db.DressFabric, "FabricId", "Name", dress.FabricId);
            ViewBag.Id = new SelectList(db.DressPhotos, "DressId", "Path", dress.Id);
            ViewBag.SizeId = new SelectList(db.DressSize, "SizeId", "Name", dress.SizeId);
            return View(dress);
        }

        // POST: Dress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SizeId,ColorId,CategoryId,Price,Gender,FabricId,ConditionId,PieceCount,Name")] Dress dress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.DressCategories, "CategoryId", "Name", dress.CategoryId);
            ViewBag.ColorId = new SelectList(db.DressColors, "ColorId", "Name", dress.ColorId);
            ViewBag.ConditionId = new SelectList(db.DressConditions, "ConditionId", "Name", dress.ConditionId);
            ViewBag.FabricId = new SelectList(db.DressFabric, "FabricId", "Name", dress.FabricId);
            ViewBag.Id = new SelectList(db.DressPhotos, "DressId", "Path", dress.Id);
            ViewBag.SizeId = new SelectList(db.DressSize, "SizeId", "Name", dress.SizeId);
            return View(dress);
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
