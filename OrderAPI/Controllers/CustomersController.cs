using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using System.Web.Mvc;
using OrderAPI;

namespace OrderAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private dborderEntities db = new dborderEntities(); 
        public IHttpActionResult GetCustomer()
        {
            var query = (from c in db.Customer
                         select new
                         {
                             c.CustomerID,
                             c.CustomerName,
                             c.Address,
                             c.City
                         });
            var customers = query.ToList();
            return Ok(customers);
        }

        // GET: api/Customers/5    
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // PUT: api/Order/5    
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }
            db.Entry(customer).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers    
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customer.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5    
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            db.Customer.Remove(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customer.Count(e => e.CustomerID == id) > 0;
        }
    }


}
