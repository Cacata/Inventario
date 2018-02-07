using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSSPruebaInventario.Models;

namespace TSSPruebaInventario.Controllers
{
    public class ProductoUbicacionsController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: ProductoUbicacions
        public ActionResult Index()
        {
            var productoUbicacions = db.ProductoUbicacions.Include(p => p.Producto).Include(p => p.Ubicacion);
            return View(productoUbicacions.ToList());
        }

        // GET: ProductoUbicacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoUbicacion productoUbicacion = db.ProductoUbicacions.Find(id);
            if (productoUbicacion == null)
            {
                return HttpNotFound();
            }
            return View(productoUbicacion);
        }

        // GET: ProductoUbicacions/Create
        public ActionResult Create()
        {
            ViewBag.IDProducto = new SelectList(db.Productoes, "ID", "Descripcion");
            ViewBag.IDUbicacion = new SelectList(db.Ubicacions, "ID", "Descripcion");
            return View();
        }

        // POST: ProductoUbicacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDProducto,IDUbicacion,Sucursal")] ProductoUbicacion productoUbicacion)
        {
            if (ModelState.IsValid)
            {
                db.ProductoUbicacions.Add(productoUbicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProducto = new SelectList(db.Productoes, "ID", "Descripcion", productoUbicacion.IDProducto);
            ViewBag.IDUbicacion = new SelectList(db.Ubicacions, "ID", "Descripcion", productoUbicacion.IDUbicacion);
            return View(productoUbicacion);
        }

        // GET: ProductoUbicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoUbicacion productoUbicacion = db.ProductoUbicacions.Find(id);
            if (productoUbicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProducto = new SelectList(db.Productoes, "ID", "Descripcion", productoUbicacion.IDProducto);
            ViewBag.IDUbicacion = new SelectList(db.Ubicacions, "ID", "Descripcion", productoUbicacion.IDUbicacion);
            return View(productoUbicacion);
        }

        // POST: ProductoUbicacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDProducto,IDUbicacion,Sucursal")] ProductoUbicacion productoUbicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoUbicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProducto = new SelectList(db.Productoes, "ID", "Descripcion", productoUbicacion.IDProducto);
            ViewBag.IDUbicacion = new SelectList(db.Ubicacions, "ID", "Descripcion", productoUbicacion.IDUbicacion);
            return View(productoUbicacion);
        }

        // GET: ProductoUbicacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoUbicacion productoUbicacion = db.ProductoUbicacions.Find(id);
            if (productoUbicacion == null)
            {
                return HttpNotFound();
            }
            return View(productoUbicacion);
        }

        // POST: ProductoUbicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoUbicacion productoUbicacion = db.ProductoUbicacions.Find(id);
            db.ProductoUbicacions.Remove(productoUbicacion);
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
