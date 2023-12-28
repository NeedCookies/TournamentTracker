using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Full tournament model
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// Name of the tournament
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represent the entry fee
        /// </summary>
        public decimal Entryfee { get; set; }

        /// <summary>
        /// Represents the list of teams which take part in the particular tournament
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Represents the list of prizes for each place
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// Represents list of round as "MatchupModel" in the particular tournament
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
