namespace Domain.Entities
{
    public class WindTurbine : PowerPlant
    {
        public double WindPercentage { get; set; }
        public WindTurbine(string name, double efficiency, double PMin, double PMax, double windPercentage) 
            : base(name, efficiency, PMin, PMax)
        {
            WindPercentage = windPercentage;

        }
        public override double CalculateCost()
        {
            return WindPercentage == 0 ? Double.MaxValue : 0;
        }

        public override double GetCurrentPMax()
        {
            return PMax * WindPercentage/ 100;
        }
    }
}
