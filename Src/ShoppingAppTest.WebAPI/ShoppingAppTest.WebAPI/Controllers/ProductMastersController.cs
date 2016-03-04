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
    public class ProductMastersController : ApiController
    {
        private ShoppingAppTestEntities db = new ShoppingAppTestEntities();

        // GET: api/ProductMasters
        public IQueryable<ProductMaster> GetProductMasters()
        {
            return db.ProductMasters;
        }

        // GET: api/ProductMasters/5
        [ResponseType(typeof(ProductMaster))]
        public IHttpActionResult GetProductMaster(decimal id)
        {
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return Ok(productMaster);
        }

        // PUT: api/ProductMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductMaster(decimal id, ProductMaster productMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productMaster.ProductID)
            {
                return BadRequest();
            }

            db.Entry(productMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
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

        // POST: api/ProductMasters
        [ResponseType(typeof(ProductMaster))]
        public IHttpActionResult PostProductMaster(ProductMaster productMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductMasters.Add(productMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productMaster.ProductID }, productMaster);
        }

        // DELETE: api/ProductMasters/5
        [ResponseType(typeof(ProductMaster))]
        public IHttpActionResult DeleteProductMaster(decimal id)
        {
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            db.ProductMasters.Remove(productMaster);
            db.SaveChanges();

            return Ok(productMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductMasterExists(decimal id)
        {
            return db.ProductMasters.Count(e => e.ProductID == id) > 0;
        }
    }
}