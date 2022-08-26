using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Utility.Dtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountsController: ControllerBase
    {
        private readonly IServiceManager _service;

        public AccountsController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await _service.AccountService.GetAllAccounts(false));
        }

        [HttpGet("{id}", Name="GetAccount")]
        public async Task<IActionResult> GetAccount(Guid id)
        {
            return Ok(await _service.AccountService.GetAccountAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountWriteDto accountWriteDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var accountReadDto = await _service.AccountService.CreateAccountAsync(accountWriteDto);
            return CreatedAtRoute(nameof(GetAccount), new {id = accountReadDto.Id}, accountReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] AccountUpdateDto accountUpdateDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.AccountService.UpdateAccount(id, accountUpdateDto, true);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
           await _service.AccountService.DeleteAccountAsync(id, false);
            return NoContent();
        }

    }
}
