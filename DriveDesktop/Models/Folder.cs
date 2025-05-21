using Newtonsoft.Json;

namespace DriveDesktop.Models
{
    public class Folder
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("parentFolder")]
        public Guid? ParentFolder { get; set; }

        [JsonProperty("subFolders")]
        public List<Folder.SubFolder> SubFolders { get; set; } = new List<Folder.SubFolder>();

        [JsonProperty("files")]
        public List<File> Files { get; set; } = new List<File>();

        public class SubFolder
        {
            [JsonProperty("id")]
            public Guid Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; } = string.Empty;
        }

    }
}
