using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        /// <summary>
        /// The unique identifier for the Team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique Team Name.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// List of People in the Team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

    }
}
