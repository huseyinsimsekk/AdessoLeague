using AdessoLeague.Business.Contract;
using AdessoLeague.Model;
using Microsoft.Extensions.Configuration;

namespace AdessoLeague.Business.Service
{
    public class EigthGroupCreator : IGroupCreator
    {
        private readonly IConfiguration _configuration;
        public EigthGroupCreator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<GroupResponseModel> CreateGroup()
        {
            var response = new List<GroupResponseModel>();
            var allTeams = _configuration.GetSection("Teams").Get<List<Team>>();
            var countries = _configuration.GetSection("Countries").Get<List<Country>>();

            if (allTeams is null || countries is null)
            {
                throw new ApplicationException("Bilgilere Ulaşılamadı!");
            }
            var random = new Random();
            var selectedCountries = countries?.OrderBy(m => random.Next(countries.Count)).Take(4).ToList();
            var count = 0;
            while (selectedCountries?.Count > 0)
            {
                var selectedTeams = allTeams.Where(m => selectedCountries.Select(c => c.Id).Contains(m.CountryId)).ToList();
                response.AddRange(GroupService.GroupResponseModelsByCountries(selectedTeams, count));
                selectedCountries.ForEach(m => countries?.Remove(m));
                if (countries != null)
                {
                    selectedCountries = countries.OrderBy(m => random.Next(countries.Count)).Take(4).ToList();
                    count += 4;
                }
            }

            return response;

        }
    }
}
