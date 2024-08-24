using Domain.Enums;

namespace Domain.Entities
{
    public abstract class PowerPlant
    {
        public string Name { get; }
        public double Efficiency { get; }
        public double PMin { get; }
        public double PMax { get; }

        public PowerPlant(string name, double efficiency, double pmin, double pmax) 
        {
            Name = name;
            Efficiency = efficiency;
            PMin = pmin;
            PMax = pmax;
        }

        public abstract double CalculateCost();

        public virtual double GetCurrentPMax() 
        {
            return PMax;
        }

    }
}
