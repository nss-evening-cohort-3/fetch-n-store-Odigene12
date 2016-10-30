using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchNStore.Models;

namespace FetchNStore.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context { get; set; }
        public ResponseRepository()
        {
            Context = new ResponseContext();
        }

        public ResponseRepository(ResponseContext context)
        {
            Context = context;
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList();
        }

        public Response GetResponses(string myURL)
        {
            Response foundResponse = Context.Responses.First(response => response.URL == myURL);

            return foundResponse;
        }

        public void StoreResponse(Response response)
        {
            Context.Responses.Add(response);

        }
    }
}