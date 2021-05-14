using System.Text.Json.Serialization;

namespace WebApi_G_Map.Models
{
    public class Message
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string body { get; set; }

        public string title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string author { get; set; }

    }

}
