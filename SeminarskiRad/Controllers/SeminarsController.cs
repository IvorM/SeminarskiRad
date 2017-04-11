using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeminarskiRad.Models.Context.SeminarContext;
using Microsoft.AspNet;
using SeminarskiRad.Services;

namespace SeminarskiRad.Controllers
{
    [Authorize]
    public class SeminarsController : Controller
    {     
        private SeminarService ss=new SeminarService();

        public ActionResult GetSeminars()
        {
            return View("_Seminars", ss.GetSeminars());
        }

        public ActionResult SeminarsList()
        {
            return View("Seminars");
        }

        public ActionResult GetBookings(int id)
        {
            return View("_Bookings", ss.GetBookings(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SeminarDescription,SeminarDate,Teacher,MaxStudents,Closed")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                if (ss.CreateSeminar(seminar))
                {
                    return Json(new {status = "success", message = "Uspješno spremljeno"});
                }
                return Json(new { status = "error", message = "Greška prilikom spremanja" });
            }

            return Json(new { status = "error", message = "Greška prilikom spremanja" });
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = ss.FindSeminar(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SeminarDescription,SeminarDate,Teacher,MaxStudents,Closed")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                if (ss.SeminarEdit(seminar))
                {
                    return Json(new { status = "success", message = "Uspješno spremljeno" });
                }
                return Json(new { status = "error", message = "Greška prilikom spremanja" });
            }
            return Json(new { status = "error", message = "Greška prilikom spremanja" });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { status = "error", message = "Greška prilikom brisanja unosa" });
            }

            if (ss.DeleteSeminar(id.Value))
            {
                return Json(new { status = "success", message = "Uspješno obrisan odabrani seminar" });
            }

            return Json(new { status = "error", message = "Greška prilikom brisanja unosa" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Close(int? id)
        {
            if (id == null)
            {
                return Json(new { status = "error", message = "Greška prilikom zatvaranja seminara" });
            }

            if (ss.CloseSeminar(id.Value))
            {
                return Json(new { status = "success", message = "Uspješno zatvoren odabrani seminar" });
            }

            return Json(new { status = "error", message = "Greška prilikom zatvaranja seminara" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return Json(new { status = "error", message = "Greška prilikom promjene" });
            }

            if (ss.Approve(id.Value))
            {
                return Json(new { status = "success", message = "Uspješno odobreno" });
            }

            return Json(new { status = "error", message = "Greška prilikom promjene" });
        }
    }
}
