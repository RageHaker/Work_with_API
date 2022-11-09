using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TradeWebAPI.DataBase;

namespace TradeWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private TradeEntities db = new TradeEntities();

        // GET: api/Products
        public IQueryable<Product> GetProduct()
        {
            return db.Product;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(string id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(string id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductArticleNumber)
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductArticleNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.ProductArticleNumber }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(string id)
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

        private bool ProductExists(string id)
        {
            return db.Product.Count(e => e.ProductArticleNumber == id) > 0;
        }
    }
}