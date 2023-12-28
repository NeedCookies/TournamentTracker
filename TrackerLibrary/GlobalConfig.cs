using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        //Since c# 4.6 version we can initialize this list property right here to
        //avoid mistakes in InitializeConnections method

        public static void InitializeConnections(bool database, bool textFiles)
        { 
            if (database)
            {
                // TODO - set up SQL Connector properly
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - create txt connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
