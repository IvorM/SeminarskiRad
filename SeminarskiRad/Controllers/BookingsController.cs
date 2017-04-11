using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeminarskiRad.Models.Context.SeminarContext;
using SeminarskiRad.Services;

namespace SeminarskiRad.Controllers
{
    public class BookingsController : Controller
    {
        private SeminarContext db = new SeminarContext();
        private BookingService bs=new BookingService();


        public ActionResult GetBookings()
        {
            return View("_Predbiljezbe",bs.GetSeminarsForBooking());
        }

        public ActionResult BookingsList()
        {
            return View("Predbiljezbe");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,BookingDate,StudentName,StudentSurname,StudentAddress,SeminarID,Approved")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                if (bs.CreateBooking(booking))
                {
                    return Json(new { status = "success", message = "Uspješno spremljeno" });
                }

                return Json(new { status = "error", message = "Greška prilikom spremanja" });
            }

            return Json(new { status = "error", message = "Greška prilikom spremanja" });
        }

    }
}
