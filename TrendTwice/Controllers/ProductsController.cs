using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrendTwice.Models;
using TrendTwice.Services;

namespace TrendTwice.Controllers
{
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        ProductsRepository _repository = new ProductsRepository();

        [HttpGet]
        [Route("listings")]
        public IHttpActionResult GetAll()
        {
            return Ok(_repository.GetAllListings());
        }

        [HttpGet]
        [Route("listings/{id}")]
        public IHttpActionResult GetListing(int id)
        {
            Sale sale = _repository.GetListingById(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }
    }
}
