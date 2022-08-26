using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await _service.AccountService.GetAllAccounts(false));
        }

    }
}
