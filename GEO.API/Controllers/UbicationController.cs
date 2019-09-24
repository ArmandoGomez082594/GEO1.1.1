

namespace GEO.API.Controllers
{
    u
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using GEO.Domain;

    [Authorize]
    public class UbicationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ubication
        public IQueryable<Ubication> GetUbications()
        {
            return db.Ubications;
        }

        // GET: Ubication/Details/5
        [ResponseType(typeof(Ubication))]
        public async Task<IHttpActionResult> GetUbication(int id)
        {
            Ubication ubication = await db.Ubications.findAsync(id);
            if (ubication == null)
            {
                return NotFound();
            }

            return Ok(ubication);

        }
        // PUT: Ubication/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUbication(int id, Ubication ubication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubication.UbicationId)
            {
                return BadRequest();
            }

            db.Entry(ubication).State = EntityState.Modified;

            try
            {
                await db.SaveChangeAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!UbicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: Ubication/Create
        [ResponseType(typeof(Ubication))]
        public async Task<ActionResult> PostUbication(Ubication ubication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ubications.Add(ubication);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ubication.UbicationId }, ubication);
        }









        // POST: Ubication/Delete/5
        [HttpPost]
        public async Task<IHttpActionResult}> Delete(int id);
        {
            Ubication ubication = await db.Ubications.FyndAsync(id);
            if (ubication = null)
	{
        return NotFound();
	}
        db.Ubications.Remove(ubication);
        await db.SaveChangeAsync();
return ok(ubication);
        }
    }
}
