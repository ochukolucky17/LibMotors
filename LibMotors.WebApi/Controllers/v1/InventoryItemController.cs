using LibMotors.Application.Features.InventoryItemFeatures.Commands;
using LibMotors.Application.Features.InventoryItemFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibMotors.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InventoryItemController : BaseApiController
    {
        /// <summary>
        /// Creates a New InventoryItem.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateInventoryItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all InventoryItems.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAll_InventoryItemsQuery()));
        }
        /// <summary>
        /// Gets InventoryItem Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetInventoryItemByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes InventryItem Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInventoryItemByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the InventoryItem Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateInventoryItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
