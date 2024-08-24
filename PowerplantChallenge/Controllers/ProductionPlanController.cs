using Application.Factories;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PowerplantChallenge.DTOs;
using PowerplantChallenge.Mapper;
using System.Net.Mime;

namespace PowerplantChallenge.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanService _productionPlanService;
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(IProductionPlanService productionPlanService, ILogger<ProductionPlanController> logger)
        {
            _productionPlanService = productionPlanService;
            _logger = logger;
        }

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<GeneratedPowerDTO>> CalculatePower([FromBody] LoadDTO load)
        {
            try 
            {
                _logger.LogInformation($"Calculating load of {load.Load} for {load.PowerPlants.Count} Powerplants");
                var generatedPower = _productionPlanService.GeneratePlan(new LoadInformation()
                {
                    Load = load.Load,
                    PowerPlants = load.PowerPlants.Select(p => PowerPlantMapper.MapPowerPlant(p, load.Fuels)).ToList()
                });

                var generatedPowerDto = generatedPower.Select(gp => new GeneratedPowerDTO()
                {
                    Name = gp.PowerPlant.Name,
                    Power = gp.Power
                }).ToList();

                _logger.LogInformation("Power calculation completed.");
                return Ok(generatedPowerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while performing calculations.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
