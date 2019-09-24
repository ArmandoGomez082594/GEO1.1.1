using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;



//pedir nombre de DB así como nombre de los campos para mañana.
namespace GEO.Backend.Controllers
{
    using System.Data.Entity;
    using GEO.Backend.Models;
    using GEO.Domain;
    public class UbicationController : Controller
    {

        private DataContextLocal db = new DataContextLocal();
        // GET: Ubication
        public  async Task<ActionResult> Index()
        {
            return View(await db.Ubications.ToListAsync();
        }

        // GET: Ubication/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ubication ubication = await db.Ubications.FindAsync(id);
            if(ubication == null)
            {
                return HttpNotFound();
            }
            return View(ubication);
        }

        // GET: Ubication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ubication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="UbicationId,Description,Address,Phone,Latitude,Longitude")] Ubication ubication)
        {
            if(ModelState.IsValid)
            {
                db.Ubications.Add(ubication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
                return View(ubication);
        }

        // GET: Ubication/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ubication ubication = await db.Ubications.FindAsync(id);

            if(ubication == null)
            {
                return HttpNotFound();
            }

            return View(ubication);

           
        }

        // POST: Ubication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UbicationId,Description,Address,Phone,Latitude,Longitude")] Ubication ubication)
        {
            if (ModeIsState.IsValid)
            {
                db.Ubications.Add(ubication);
                await db.SavedChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ubication);

        }

        // GET: Ubication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ubication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {

            Ubication ubication = await db.Ubications.FindAsync(id);
            db.Ubications.Remove(ubication);
            await db.SaveChangesAsync();
            return RedirectToAction("Indes");
             
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
