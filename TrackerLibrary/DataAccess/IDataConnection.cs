using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface IDataConnection
    {
        /// <summary>
        /// Create a new entry of PrizeModel in storage and return 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PrizeModel CreatePrize(PrizeModel model);

        /// <summary>
        /// Create a new entry of PersonModel in storage and returns it
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        PersonModel CreatePerson(PersonModel person);

        /// <summary>
        /// Create a new entry of TeamModel in storage and returns it
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TeamModel CreateTeam(TeamModel model);

        /// <summary>
        /// Create a new entry of TournamentModel and all models, which was selected for this Tournament
        /// Returns TournamentModel with Id from storage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void CreateTournament(TournamentModel model);

        /// <summary>
        /// Returns a list of TeamModel
        /// </summary>
        /// <returns></returns>
        List<TeamModel> GetTeam_All();

        /// <summary>
        /// Returns a list of PersonModel
        /// </summary>
        /// <returns></returns>
        List<PersonModel> GetPerson_All();

        /// <summary>
        /// Returns a list of TournamentModel
        /// </summary>
        /// <returns></returns>
        List<TournamentModel> GetTournament_All();
    }
}
