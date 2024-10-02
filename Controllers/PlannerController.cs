using MealPlannerCSharpApi.Models;
using MealPlannerCSharpApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerCSharpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlannerController : ControllerBase
{
    private readonly IPlannerRepository _plannerRepository;

    public PlannerController(IPlannerRepository plannerRepository)
    {
        _plannerRepository = plannerRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Planner>> CreatePlanner(Planner planner)
    {
        var newPlanner = await _plannerRepository.CreatePlanner(planner);

        return CreatedAtAction(nameof(GetPlanner), new { plannerId = planner.Id }, newPlanner);
    }

    [HttpGet("{plannerId}")]
    public async Task<ActionResult<Planner>> GetPlanner(long plannerId)
    {
        return await _plannerRepository.GetPlanner(plannerId);
    }

    [HttpDelete("{plannerId}")]
    public async Task<IActionResult> DeletePlanner(long plannerId)
    {
        _plannerRepository.DeletePlanner(plannerId);
        return NoContent();
    }
}
