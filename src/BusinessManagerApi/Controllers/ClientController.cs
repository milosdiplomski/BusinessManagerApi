using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.Models;
using BusinessManager.Shared.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessManagerApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private ClientsBusinessLogic _clientsBusinessLogic;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IUnitOfWork unitOfWork, ILogger<ClientController> log)
        {
            _unitOfWork = unitOfWork;
            _logger = log;
            _clientsBusinessLogic = new ClientsBusinessLogic(_unitOfWork, _logger);
        }

        /// <summary>
        /// Insert client into database.
        /// </summary>
        /// <param name="client"></param>
        /// <response code="201">Successfully created</response>
        /// <response code="400">Bad request</response>
        [Route("CreateClient")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateClient([FromBody] Clients client)
        {
            try
            {
                var clientFromDb = await _clientsBusinessLogic.CreateClient(client);

                return Created(string.Concat("api/Client/", clientFromDb.Id), clientFromDb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets all clients from database.
        /// </summary>
        /// <param name="client"></param>
        /// <response code="200">Returns the list of items</response>
        /// <response code="400">Bad request</response>
        [Route("GetAllClients")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var clients = await _clientsBusinessLogic.GetAllClients();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Soft delete client in database.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Bad request</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SoftDeleteClient(Guid id)
        {
            try
            {
                await _clientsBusinessLogic.DeleteClient(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update client row in database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Bad request</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Clients client)
        {
            try
            {
                _clientsBusinessLogic.UpdateClient(id, client);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
