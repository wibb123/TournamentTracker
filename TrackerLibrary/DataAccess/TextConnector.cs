using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Saves a new prize to the text data storage
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        public void CreatePrize(PrizeModel model)
        {
            // Load the text file and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID and add 1
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Convert the prizes to list<string> and save the list<string> to the text file
            prizes.SaveToPrizeFile();
        
        }

        public void CreatePerson(PersonModel model)
        {
            // Load the text file and convert the text to List<PersonModel>
            List<PersonModel> people = GlobalConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            // Find the max ID and add 1
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            people.Add(model);

            // Convert the people to list<string> and save the list<string> to the text file
            people.SaveToPersonFile();

        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> people = GlobalConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            return people;
        }

        public void CreateTeam(TeamModel model)
        {
            // Load the text file and convert the text to List<TeamModel>
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            // Find the max ID and add 1
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            teams.Add(model);

            // Convert the teams to list<string> and save the list<string> to the text file
            teams.SaveToTeamFile();
        }

        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            return teams;
        }

        public void CreateTournament(TournamentModel model)
        {
            // Load the text file and convert the text to List<TeamModel>
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            // Find the max ID and add 1
            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile();

            // Add the new record with the new ID (max + 1)
            tournaments.Add(model);

            // Convert the tournaments to list<string> and save the list<string> to the text file
            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResults(model);
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
            // Load the text file and convert the text to List<TeamModel>
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            // Remove completed Tournament
            tournaments.Remove(model);

            // Convert the tournaments to list<string> and save the list<string> to the text file
            tournaments.SaveToTournamentFile();

            //TournamentLogic.UpdateTournamentResults(model);
        }
    }
}
