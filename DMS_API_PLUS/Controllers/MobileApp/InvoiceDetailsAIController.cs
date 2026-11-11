using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsAIController : ControllerBase
    {
        private readonly IInvoiceDetailsAIRepository _repo;
        public InvoiceDetailsAIController(IInvoiceDetailsAIRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("InvoiceSave")]
        public async Task<IActionResult> InvoiceSave([FromForm] InvoiceDetailsAI model)
        {
            return Ok(await _repo.InvoiceSave(UserHelper.GetUser(User),model));
        }

        [HttpPost("MobileInvoiceSave")]
        public async Task<IActionResult> Save(InvoiceDetailsResponse input)
        {

            return Ok(await _repo.MobileInvoiceSave(UserHelper.GetUser(User), input));
        }

    }
}
