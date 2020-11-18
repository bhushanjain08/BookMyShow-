using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using api_test.Models;

namespace api_test.Controllers
{
    //[EnableCors(origins: "http://zenabbms.azurewebsites.net/api/Theatrecrud", headers: "*", methods: "*")]
    public class TheatrecrudController : ApiController
    {
        //GET - Retrieve data   -api/Theatrecrud
        public IHttpActionResult GetAllTheatres()
        {
            IList<TheatrecrudViewModel> theatrecruds = null;
            using (var x= new BMSEntities3())
            {
                theatrecruds = x.Theatrecruds.Select(t => new TheatrecrudViewModel()
                {
                    TheatreId = t.TheatreId,
                    TheatreName = t.TheatreName,
                    Location = t.Location
                }).ToList<TheatrecrudViewModel>();
                
            }
            if (theatrecruds.Count == 0)
                return NotFound();
            return Ok(theatrecruds);

        }
    }
}
