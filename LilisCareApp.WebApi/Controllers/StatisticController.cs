using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace LilisCareApp.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public StatisticController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatisticsAsync()
        {
            try
            {
                StatisticsModel statistics = await _checkoutService.GetStatisticsAsync();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
