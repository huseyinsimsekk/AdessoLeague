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

        [HttpGet(Name = "GetGroups/{groupCount}/{creatorId}")]
        public ActionResult Get(int groupCount, int creatorId)
        {
            GroupCreatorContext groupCreaterContext = null;

            switch (groupCount)
            {
                case 4:
                    groupCreaterContext = new GroupCreatorContext(_mainContext, new FourGroupCreator(_configuration));
                    break;
                case 8:
                    groupCreaterContext = new GroupCreatorContext(_mainContext, new EigthGroupCreator(_configuration));
                    break;
                default:
                    return BadRequest("4 veya 8 Grup Oluşturabilirsiniz!");
            }
            try
            {
                return Ok(groupCreaterContext.CreateGroups(creatorId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}