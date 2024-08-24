using Domain.Entities;

namespace Application.Factories
{
    public static class PowerPlantFactory
    {
        public static PowerPlant CreateGasFired(string name, double efficiency, double pMin, double pMax, double gasCost)
        {
            return new GasFired(name, efficiency, pMin, pMax, gasCost);
        }

        public static PowerPlant CreateTurbojet(string name, double efficiency, double pMin, double pMax, double kerosineCost)
        {
            return new Turbojet(name, efficiency, pMin, pMax, kerosineCost);
        }

        public static PowerPlant CreateWindTurbine(string name, double efficiency, double pMin, double pMax, double windPercentage)
        {
            return new WindTurbine(name, efficiency, pMin, pMax, windPercentage);
        }
    }
}
