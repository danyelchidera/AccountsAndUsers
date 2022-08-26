using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Dtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/accounts/{accountId}/[Controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IServiceManager _service;

        public UsersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountUsers(Guid accountId)
        {
            return Ok(await _service.UserService.GetAccountUsersAsync(accountId, false, false));
        }

        [HttpGet("{id}", Name = "GetAccountUserById")]
        public async Task<IActionResult> GetAccountUserById(Guid id, Guid accountId)
        {
            return Ok(await _service.UserService.GetAccountUserByIdAsync(accountId, id, false, false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountUser(Guid accountId, [FromBody] UserWriteDto user)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var userReadDto = await _service.UserService.CreateAccountUser(accountId, user, false);
            return CreatedAtRoute(nameof(GetAccountUserById), new { accountId, id = userReadDto.Id}, userReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateAccountUser(Guid accountId, Guid id, 
            [FromBody] UserUpdateDto user)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.UserService.UpdateAccountUser(accountId, id, user, false, true);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountUser(Guid accountId, Guid id)
        {
            await _service.UserService.DeleteAccountUser(accountId, id, false, false);
            return NoContent();
        }



    }
}
