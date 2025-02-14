using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Language { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } 

        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }

    }
}
