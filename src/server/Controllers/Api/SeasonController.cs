using System.Collections.Generic;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/seasons")]
    public class SeasonController : ControllerBase
    {
        /// <summary>
        /// List all seasons
        /// </summary>
        /// <remarks>
        /// Gets a list of all known quiz seasons, including past and future seasons.
        /// </remarks>
        [HttpGet]
        public async Task<List<Season>> List()
        {
            return null;
        }

        /// <summary>
        /// Get active seasons
        /// </summary>
        /// <remarks>
        /// Gets a list of seasons that are currently active. Usually just one season will be returned.
        /// </remarks>
        [HttpGet("active")]
        public async Task<List<Season>> GetActive()
        {
            return null;
        }
    }
}
