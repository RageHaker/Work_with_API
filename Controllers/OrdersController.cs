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
using TradeWebAPI.Models; /// !

namespace TradeWebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private TradeEntities db = new TradeEntities();

        // GET: api/Orders
        [ResponseType(typeof(List<ResponseTrade>))] /// !
        public IHttpActionResult GetOrder() /// rename
        {
            return Ok(db.Order.ToList().ConvertAll(p => new ResponseTrade(p))); /// !
        }

        // GET: api/Orders/5
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

        // PUT: api/Orders/5
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

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
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