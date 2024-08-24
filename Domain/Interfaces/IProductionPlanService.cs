using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductionPlanService
    {
        List<GeneratedPower> GeneratePlan(LoadInformation loadInformation);
    }
}
