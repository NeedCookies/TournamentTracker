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
        // TODO - Wire up CreatePrize for text files

        private const string PrizesFile = "PrizesModels.csv";

        /// <summary>
        /// Add new prize entry to txt file and return a full model with correct id corresponds to txt file
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load txt file
            // Convert txt to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Add new record with new Id (max + 1)
            int currentId = prizes.Count + 1;
            model.Id = currentId;
            prizes.Add(model);


            // Convert the prizes to list<string>
            // Save the list<string> to txt
            prizes.SaveToPrizeModelFile(PrizesFile);

            return model;
        }
    }
}
