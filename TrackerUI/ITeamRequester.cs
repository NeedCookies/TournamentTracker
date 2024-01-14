using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;

namespace TrackerUI
{
    public interface ITeamRequester
    {
        /// <summary>
        /// Get the new TeamModel
        /// </summary>
        /// <param name="model">TeamModel instance</param>
        void TeamComplete(TeamModel model);
    }
}
