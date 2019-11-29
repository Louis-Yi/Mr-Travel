using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Mr_Travel.Models;
using Mr_Travel.Utils;

namespace Mr_Travel.Controllers
{
    public class BookingsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bookings
        [ValidateInput(true)]
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Hotel);
            return View(bookings.ToList());
        }

        [ValidateInput(true)]
        public ActionResult Viewbooking()
        {
            var a = User.Identity.GetUserId();
            var Bookings = db.Bookings.Where(r => r.User_ID == a);
            return View(Bookings.ToList());
        }

        // GET: Bookings/Details/5
        [ValidateInput(true)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        [ValidateInput(true)]
        public ActionResult Create()
        {
            Booking booking = new Booking();
            booking.User_ID = User.Identity.GetUserId();
            //if (null == date)
                //return RedirectToAction("Index");
            //var d = date;
            //DateTime convertedDate = Convert.ToDateTime(d);
            //booking.Date = convertedDate;
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Hotel_Name");
            return View(booking);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(true)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,Date,User_ID,HotelId")] Booking booking)
        {
            int b = booking.HotelId;
            var e = db.Bookings.Where(f => f.HotelId == b);
            foreach (var c in e)
            {
                if (booking.Date.CompareTo(DateTime.Now) < 0)
                {
                    return Content("<script>alert('DateTime cannot before now, Please select another time'); window.location.herf='../Bookings/Index' </script>");
                }
            }
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                EmailAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Hotel_Name", booking.HotelId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        [ValidateInput(true)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Hotel_Name", booking.HotelId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,Date,User_ID,HotelId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(db.Hotels, "Id", "Hotel_Name", booking.HotelId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [ValidateInput(true)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [ValidateInput(true)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

        public async System.Threading.Tasks.Task<ActionResult> EmailAsync()
        {
            String toEmail = User.Identity.GetUserName();
            EmailSender es = new EmailSender();
            await es.SendAsync(toEmail);
            return null;
        }
    }
}
