using Application;
using Application.Factories;
using Domain.Entities;

namespace PowerPlantTests
{
    [TestClass]
    public class ProductionPlanServiceTests
    {
        [DataTestMethod]
        [DataRow(480, 13.4, 50.8, 60)]
        [DataRow(480, 13.4, 50.8, 0)]
        [DataRow(910, 13.4, 50.8, 60)]
        public void WhenGeneratingPlanLoadMustBeCovered(int load, double gasCost, double kerosineCost, double windPercentage)
        {
            var productionPlanService = new ProductionPlanService();

            var listGeneratedPower = productionPlanService.GeneratePlan(new LoadInformation()
            {
                Load = load,
                PowerPlants = new List<PowerPlant> 
                {
                    PowerPlantFactory.CreateGasFired("gasfiredbig1", 0.53, 100, 460, gasCost),
                    PowerPlantFactory.CreateGasFired("gasfiredbig2", 0.53, 100, 460, gasCost),
                    PowerPlantFactory.CreateGasFired("gasfiredsomewhatsmaller", 0.37, 40, 210, gasCost),
                    PowerPlantFactory.CreateTurbojet("tj1", 0.3, 0,16, kerosineCost),
                    PowerPlantFactory.CreateWindTurbine("windpark1", 1, 0, 150, windPercentage),
                    PowerPlantFactory.CreateWindTurbine("windpark2", 1, 0, 36, windPercentage)
                }
            });

            var totalPower = listGeneratedPower.Sum(gp => gp.Power);
            Assert.IsTrue(totalPower >= load);
        }
    }
}