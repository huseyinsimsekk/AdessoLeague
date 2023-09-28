namespace AdessoLeague.Model.Entity
{
    public class GroupTeam
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int TeamId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Hash { get; set; }
    }
}
