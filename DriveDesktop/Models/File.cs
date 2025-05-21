using Newtonsoft.Json;

namespace DriveDesktop.Models
{
    public class File
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("ownerId")]
        public Guid OwnerId { get; set; }

        [JsonProperty("folderId")]
        public Guid FolderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("contentType")]
        public string ContentType { get; set; } = string.Empty;   

        [JsonProperty("contentSize")]
        public long ContentSize { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
