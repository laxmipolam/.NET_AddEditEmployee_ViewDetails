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
    public class EmployeesController : ApiController
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: api/Employees
        public IQueryable<EmployeeTableDTO> GetEmployees()
        {
            var employees = from b in db.Employees
                        select new EmployeeTableDTO()
                        {
                            Id = b.Id,
                            FirstName  = b.FirstName,
                            LastName = b.LastName,
                            Email = b.Email,
                            IsActive = b.IsActive,
                            MobileNumber = b.MobileNumber,
                            CollegeName = b.College.Name
                        };

            return employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeePopupDTO))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            
            var employee = await db.Employees.Include(b => b.College).Select(b =>
            
         new EmployeePopupDTO()
         {
             Id = b.Id,
             FirstName = b.FirstName,
             LastName = b.LastName,
             Email = b.Email,
             MobileNumber = b.MobileNumber,
             CollegeName = b.College.Name,
             IsActive = b.IsActive,

         }).SingleOrDefaultAsync(b => b.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(employee).Reference(x => x.Stream).Load();

            var dto = new EmployeeTableDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
            };

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, dto);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}