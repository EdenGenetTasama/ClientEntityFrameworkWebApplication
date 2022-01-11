using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            try
            {
                List<Client> clients = clientDB.Clients.ToList();
                return Ok(clients);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Client/5
        public IHttpActionResult Get(int id)
        {
            try
            {


                Client client = clientDB.Clients.Find(id);

                return Ok(client);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Client
        public IHttpActionResult Post([FromBody] Client client)
        {
            try
            {
                clientDB.Clients.Add(client);
                clientDB.SaveChanges();
                return Ok("Add");
                   catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody] Client client)
        {
            try
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
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Client client = clientDB.Clients.Find(id);
                clientDB.Clients.Remove(client);
                return Ok("Delete");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
