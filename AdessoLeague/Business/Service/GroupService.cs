using AdessoLeague.Business.Contract;
using AdessoLeague.Model;
using System.Text.RegularExpressions;
using System;
using AdessoLeague.Enum;

namespace AdessoLeague.Business.Service
{
    public class GroupService
    {
        public static List<GroupResponseModel> GroupResponseModelsByCountries(List<Team> teams, int count = 0)
        {
            var groups = new List<GroupResponseModel>();
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                var selectedGroup = new GroupResponseModel() { GroupName = $"{(GroupName)(count + i + 1)}", Teams = new List<Team>() };

                var randomTeams = teams.GroupBy(m => m.CountryId).Select(g => g.ElementAt(random.Next(0, g.Count()))).ToList();

                selectedGroup.Teams.AddRange(randomTeams);
                randomTeams.ForEach(m => teams.Remove(m));

                groups.Add(selectedGroup);
            }
            return groups.OrderBy(m => m.GroupName).ToList();
        }
    }
}
