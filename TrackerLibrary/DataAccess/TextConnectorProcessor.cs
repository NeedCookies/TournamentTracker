using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.DataAccess.TextConnectHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Return a full file path as string, concatenate filepath from AppSettings with filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FullFilePath(this string fileName) //PrizeModel.csv
        {
            return $"{ ConfigurationManager.AppSettings["filepath"] }\\{ fileName }";
        }

        /// <summary>
        /// Returns all file lines as a List, if file doesn't exists returns new empty list
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Loop through all lines and convert each of line in PrizeModel
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Loop through all lines in storage file and convert each of line into a PersonModel
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<PersonModel> ConverToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (var line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];
                output.Add(p);
            }
            return output;
        }

        /// <summary>
        /// Read all lines in the storage file and convert each line into a TeamModel and PersonModel by personIds list in TeamModel
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="peopleFileName"></param>
        /// <returns></returns>
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConverToPersonModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
                output.Add(t);
            }
            return output;
        }

        /// <summary>
        /// Write to file prizes, converted to string as "Id,PlaceNumber,PlaceName,PrizeAmount,PrizePercentage"
        /// </summary>
        /// <param name="models"></param>
        /// <param name="filename"></param>
        public static void SaveToPrizeModelFile(this List<PrizeModel> models, string filename)
        {
            List<string> lines = new List<string>();

            foreach (var p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PrizeAmount },{ p.PrizePercentage }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }

        /// <summary>
        /// Write to People File Storage giving model as string "Id,FirstName,LastName,EmailAddress,CellPhoneNumber"
        /// </summary>
        /// <param name="models"></param>
        /// <param name="filename"></param>
        public static void SaveToPersonModelsFile(this List<PersonModel> models, string filename)
        {
            List<string> lines = new List<string>();

            foreach(var p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.CellphoneNumber }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string filename)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{ t.Id },{ t.TeamName },{ ConvertPeopleListToString(t.TeamMembers) }");
            }

            File.WriteAllLines(filename.FullFilePath(), lines);
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            
            if (people.Count == 0) { return ""; }

            foreach (PersonModel p in people)
            {
                output += $"{ p.Id }|";
            }

            output = output.Substring(0, output.Length - 1); // Remove last char '|'
            return output;
        }
    }
}
