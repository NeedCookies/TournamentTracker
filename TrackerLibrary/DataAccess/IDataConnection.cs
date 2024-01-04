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
        /// Returns a list of PersonModel
        /// </summary>
        /// <returns></returns>
        List<PersonModel> GetPerson_All();
    }
}
