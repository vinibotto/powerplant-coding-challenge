using Domain.Entities;
using Domain.Interfaces;

namespace Application
{
    public class ProductionPlanService : IProductionPlanService
    {
       
        public List<GeneratedPower> GeneratePlan(LoadInformation loadInformation)
        {
            var meritOrderedPlants = loadInformation.PowerPlants
                .OrderBy(ppc => ppc.CalculateCost())
                .ToList();

            var remainingLoad = loadInformation.Load;
            var productions = new List<GeneratedPower>();

            foreach (var plant in meritOrderedPlants)
            {
                if (remainingLoad <= 0) 
                {
                    productions.Add(new GeneratedPower(plant, 0));
                    continue;
                }

                var powerToProduce = CalculatePowerToProduce(plant, remainingLoad);
                productions.Add(new GeneratedPower(plant, powerToProduce));

                remainingLoad -= powerToProduce;
            }

            if (remainingLoad == 0)
                return productions;

            foreach (var plants in productions)
            {
                if (plants.Power == 0 && remainingLoad > 0)
                {
                    var powerToProduce = CalculatePowerToProduce(plants.PowerPlant, remainingLoad, true);
                    plants.Power = powerToProduce;
                    remainingLoad -= powerToProduce;
                }
                else if (remainingLoad < 0 && plants.Power < Math.Abs(remainingLoad))
                {
                    plants.Power = 0;
                }
            }

            return productions;

        }

        private double CalculatePowerToProduce(PowerPlant plant, double remainingLoad, bool acceptOverload = false)
        {
            if (remainingLoad >= plant.PMin)
            {
                return Math.Min(remainingLoad, plant.GetCurrentPMax());
            }
            else if (acceptOverload)
            {
                return plant.PMin;
            }

            return 0;
        }
    }
}
