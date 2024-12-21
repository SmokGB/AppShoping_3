using System.Text.Json.Serialization;

namespace AppShoping.Entities
{
    public abstract class EntityBase : IEntity
    {
        [JsonPropertyOrder(-1)]
        public int Id { get; set; }
    }
}
