using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMBQ.Hub.Models;

namespace FMBQ.Hub
{
    public class SeasonService
    {
        // TODO: Determine this in a dynamic way.
        private const int initialYear = 2019;
        private const int startingMonth = 9;

        public IEnumerable<Season> GetAll()
        {
            var now = DateTime.Now;
            var latestYear = now.Year;

            if (now.Month >= startingMonth) {
                latestYear += 1;
            }

            while (latestYear >= initialYear)
            {
                yield return new Season
                {
                    Id = latestYear.ToString(),
                    StartingYear = latestYear - 1,
                    EndingYear = latestYear,
                };

                latestYear -= 1;
            }
        }
    }
}
