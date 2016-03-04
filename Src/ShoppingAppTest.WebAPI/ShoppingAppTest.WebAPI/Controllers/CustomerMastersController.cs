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
using ShoppingAppTest.WebAPI.Models;

namespace ShoppingAppTest.WebAPI.Controllers
{
    public class CustomerMastersController : ApiController
    {
        private ShoppingAppTestEntities db = new ShoppingAppTestEntities();

        // GET: api/CustomerMasters
        public IQueryable<CustomerMaster> GetCustomerMasters()
        {
            return db.CustomerMasters;
        }

        // GET: api/CustomerMasters/5
        [ResponseType(typeof(CustomerMaster))]
        public IHttpActionResult GetCustomerMaster(decimal id)
        {
            CustomerMaster customerMaster = db.CustomerMasters.Find(id);
            if (customerMaster == null)
            {
                return NotFound();
            }

            return Ok(customerMaster);
        }

        // PUT: api/CustomerMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerMaster(decimal id, CustomerMaster customerMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerMaster.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customerMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMasterExists(id))
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

        // POST: api/CustomerMasters
        [ResponseType(typeof(CustomerMaster))]
        public IHttpActionResult PostCustomerMaster(CustomerMaster customerMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerMasters.Add(customerMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerMaster.CustomerID }, customerMaster);
        }

        // DELETE: api/CustomerMasters/5
        [ResponseType(typeof(CustomerMaster))]
        public IHttpActionResult DeleteCustomerMaster(decimal id)
        {
            CustomerMaster customerMaster = db.CustomerMasters.Find(id);
            if (customerMaster == null)
            {
                return NotFound();
            }

            db.CustomerMasters.Remove(customerMaster);
            db.SaveChanges();

            return Ok(customerMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerMasterExists(decimal id)
        {
            return db.CustomerMasters.Count(e => e.CustomerID == id) > 0;
        }
    }
}