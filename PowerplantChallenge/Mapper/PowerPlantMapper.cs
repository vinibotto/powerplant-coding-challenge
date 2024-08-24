using Application.Factories;
using Domain.Entities;
using Domain.Enums;
using PowerplantChallenge.DTOs;

namespace PowerplantChallenge.Mapper
{
    public static class PowerPlantMapper
    {
        public static PowerPlant MapPowerPlant(PowerPlantDTO powerplantDto, FuelDTO fuelDto)
        {
            return powerplantDto.Type switch
            {
                PowerPlantType.WindTurbine => PowerPlantFactory.CreateWindTurbine(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.PMin, powerplantDto.PMax, fuelDto.Wind),
                PowerPlantType.GasFired => PowerPlantFactory.CreateGasFired(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.PMin, powerplantDto.PMax, fuelDto.Gas),
                PowerPlantType.Turbojet => PowerPlantFactory.CreateTurbojet(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.PMin, powerplantDto.PMax, fuelDto.Kerosine),
                _ => throw new ArgumentException("Unknown power plant"),
            };
        }
    }
}
