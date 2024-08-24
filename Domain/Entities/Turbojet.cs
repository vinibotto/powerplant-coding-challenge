namespace Domain.Entities
{
    public class Turbojet : PowerPlant
    {
        public double KerosineCost { get; set; }
        public Turbojet(string name, double efficiency, double PMin, double PMax, double kerosineCost) 
            : base(name, efficiency, PMin, PMax)
        {
            KerosineCost = kerosineCost;
        }
        public override double CalculateCost()
        {
            return (KerosineCost / Efficiency);
        }
    }
}
