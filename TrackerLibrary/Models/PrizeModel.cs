using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents the prize for each place in tournament
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// Represents a place unique number
        /// </summary>
        public int PlaceNumber { set; get; }

        /// <summary>
        /// Represents the place name
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents the prize amount for the particular place
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the prize size using percentage of budget
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberVal = 0;
            int.TryParse(placeNumber, out placeNumberVal);
            PlaceNumber = placeNumberVal;

            decimal prizeAmountVal = 0;
            decimal.TryParse(prizeAmount, out prizeAmountVal);
            PrizeAmount = prizeAmountVal;

            double prizePercentageVal = 0;
            double.TryParse(prizePercentage, out prizePercentageVal);
            PrizePercentage = prizePercentageVal;
        }
    }
}
