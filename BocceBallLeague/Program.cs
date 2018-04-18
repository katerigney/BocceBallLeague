using BocceBallLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BocceBallLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();
            Console.WriteLine("Tampa Bay Bocce Ball League");
            Console.WriteLine("---------------------------");


            //EXPLORER MODE/////////////////////////////////////


            //-----------------------------------------------      
            //All the Players and what team they are on

            Console.WriteLine("LEAGUE PLAYER INFORMATION");
            var players = db.Players.Include(i => i.Team);
            foreach (var person in players)
            {
                Console.WriteLine($"{person.FullName} plays for the {person.Team.Mascot}");
            }

            Console.WriteLine($"--------------------------------------------");


            //-----------------------------------------------
            //Past games

            Console.WriteLine("PREVIOUS LEAGUE GAMES");
            var past = db.Games.Where(game => game.Date < DateTime.Today);
            foreach (var game in past)
            {
                Console.WriteLine($"Games were played on {game.Date.ToString("MMMM dd, yyyy")}.");
            }

            Console.WriteLine($"--------------------------------------------");


            //-----------------------------------------------
            //All the teams, with their win / loss record

            Console.WriteLine("LEAGUE WIN/LOSS RECORD");
            var teams = db.Teams;
            foreach (var team in teams)
            {
                Console.WriteLine($"The {team.Mascot} have won {team.Wins} times and lost {team.Losses} times.");
            }

            Console.WriteLine($"--------------------------------------------");


            //-----------------------------------------------
            //All the Upcoming games(games who Date Happened is in the future)

            Console.WriteLine("UPCOMING LEAGUE GAMES");
            var upcoming = db.Games.Where(game => game.Date > DateTime.Today);
            foreach (var game in upcoming)
            {
                Console.WriteLine($"There is an upcoming game on {game.Date.ToString("MMMM dd, yyyy")}.");
            }

            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"--------------------------------------------");


            //ADVENTURE MODE/////////////////////////////////////


            var programRunning = true;
            while (programRunning)
            {
                Console.WriteLine("Select your next step: Add new (team) to the league, Add a (player) to the league, (Schedule) a game, (Update) game scores, or (Exit)");
                var response = Console.ReadLine().ToLower();

                if (response == "team")
                {
                    var addTeam = true;
                    while (addTeam)
                    {
                        Console.WriteLine("Please enter team mascot/name:");
                        var newTeamMascot = Console.ReadLine();
                        Console.WriteLine("Please enter team colors:");
                        var newTeamColors = Console.ReadLine();

                        var newTeam = new Model.Teams
                        {
                            Mascot = newTeamMascot,
                            Colors = newTeamColors,
                        };
                        db.Teams.Add(newTeam);
                        db.SaveChanges();
                        Console.WriteLine($"{newTeam.Mascot} added to the Tampa Bay Bocce Ball League!");
                        Console.WriteLine("Do you want to enter another team? (Y) or (N)");
                        var reply = Console.ReadLine().ToLower();
                        if (reply == "n")
                            {
                                addTeam = false;
                            }
                    }
                    



                }
                else if (response == "player")
                {
                    Console.WriteLine("Select: (View) win/loss records or (Add) a team to the league");

                }
                else if (response == "schedule")
                {
                    Console.WriteLine("Select: (View) win/loss records or (Add) a team to the league");

                }
                else if (response == "update")
                {

                }
                else
                {
                    programRunning = false;
                }





                // Allow Julia(the user) to create new players, and add them to a team
                //Allow Julia to create new teams
                //Allow Julia to schedule games only in the future
                // Allow Julia to enter in the score of a game(only in the past)





                
            }
        }
    }
}
