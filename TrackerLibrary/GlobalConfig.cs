using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizesModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        //Since c# 4.6 version we can initialize this list property right here to
        //avoid mistakes in InitializeConnections method

        public static void InitializeConnections(bool database, bool textFiles)
        { 
            if (database)
            {
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }

        /// <summary>
        /// Return a connectionString database from App.Config file with giving parameter name
        /// </summary>
        /// <param name="name">DataBase name</param>
        /// <returns></returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
