using System.Text.Json.Serialization;

namespace PersonalPlaner.Shared.FeiertageApi
{

    public class Feiertag
    {
        [JsonPropertyName("date")] public string Date { get; set; } = string.Empty;

        [JsonPropertyName("fname")] public string Fname { get; set; } = string.Empty;

        [JsonPropertyName("all_states")] public string Allstates { get; set; } = string.Empty;

        [JsonPropertyName("bw")] public string Bw { get; set; } = string.Empty;

        [JsonPropertyName("by")] public string By { get; set; } = string.Empty;

        [JsonPropertyName("be")] public string Be { get; set; } = string.Empty;

        [JsonPropertyName("bb")] public string Bb { get; set; } = string.Empty;

        [JsonPropertyName("hb")] public string Hb { get; set; } = string.Empty;
        [JsonPropertyName("hh")] public string Hh { get; set; } = string.Empty;
        [JsonPropertyName("he")] public string He { get; set; } = string.Empty;
        [JsonPropertyName("mv")] public string Mv { get; set; } = string.Empty;
        [JsonPropertyName("ni")] public string Ni { get; set; } = string.Empty;
        [JsonPropertyName("nw")] public string Nw { get; set; } = string.Empty;
        [JsonPropertyName("rp")] public string Rp { get; set; } = string.Empty;
        [JsonPropertyName("sl")] public string Sl { get; set; } = string.Empty;
        [JsonPropertyName("sn")] public string Sn { get; set; } = string.Empty;
        [JsonPropertyName("st")] public string St { get; set; } = string.Empty;
        [JsonPropertyName("sh")] public string Sh { get; set; } = string.Empty;
        [JsonPropertyName("th")] public string Th { get; set; } = string.Empty;
        [JsonPropertyName("comment")] public string Comment { get; set; } = string.Empty;
        [JsonPropertyName("augsburg")] public string Augsburg { get; set; } = string.Empty;
        [JsonPropertyName("katholisch")] public string Katholisch { get; set; } = string.Empty;
    }


}
