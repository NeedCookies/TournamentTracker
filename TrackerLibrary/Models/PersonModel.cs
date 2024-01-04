using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Default person model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Person phone number
        /// </summary>
        public string CellphoneNumber { get; set; }

        /// <summary>
        /// Return FirstName and LastName properties 
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
    }
}
