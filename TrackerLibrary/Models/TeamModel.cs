using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a team 
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// Represents the team in list of "PersonModel" objects
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// The particular team name
        /// </summary>
        public string TeamName { get; set; }
    }
}
