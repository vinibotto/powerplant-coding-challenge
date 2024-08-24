using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PowerplantChallenge.DTOs
{
    public class LoadDTO
    {
        public double Load { get; set; }
        public FuelDTO Fuels { get; set; }
        public List<PowerPlantDTO> PowerPlants { get; set; }
    }
}
