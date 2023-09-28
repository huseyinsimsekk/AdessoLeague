using System.Text.Json.Serialization;

namespace AdessoLeague.Model
{
    public class Team
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int CountryId { get; set; }
    }
}
