using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.IBll;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WasteController : ControllerBase
    {
        private readonly ILogger<WasteController> _logger;
        private readonly IWaste _waste;

        public WasteController(ILogger<WasteController> logger, IWaste waste)
        {
            _logger = logger;
            _waste = waste;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var lstWaste = await _waste.GetWasteByGoogleSheetAsync();
            if (lstWaste.Any())
                return Ok(lstWaste);

            return NotFound();
        }
    }
}