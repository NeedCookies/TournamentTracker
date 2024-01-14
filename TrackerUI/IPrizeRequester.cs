using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;

namespace TrackerUI
{
    public interface IPrizeRequester
    {
        /// <summary>
        /// Get the created PrizeForm
        /// </summary>
        /// <param name="model"></param>
        void PrizeComplete(PrizeModel model);
    }
}
