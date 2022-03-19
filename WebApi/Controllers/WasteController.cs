using Microsoft.AspNetCore.Mvc;
using WebApi.Bll;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WasteController : ControllerBase
    {
        private readonly ILogger<WasteController> _logger;
        private readonly string _endPoint = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQ6LMYyIYZzsrMhVB4_dg0fADQ-hVx5y8qOPEe7eIP8rFm4sWoLtYURivnlTqKBFJ5qbfs69HlKbeXK/pub?output=csv";

        public WasteController(ILogger<WasteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<WasteInfo>> GetAsync()
        {
            return await new Waste().GetWasteByGoogleSheetAsync(_endPoint);
        }
    }
}
