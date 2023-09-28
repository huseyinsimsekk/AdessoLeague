using AdessoLeague.Business.Contract;
using AdessoLeague.Data;
using AdessoLeague.Enum;
using AdessoLeague.Model;
using AdessoLeague.Model.Entity;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace AdessoLeague.Business.Service
{
    public class GroupCreatorContext
    {
        private readonly IGroupCreator _groupCreator;
        private readonly MainContext _mainContext;
        public GroupCreatorContext(MainContext mainContext, IGroupCreator groupCreator)
        {
            _groupCreator = groupCreator;
            _mainContext = mainContext;
        }
        public List<GroupResponseModel> CreateGroups(int creatorId)
        {
            try
            {
                var list = _groupCreator.CreateGroup();
                var hash = DateTime.Now + "_" + creatorId.ToString();

                for (int i = 0; i < list.Count; i++)
                {
                    foreach (var team in list[i].Teams)
                    {
                        _mainContext.GroupTeams.Add(new GroupTeam
                        {
                            CreateTime = DateTime.Now.Date,
                            Hash = hash,
                            CreatorId = creatorId,
                            GroupName = list[i].GroupName,
                            TeamId = team.Id
                        });
                    }
                }
                _mainContext.SaveChanges();
                return list;

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Gruplar Oluşturulurken Hata Alındı. Detay: {ex.Message}");
            }

        }
    }
}
