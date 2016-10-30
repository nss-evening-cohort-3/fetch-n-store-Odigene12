using FetchNStore.DAL;
using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FetchNStore.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository myrepo = new ResponseRepository();
        // GET api/<controller>
        public IEnumerable<Response> Get()
        {
            return myrepo.GetResponses();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>

        public void Post([FromBody]Response response)
        {
            myrepo.StoreResponse(response);
            myrepo.Context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}