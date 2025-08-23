using Microsoft.AspNetCore.Mvc;

namespace ConfigSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/config/
        [HttpGet("{system}/{client}/{key}")]
        public IActionResult GetKeyValue(string system, string client, string key)
        {
            var sectionPath = $"{system}:{client}:{key}";
            var keyValue = _configuration[sectionPath];

            if (key == "Block")
                return Ok(new { System = system, Client = client, Block = keyValue });
            else
                return NotFound($"Chave não encontrada para  '{system}'.");
        }
    }


}
