using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using System.Web.Mvc;
using OrderAPI;

namespace OrderAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private dborderEntities db = new dborderEntities();
        public IHttpActionResult GetProduct()
        {
            var query = (from c in db.Product
                         select new
                         {
                             c.ProductID,
                             c.ProductName,
                             c.Price
                         });
            var products = query.ToList();
            return Ok(products);
        }

        // GET: api/products/5    
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/products/5    
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.ProductID)
            {
                return BadRequest();
            }
            db.Entry(product).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/products    
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostCustomer(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Product.Add(product);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/products/5    
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.ProductID == id) > 0;
        }
    }


}
