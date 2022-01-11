using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers.api
{
    public class ClientController : ApiController
    {
        ModelContext clientDB = new ModelContext();
        // GET: api/Client
        public IHttpActionResult Get()
        {
            List<Client> clients = clientDB.Clients.ToList();
            return Ok(clients);
        }

        // GET: api/Client/5
        public IHttpActionResult Get(int id)
        {
            Client client = clientDB.Clients.Find(id);

            return Ok(client); ;
        }

        // POST: api/Client
        public IHttpActionResult Post([FromBody] Client client)
        {
            clientDB.Clients.Add(client);
            clientDB.SaveChanges();
            return Ok("Add");
        }

        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody] Client client)
        {
            Client ClientThatMatchId = clientDB.Clients.Find(id);
            if (client != null)
            {
                ClientThatMatchId.ClientName =  client.ClientName;
                ClientThatMatchId.ClientNameLast =client.ClientNameLast;

            }
            clientDB.SaveChanges();
            return Ok("Update");
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete(int id)
        {
            Client client = clientDB.Clients.Find(id);
            clientDB.Clients.Remove(client);
            return Ok("Delete");
        }
    }
}
