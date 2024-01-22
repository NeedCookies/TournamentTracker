using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        /// The ID from the database that will be used to identify the winner
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Represents TeamModel team Winner of this particular match
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents number of round this match belongs to
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// Returns string with team names for the matchup
        /// </summary>
        public string DisplayName
        {
            get
            {
                string output = "";
                foreach (MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs {me.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        // At the moment of start tournament we've determined only first round matchups
                        output = "Matchup Not Yet Determined";
                        break;
                    }
                }
                return output;
            }                        
        }
    }
}
