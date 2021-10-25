using DocuraeAPI.Models;
using DocuraeAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Route("client/{clientId}/logtext/")]
    [Route("client/logtext/")]
    public class LogTextController: Controller
    {
        private readonly ILogTextRepository _repository;

        public LogTextController(ILogTextRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetLogTextsAsync(int patientId)
        {
            var model = await _repository.GetLogTextsAsync(patientId);
            return Ok(model);
        }
        [HttpPost("{patientId}")]
        public async Task<IActionResult> SetLogTextAsync([FromBody] AddTextLogDTO newTextLog, int patientId)
        {
            await _repository.SetLogTextAsync(newTextLog, patientId);
            return Ok();
        }
        [HttpPost("reminder")]
        public async Task<IActionResult> AddReminderAsync([FromBody] AddReminderDTO obj)
        {
            await _repository.SetReminderAsync(obj);
            return Ok();
        }
        [HttpPost("addition")]
        public async Task<IActionResult> AddLTAdditionAsync([FromBody] AddTextLogAdditionsDTO lTAdditionsObj)
        {
            await _repository.SetNewAdditionAsync(lTAdditionsObj);
            return Ok();
        }
        [HttpDelete("{textLogID}")]
        public async Task<IActionResult> DeleteTextLogAsync(int textLogID)
        {
            await _repository.DeleteTextLogAsync(textLogID);
            return Ok();
        }

    }
}
