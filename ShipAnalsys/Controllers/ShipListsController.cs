using ShipAnalsys.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ShipAnalsys.Controllers
{
    public class ShipListsController : ApiController
    {
        private ShipAnalsysContext db = new ShipAnalsysContext();

        // GET: api/ShipLists
        public IQueryable<ShipList> GetShipLists()
        {
            return db.ShipLists;
        }

        // GET: api/ShipLists/5
        [ResponseType(typeof(ShipList))]
        public async Task<IHttpActionResult> GetShipList(int id)
        {
            ShipList shipList = await db.ShipLists.FindAsync(id);
            if (shipList == null)
            {
                return NotFound();
            }

            return Ok(shipList);
        }

        // PUT: api/ShipLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShipList(int id, ShipList shipList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipList.Id)
            {
                return BadRequest();
            }

            db.Entry(shipList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipListExists(id))
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

        // POST: api/ShipLists
        [ResponseType(typeof(ShipList))]
        public async Task<IHttpActionResult> PostShipList(ShipList shipList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShipLists.Add(shipList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shipList.Id }, shipList);
        }

        // DELETE: api/ShipLists/5
        [ResponseType(typeof(ShipList))]
        public async Task<IHttpActionResult> DeleteShipList(int id)
        {
            ShipList shipList = await db.ShipLists.FindAsync(id);
            if (shipList == null)
            {
                return NotFound();
            }

            db.ShipLists.Remove(shipList);
            await db.SaveChangesAsync();

            return Ok(shipList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShipListExists(int id)
        {
            return db.ShipLists.Count(e => e.Id == id) > 0;
        }
    }
}