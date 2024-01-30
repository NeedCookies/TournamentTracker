using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess.TextConnectHelpers;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Add new entry to Text file and return a full model off added object with correct id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void CreatePerson(PersonModel model)
        {
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConverToPersonModels();

            int currentId = people.Count + 1;
            model.Id = currentId;
            people.Add(model);

            people.SaveToPeopleFile();
        }

        /// <summary>
        /// Add new prize entry to txt file and return a full model with correct id corresponds to txt file
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void CreatePrize(PrizeModel model)
        {
            // Load txt file
            // Convert txt to List<PrizeModel>
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Add new record with new Id (max + 1)
            int currentId = prizes.Count + 1;
            model.Id = currentId;
            prizes.Add(model);


            // Convert the prizes to list<string>
            // Save the list<string> to txt
            prizes.SaveToPrizeModelFile();
        }

        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int currentId = teams.Count + 1;
            model.Id = currentId;
            teams.Add(model);

            teams.SaveToTeamFile();
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();

            int currentId = tournaments.Count + 1;

            model.Id = currentId;

            model.SaveRoundsToFile();

            tournaments.Add(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResult(model);
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConverToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }

        public void CompleteTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            tournaments.Remove(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResult(model);
        }
    }
}
