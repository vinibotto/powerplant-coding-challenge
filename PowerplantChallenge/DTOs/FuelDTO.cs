using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PowerplantChallenge.DTOs
{
    public class FuelDTO
    {
        [JsonProperty("gas(euro/MWh)")]
        public double Gas { get; set; }
        [JsonProperty("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }
        [JsonProperty("co2(euro/ton)")]
        public double CO2 { get; set; }
        [JsonProperty("wind(%)")]
        public double Wind { get; set; }
    }
}
