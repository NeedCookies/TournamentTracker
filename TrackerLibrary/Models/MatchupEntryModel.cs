﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents one team in matchup
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score of this particular team
        /// </summary>
        public double score { get; set; }

        /// <summary>
        /// Represents the matchup where this team came from as winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
