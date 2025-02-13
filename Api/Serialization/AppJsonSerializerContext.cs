using System.Text.Json.Serialization;
using Core.Entities;
using Core.Enums;

namespace BitysApi.Serialization
{
    [JsonSerializable(typeof(IEnumerable<Profile>))]
    [JsonSerializable(typeof(Profile))]
    [JsonSerializable(typeof(StatusEnum))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {
    }
}
