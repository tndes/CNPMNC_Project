using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using CNPMNC_Project.Models;

namespace CNPMNC_Project.Controllers
{
    public class NHANVIENsController : Controller
    {
        private ProjectEntities db = new ProjectEntities();

        // GET: NHANVIENs
        public ActionResult Index(string searchString)
        {   
            var nHANVIENs = db.NHANVIENs.Include(n => n.CHUCVU).Include(n => n.PHONGBAN);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                nHANVIENs = nHANVIENs.Where(n => n.HOTENNV.Contains(searchString) || SqlFunctions.StringConvert((double)n.MANV).Contains(searchString));

            }
            return View(nHANVIENs.ToList());
        }
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[12] {
                new DataColumn("MANV"),
                new DataColumn("MAPB"),
                new DataColumn("MACV"),
                new DataColumn("HOTENNV"),
                new DataColumn("DIACHI"),
                new DataColumn("GIOITINH"),
                new DataColumn("NGAYSINH"),
                new DataColumn("CMND"),
                new DataColumn("QUEQUAN"),
                new DataColumn("SDT"),
                new DataColumn("DANTOC"),
                new DataColumn("SOBH")});
            var emps = from NHANVIEN in db.NHANVIENs.ToList() select NHANVIEN;
            foreach (var nHANVIEN in emps)
            {
                dt.Rows.Add(nHANVIEN.MANV, nHANVIEN.MAPB, nHANVIEN.MACV,
                    nHANVIEN.HOTENNV, nHANVIEN.DIACHI, nHANVIEN.GIOITINH,
                    nHANVIEN.NGAYSINH, nHANVIEN.CMND, nHANVIEN.QUEQUAN,
                    nHANVIEN.SDT, nHANVIEN.DANTOC, nHANVIEN.SOBH);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
        // GET: NHANVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV");
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB");
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,MAPB,MACV,HOTENNV,DIACHI,GIOITINH,NGAYSINH,CMND,QUEQUAN,SDT,DANTOC,SOBH,IMG_PATH")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,MAPB,MACV,HOTENNV,DIACHI,GIOITINH,NGAYSINH,CMND,QUEQUAN,SDT,DANTOC,SOBH,IMG_PATH")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAPB = new SelectList(db.PHONGBANs, "MAPB", "TENPB", nHANVIEN.MAPB);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
