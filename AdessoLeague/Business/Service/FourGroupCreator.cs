using AdessoLeague.Business.Contract;
using AdessoLeague.Model;

namespace AdessoLeague.Business.Service
{
    public class FourGroupCreator : IGroupCreator
    {
        private readonly IConfiguration _configuration;
        public FourGroupCreator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<GroupResponseModel> CreateGroup()
        {
            var teams = _configuration.GetSection("Teams").Get<List<Team>>();
            if (teams is null)
            {
                throw new ApplicationException("Bilgilere Ulaşılamadı!");
            }
            return GroupService.GroupResponseModelsByCountries(teams); ;
        }
    }
}
