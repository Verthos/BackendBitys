using System.Text.Json.Serialization;
using Core.Enums;

namespace Core.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<User> Users { get; set; }

    }
}
