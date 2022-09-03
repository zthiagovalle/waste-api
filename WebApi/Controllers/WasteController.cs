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
        private readonly string _endPoint = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQ6LMYyIYZzsrMhVB4_dg0fADQ-hVx5y8qOPEe7eIP8rFm4sWoLtYURivnlTqKBFJ5qbfs69HlKbeXK/pub?output=csv";

        public WasteController(ILogger<WasteController> logger, IWaste waste)
        {
            _logger = logger;
            _waste = waste;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var lstWaste = await _waste.GetWasteByGoogleSheetAsync(_endPoint);

            if (lstWaste.Any())
                return Ok(lstWaste);

            return NotFound();
        }
    }
}