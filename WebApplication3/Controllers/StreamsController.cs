using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StreamsController : ApiController
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: api/Streams
        public IQueryable<Stream> GetStreams()
        {
            return db.Streams;
        }

        // GET: api/Streams/5
        [ResponseType(typeof(Stream))]
        public async Task<IHttpActionResult> GetStream(int id)
        {
            Stream stream = await db.Streams.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }

            return Ok(stream);
        }

        // PUT: api/Streams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStream(int id, Stream stream)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stream.Id)
            {
                return BadRequest();
            }

            db.Entry(stream).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreamExists(id))
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

        // POST: api/Streams
        [ResponseType(typeof(Stream))]
        public async Task<IHttpActionResult> PostStream(Stream stream)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Streams.Add(stream);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stream.Id }, stream);
        }

        // DELETE: api/Streams/5
        [ResponseType(typeof(Stream))]
        public async Task<IHttpActionResult> DeleteStream(int id)
        {
            Stream stream = await db.Streams.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }

            db.Streams.Remove(stream);
            await db.SaveChangesAsync();

            return Ok(stream);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StreamExists(int id)
        {
            return db.Streams.Count(e => e.Id == id) > 0;
        }
    }
}