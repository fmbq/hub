using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace FMBQ.Hub.Models
{
    public class CreateTeamRequest
    {
        /// <summary>
        /// A user-facing name for the team.
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string DivisionId { get; set; }

        /// <summary>
        /// A list of person IDs who are members of the team.
        /// </summary>
        /// <value></value>
        public List<string> Quizzers { get; set; }
    }
}
