using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using SeminarskiRad.Models.Context.SeminarContext;

namespace SeminarskiRad.Services
{
    public class SeminarService
    {
        private SeminarContext db;

        public SeminarService()
        {
            db=new SeminarContext();
        }

        public IEnumerable<Seminar> GetSeminars()
        {
            return db.Seminars;
        }

        public bool DeleteSeminar(int seminarID)
        {
            try
            {
                db.Seminars.Remove(db.Seminars.Find(seminarID));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }

        public bool CloseSeminar(int seminarID)
        {
            try
            {
                var seminar = db.Seminars.Find(seminarID);
                seminar.Closed = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SeminarEdit(Seminar seminar)
        {
            try
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool Approve(int studentID)
        {
            try
            {
                var booking = db.Bookings.Find(studentID);
                if (booking.Seminar.MaxStudents>booking.Seminar.Bookings.Where(b=>b.Approved).Count())
                {
                    booking.Approved = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    booking.Seminar.Closed = true;
                    db.SaveChanges();
                }
                return false;
            }
            catch (Exception)
            {
                
               return false;
            }
        }

        public IEnumerable<Booking> GetBookings(int id)
        {
            try
            {
                return db.Seminars.Find(id).Bookings;
            }
            catch (Exception)
            {
                
                return new List<Booking>();
            }
        }

        public bool CreateSeminar(Seminar seminar)
        {
            try
            {
                db.Seminars.Add(seminar);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public Seminar FindSeminar(int? id)
        {
            return db.Seminars.Find(id);
        }
    }
}