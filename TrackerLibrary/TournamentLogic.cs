using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int roundsCount = FindNumberOfRound(model.EnteredTeams.Count);
            int byes = NumberOfByes(roundsCount, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            CreateRoundsAfterFirst(model, roundsCount);

        }

        private static void CreateRoundsAfterFirst(TournamentModel model, int rounds)
        {
            // Represents current round, start by 2
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });
                    // if we have the two teams for this matchup we pass it into round and create new matchup for the round
                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currRound);
                previousRound = currRound;

                currRound = new List<MatchupModel>();
                round++;
            }

        }

        public static void UpdateTournamentResult(TournamentModel tournament)
        {
            List<MatchupModel> ToScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    if (matchup.Winner == null && (matchup.Entries.Any(x => x.Score != 0) || matchup.Entries.Count == 1))
                    {
                        ToScore.Add(matchup);
                    }
                }
            }

            MarkWinnerInMatchups(ToScore);

            AdvanceWinners(ToScore, tournament);

            ToScore.ForEach(x => GlobalConfig.Connections[0].UpdateMatchup(x));
        }
        
        // Loop through all mathups toScore and foreach mathcups we look child matchup
        // in the rest of tournament matchups, and if we find such one
        // update it (set to child matchups team which was winner in parent matchup)
        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel matchup in round)
                    {
                        foreach (MatchupEntryModel me in matchup.Entries)
                        {
                            if (me.ParentMatchup != null && me.ParentMatchup.Id == m.Id)
                            {
                                me.TeamCompeting = m.Winner;
                                GlobalConfig.Connections[0].UpdateMatchup(matchup);
                            }
                        }
                    }
                }
            }
        }

        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel model in models)
            {
                if (model.Entries.Count == 1)
                {
                    model.Winner = model.Entries[0].TeamCompeting;
                    continue;
                }
                // 0 - false, or low score wins
                if (greaterWins == "0")
                {
                    if (model.Entries[0].Score < model.Entries[1].Score)
                    {
                        model.Winner = model.Entries[0].TeamCompeting;
                        model.WinnerId = model.Entries[0].Id;
                    }
                    else if (model.Entries[1].Score < model.Entries[0].Score)
                    {
                        model.Winner = model.Entries[1].TeamCompeting;
                        model.WinnerId = model.Entries[1].Id;
                    }
                    else
                    {
                        throw new Exception("Tie games aren't allowed");
                    }
                }
                else
                {
                    if (model.Entries[0].Score > model.Entries[1].Score)
                    {
                        model.Winner = model.Entries[0].TeamCompeting;
                        model.WinnerId = model.Entries[0].Id;
                    }
                    else if (model.Entries[1].Score > model.Entries[0].Score)
                    {
                        model.Winner = model.Entries[1].TeamCompeting;
                        model.WinnerId = model.Entries[1].Id;
                    }
                    else
                    {
                        throw new Exception("Tie games aren't allowed");
                    }
                }
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                // In One Entry we can have 2 teams or one team + bye team
                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }

        // Calculate how many empty byes teams we need
        private static int NumberOfByes(int round, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= round; i++)
            {
                totalTeams *= 2; 
            }
            output = totalTeams - numberOfTeams;
            return output;
        }

        private static int FindNumberOfRound(int teamsCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamsCount)
            {
                output++;
                // Because round count requires 2^round.Count teams
                val *= 2;
            }
            return output;
        }

        // Randomize giving list of teamModel
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
            
        }
    }
}
