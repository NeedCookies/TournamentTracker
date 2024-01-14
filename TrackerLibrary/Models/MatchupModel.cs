using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents the particular match
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// The uniqe identifier for the matchup
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the list of MatchupEntryModel for the Matchup for this match
        /// </summary>
        public List<MatchupEntryModel> Entries = new List<MatchupEntryModel>();

        /// <summary>
        /// Winner of this particular match
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents which round this match belongs to
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
