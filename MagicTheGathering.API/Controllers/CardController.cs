using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheGathering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public int GetNumberOfCards()
        {
            return 5;
        }
    }
}

