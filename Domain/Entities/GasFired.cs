using System.Security.Cryptography.X509Certificates;

namespace Domain.Entities
{
    public class GasFired : PowerPlant
    {
        public double GasCost { get; }

        public GasFired(string name, double efficiency, double PMin, double PMax, double gasCost)
            : base(name, efficiency, PMin, PMax)
        {
            GasCost = gasCost;
        }

        public override double CalculateCost()
        {
            return (GasCost / Efficiency);
        }
    }
}
