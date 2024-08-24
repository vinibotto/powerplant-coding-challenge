namespace Domain.Entities
{
    public class GeneratedPower
    {
        public PowerPlant PowerPlant { get; set; }

        public double Power { get; set; }

        public GeneratedPower(PowerPlant plant, double powerToProduce)
        {
            PowerPlant = plant;
            Power = powerToProduce;
        }
    }
}
