using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/seasons")]
    [OpenApiTag("seasons", Description = "Seasons API")]
    public class SeasonController : ControllerBase
    {
        private readonly SeasonService seasonService;

        public SeasonController(SeasonService seasonService)
        {
            this.seasonService = seasonService;
        }

        /// <summary>
        /// List all seasons
        /// </summary>
        /// <remarks>
        /// Gets a list of all known quiz seasons, including past and future seasons.
        /// </remarks>
        [HttpGet]
        public List<Season> GetSeasons()
        {
            return seasonService.GetAll().ToList();
        }

        /// <summary>
        /// Get active seasons
        /// </summary>
        /// <remarks>
        /// Gets a list of seasons that are currently active. Usually just one season will be returned.
        /// </remarks>
        [HttpGet("active")]
        public async Task<List<Season>> GetActiveSeasons()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all tournaments in a season
        /// </summary>
        [HttpGet("{seasonId}/tournaments")]
        public async Task<List<Tournament>> GetSeasonTournaments(string seasonId)
        {
            throw new NotImplementedException();
        }
    }
}
