using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {


                Client client = await clientDB.Clients.FindAsync(id);

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
        public async Task<IHttpActionResult> Post([FromBody] Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                clientDB.Clients.Add(client);
                await clientDB.SaveChangesAsync();
                return Ok("Add");

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

        // PUT: api/Client/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Client client)
        {
            try
            {

                Client ClientThatMatchId = await clientDB.Clients.FindAsync(id);
                if (client != null)
                {
                    ClientThatMatchId.ClientName =  client.ClientName;
                    ClientThatMatchId.ClientNameLast =client.ClientNameLast;

                }
                await clientDB.SaveChangesAsync();
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
        public async Task <IHttpActionResult> Delete(int id)
        {
            try
            {
                Client client = await clientDB.Clients.FindAsync(id);
                clientDB.Clients.Remove(client);
                await clientDB.SaveChangesAsync();
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

