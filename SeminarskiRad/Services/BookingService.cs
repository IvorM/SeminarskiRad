using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using SeminarskiRad.Models.Context.SeminarContext;

namespace SeminarskiRad.Services
{
    public class BookingService
    {
        private SeminarContext db;

        public BookingService()
        {
            db = new SeminarContext();
        }

        public IEnumerable<Seminar> GetSeminarsForBooking()
        {
            return db.Seminars.Where(s => s.Closed == false);
        }

        public bool CreateBooking(Booking booking)
        {
            try
            {
                booking.BookingDate=DateTime.Today;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }       
        }

    }
}