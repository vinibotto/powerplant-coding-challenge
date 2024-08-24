using Newtonsoft.Json;

namespace PowerplantChallenge.DTOs
{
    public class GeneratedPowerDTO
    {
        public string Name { get; set; }
        [JsonProperty("p")]
        public double Power { get; set; }
    }
}
