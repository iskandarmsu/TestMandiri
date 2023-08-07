using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OrderAPI;

using System.Web.Mvc;

namespace OrderAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private dborderEntities db = new dborderEntities();
        public IHttpActionResult GetOrder()
        {
            var query = (from o in db.Order
                         join c in db.Customer on o.CustomerID equals c.CustomerID
                         join p in db.Product on o.ProductID equals p.ProductID
                         select new
                         {
                             o.OrderID,
                             o.OrderDate,
                             o.CustomerID,
                             c.CustomerName,
                             c.Address,
                             o.RequiredDate,
                             o.OrderName,
                             o.ProductID,
                             p.ProductName,
                             p.Price,
                             o.Qty,
                             o.Harga,
                             o.Total
                         });

            var orders = query.ToList();
            return Ok(orders);
        }

        // GET: api/Order/5    
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // PUT: api/Order/5    
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != order.OrderID)
            {
                return BadRequest();
            }
            db.Entry(order).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order    
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostCustomer(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Order.Add(order);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
        }

        // DELETE: api/Order/5    
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            db.Order.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Order.Count(e => e.OrderID == id) > 0;
        }
    }
}
