using ShipAnalsys.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ShipAnalsys.Controllers
{
    public class ShipDatasController : ApiController
    {
        private ShipAnalsysContext db = new ShipAnalsysContext();

        [Route("api/shipdatas/{startDate}/{endDate}")]
        [HttpGet]
        public IQueryable GetAllDatas(string startDate, string endDate)
        {
            IFormatProvider KR_Format = new System.Globalization.CultureInfo("ko-KR", true);
            DateTime startdateInput = DateTime.ParseExact(startDate, "yyyyMMddHHmmss", KR_Format);
            DateTime enddateInput = DateTime.ParseExact(endDate, "yyyyMMddHHmmss", KR_Format);

            var shipdataout =
                from s in db.ShipDatas
                where s.date >= startdateInput && s.date <= enddateInput
                select s;

            return shipdataout;
        }

        [Route("api/shipdatas/{startDate}/{endDate}/{interval}")]
        [HttpGet]
        public IQueryable GetShipDatas(string startDate, string endDate, int interval)
        {
            IFormatProvider KR_Format = new System.Globalization.CultureInfo("ko-KR", true);
            DateTime startdateInput = DateTime.ParseExact(startDate, "yyyyMMddHHmmss", KR_Format);
            DateTime enddateInput = DateTime.ParseExact(endDate, "yyyyMMddHHmmss", KR_Format);

            var shipdataout1 =
            from s in db.ShipDatas
            where s.date >= startdateInput && s.date <= enddateInput
            group s by new
            {
                s.date.Year,
                s.date.Month,
                s.date.Day,
                s.date.Hour,
                Minute = (s.date.Minute / interval)
            } into groupData
            orderby groupData.Key.Year, groupData.Key.Month, groupData.Key.Day, groupData.Key.Hour, groupData.Key.Minute ascending
            let prev = db.ShipDatas.GroupBy(a => new {
                a.date.Year,
                a.date.Month,
                a.date.Day,
                a.date.Hour,
                Minute = (a.date.Minute / interval)
            }).Where(x => DbFunctions.CreateDateTime(x.Key.Year, x.Key.Month, x.Key.Day, x.Key.Hour, x.Key.Minute * interval, 0) < DbFunctions.CreateDateTime(groupData.Key.Year, groupData.Key.Month, groupData.Key.Day, groupData.Key.Hour, groupData.Key.Minute * interval, 0)).FirstOrDefault()

            select new

            {
                tt = prev,

                now = groupData.Select(d => d.date),
                prevdate = prev.Select(d=>d.date),


             //   // 여기서 해야 된다.
             //   date = DbFunctions.CreateDateTime(groupData.Key.Year, groupData.Key.Month, groupData.Key.Day, groupData.Key.Hour, groupData.Key.Minute * interval, 0),


                


             //   spp =
             //from prod2 in groupData

             //    //where prod2.draughtAft > groupData.Average(prod3 => prod3.draughtAft - 100)
             //select new
             //{
             //    arspro = ((1 / (DbFunctions.StandardDeviationP(groupData.Select(d => d.flowMeterMeHfo)) * SqlFunctions.SquareRoot(2 * Math.PI))) * (Math.Pow(Math.E, (-1 * Math.Pow((double)(prod2.flowMeterMeHfo - groupData.Average(d => d.flowMeterMeHfo)), 2) / (2 * Math.Pow((double)(DbFunctions.StandardDeviationP(groupData.Select(d => d.flowMeterMeHfo))), 2))))) * groupData.Count() > 0.5) | DbFunctions.StandardDeviationP(groupData.Select(d => d.speedVs)) > 3 ? true : false,
             //    //tt = prod2.draughtAft - prev.av draughtAft;


             //},

              
             //   speedVs = DbFunctions.StandardDeviationP(groupData.Select(d => d.speedVs)),
             //   speedVg = DbFunctions.StandardDeviationP(groupData.Select(d => d.speedVg)),
             //   powerDel = groupData.Average(d => d.powerDel),
             //   relWindDir = groupData.Average(d => d.relWindDir),
             //   relWindSpd = groupData.Average(d => d.relWindSpd),
             //   headingGps = groupData.Average(d => d.headingGps),
             //   shaftRev = DbFunctions.StandardDeviationP(groupData.Select(d => d.shaftRev)),
             //   draughtFore = groupData.Average(d => d.draughtFore),
             //   draughtAft = groupData.Average(d => d.draughtAft),
             //   waterDepth = groupData.Average(d => d.waterDepth),
             //   rudderAngle = DbFunctions.StandardDeviationP(groupData.Select(d => d.rudderAngle)),
             //   seawaterTemp = groupData.Average(d => d.seawaterTemp),
             //   flowMeterMeHfo = groupData.Average(d => d.flowMeterMeHfo),
             //   shaftTorque = groupData.Average(d => d.shaftTorque)
            };

            var i = 0;
            //var shipout = from n in shipdataout1
            //              where 


            return shipdataout1;
        }

        // GET: api/ShipDatas/5
        [ResponseType(typeof(ShipData))]
        public async Task<IHttpActionResult> GetShipData(Int64 id)
        {
            ShipData shipData = await db.ShipDatas.FindAsync(id);
            if (shipData == null)
            {
                return NotFound();
            }

            return Ok(shipData);
        }

        // PUT: api/ShipDatas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShipData(Int64 id, ShipData shipData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipData.Id)
            {
                return BadRequest();
            }

            db.Entry(shipData).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipDataExists(id))
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

        // POST: api/ShipDatas
        [ResponseType(typeof(ShipData))]
        public async Task<IHttpActionResult> PostShipData(ShipData shipData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShipDatas.Add(shipData);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShipDataExists(shipData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shipData.Id }, shipData);
        }

        // DELETE: api/ShipDatas/5
        [ResponseType(typeof(ShipData))]
        public async Task<IHttpActionResult> DeleteShipData(Int64 id)
        {
            ShipData shipData = await db.ShipDatas.FindAsync(id);
            if (shipData == null)
            {
                return NotFound();
            }

            db.ShipDatas.Remove(shipData);
            await db.SaveChangesAsync();

            return Ok(shipData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShipDataExists(Int64 id)
        {
            return db.ShipDatas.Count(e => e.Id == id) > 0;
        }
    }
}