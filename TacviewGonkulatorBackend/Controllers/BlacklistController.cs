using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacviewGonkulatorBackend.Services;

namespace TacviewGonkulatorBackend.Controllers
{
    public class BlacklistController : Controller
    {
        private readonly ITacviewService _tacviewService;

        public BlacklistController(ITacviewService tacviewService)
        {
            _tacviewService = tacviewService;
        }
        
        [HttpGet("/api/v1/missileblacklist")]
        public async Task<IActionResult> GetMissileBlacklist()
        {
            var blacklist = await _tacviewService.GetMissileBlacklist();
            return Ok(blacklist);
        }
    }
}