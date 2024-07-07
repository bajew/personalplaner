using System.Text.Json.Serialization;

namespace PersonalPlaner.Shared.FeiertageApi
{
    public class FeiertageResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("feiertage")]
        public Feiertag[] Feiertage { get; set; } = [];
    }


}
