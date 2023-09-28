using AdessoLeague.Business.Service;
using AdessoLeague.Data;
using AdessoLeague.Model;
using Microsoft.AspNetCore.Mvc;

namespace AdessoLeague.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeagueGroupController : ControllerBase
    {
        private readonly ILogger<LeagueGroupController> _logger;
        private readonly IConfiguration _configuration;
        private readonly MainContext _mainContext;
        public LeagueGroupController(ILogger<LeagueGroupController> logger, IConfiguration configuration, MainContext mainContext)
        {
            _logger = logger;
            _configuration = configuration;
            _mainContext = mainContext;
        }

        [HttpPost]
        public ActionResult CreateGroups([FromBody] GroupCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return BadRequest($"Girelen Bilgiler Hatalı. Detay: {message}");
            }

            try
            {
                GroupCreatorContext groupCreaterContext = null;
                switch (model.GroupCount)
                {
                    case 4:
                        groupCreaterContext = new GroupCreatorContext(_mainContext, new FourGroupCreator(_configuration));
                        break;
                    case 8:
                        groupCreaterContext = new GroupCreatorContext(_mainContext, new EigthGroupCreator(_configuration));
                        break;
                    default:
                        break;
                }
                return Ok(groupCreaterContext.CreateGroups(model.CreatorId));
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}