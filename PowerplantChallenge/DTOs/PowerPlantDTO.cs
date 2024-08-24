using Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PowerplantChallenge.DTOs
{
    public class PowerPlantDTO
    {
        public string Name { get; set; }
        public PowerPlantType Type { get; set; }
        public double Efficiency { get; set; }
        public double PMin { get; set; }
        public double PMax { get; set; }
    }
}
