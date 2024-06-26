using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nvd_lession09.Models;

namespace Nvd_lession09.Controllers
{
    public class SinhViensController : Controller
    {
        private K22CNT3_QLSVEntities db = new K22CNT3_QLSVEntities();

        // GET: SinhViens
        public ActionResult NvdIndex()
        {
            var sinhViens = db.SinhViens.Include(s => s.Khoa);
            return View(sinhViens.ToList());
        }

        // GET: SinhViens/Details/5
        public ActionResult NvdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult NvdCreate()
        {
            ViewBag.MaKH = new SelectList(db.Khoas, "MakH", "TenKH");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvdCreate([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKH,HocBong,DiemTB")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("NvdIndex");
            }

            ViewBag.MaKH = new SelectList(db.Khoas, "MakH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult NvdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.Khoas, "MakH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvdEdit([Bind(Include = "MaSV,HoSV,TenSV,Phai,NgaySinh,NoiSinh,MaKH,HocBong,DiemTB")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvdIndex");
            }
            ViewBag.MaKH = new SelectList(db.Khoas, "MakH", "TenKH", sinhVien.MaKH);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult NvdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("NvdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
            db.SaveChanges();
            return RedirectToAction("NvdIndex");
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
