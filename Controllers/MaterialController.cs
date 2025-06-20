using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaterialAPI_Azure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly GetActiveMaterialsUseCase _getActiveMaterialsUseCase;

        public MaterialController(GetActiveMaterialsUseCase getActiveMaterialsUseCase)
        {
            _getActiveMaterialsUseCase = getActiveMaterialsUseCase;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMaterials()
        {
            try
            {
                var materialDtos = await _getActiveMaterialsUseCase.Execute();

                return Ok(materialDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
