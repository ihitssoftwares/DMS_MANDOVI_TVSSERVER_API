using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SAMPLE_API_PLUS.Helper;

namespace TVS_API_PLUS.Controllers.Custom
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MCareCustomerDetailsController : ControllerBase
    {
        private readonly McareApiClient _mcare;
        private readonly ILogger<MCareCustomerDetailsController> _logger;

        public MCareCustomerDetailsController(McareApiClient mcare, ILogger<MCareCustomerDetailsController> logger)
        {
            _mcare = mcare;
            _logger = logger;
        }
        [HttpGet("List")]
        public async Task<IActionResult> List(string RegNo, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(RegNo))
                return BadRequest(new { error = "RegNo is required." });

            try
            {
                var json = await _mcare.GetCustomerListAsync(RegNo.Trim(), ct);

                var data = JsonConvert.DeserializeObject<MCareCustomerDetails>(json);
                if (data?.List == null || data.List.Count == 0)
                    return NotFound(new { message = "This vehicle has no MCare." });

                return Content(json, "application/json");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Call to the Mandovi API failed.");
                return StatusCode(502, new { error = "Customer details are temporarily unavailable." });
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Create(MCareCustomerDetails model, CancellationToken  ct)
        {
            if (model == null)
                return BadRequest(new { error = "Request body is required." });

            try
            {
                // Forwarded to the Mandovi API, which saves it through the stored procedure
                var body = JsonConvert.SerializeObject(model);
                var json = await _mcare.SaveCustomerAsync(body, ct);
                return Content(json, "application/json");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Save to the Mandovi API failed.");
                return StatusCode(502, new { error = "Customer details could not be saved right now." });
            }
        }
    }
}