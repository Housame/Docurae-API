using DocuraeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Route("client/{clientId}/settings/")]
    [Route("client/settings/")]
    public class SettingsController: Controller
    {
        private readonly ISettingsRepository _repository;

        public SettingsController(ISettingsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            var model = await _repository.GetSettingsAsync();
            return Ok(model);
        }
    }
}
