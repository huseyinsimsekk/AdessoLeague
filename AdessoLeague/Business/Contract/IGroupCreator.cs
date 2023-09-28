using AdessoLeague.Model;

namespace AdessoLeague.Business.Contract
{
    public interface IGroupCreator
    {
        List<GroupResponseModel> CreateGroup();
    }
}
