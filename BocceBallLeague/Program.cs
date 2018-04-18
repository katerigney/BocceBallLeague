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
                    var addPlayer = true;
                    while (addPlayer)
                    {
                        Console.WriteLine("Please enter player name:");
                        var newPlayerName = Console.ReadLine();
                        Console.WriteLine("Please enter player nickname:");
                        var newPlayerNickname = Console.ReadLine();
                        Console.WriteLine("Please enter player number:");
                        var newPlayerNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Which are does the player throw with? (L) or (R)");
                        var newPlayerArm = Console.ReadLine();
                        Console.WriteLine("Which team will the play on?");
                        var newPlayerTeam = Console.ReadLine();

                        var newPlayerTeamName = db.Teams.First(team => team.Mascot == newPlayerTeam);

                        var newPlayer = new Model.Players
                        {
                            FullName = newPlayerName,
                            Nickname = newPlayerNickname,
                            Number = newPlayerNumber,
                            ThrowingArm = newPlayerArm,
                            Team = newPlayerTeamName
                        };
                        db.Players.Add(newPlayer);
                        db.SaveChanges();
                        Console.WriteLine($"{newPlayer.FullName} added to the Tampa Bay Bocce Ball League!");
                        Console.WriteLine("Do you want to enter another player? (Y) or (N)");
                        var reply = Console.ReadLine().ToLower();
                        if (reply == "n")
                        {
                            addPlayer = false;
                        }
                    }
                }
                else if (response == "schedule")
                {
                    var addGame = true;
                    while (addGame)
                    {
                        Console.WriteLine("Please enter the home team:");
                        var newGameHomeTeam = Console.ReadLine();
                        Console.WriteLine("Please enter the away team:");
                        var newGameAwayTeam = Console.ReadLine();
                        Console.WriteLine("Please enter the game date:");
                        Console.WriteLine("Format: YYYY-MM-DD");
                        var newGameDate = Console.ReadLine();

                        var newGameHomeTeamName = db.Teams.First(team => team.Mascot == newGameHomeTeam);
                        var newGameAwayTeamName = db.Teams.First(team => team.Mascot == newGameAwayTeam);

                        var newGame = new Model.Games
                        {
                            HomeTeam = newGameHomeTeamName,
                            AwayTeam = newGameAwayTeamName,
                            Date = Convert.ToDateTime(newGameDate)
                        };
                        db.Games.Add(newGame);
                        db.SaveChanges();
                        Console.WriteLine($"Game on {newGame.Date.ToString("MMMM dd, yyyy")} added to the Tampa Bay Bocce Ball League Schedule!");
                        Console.WriteLine("Do you want to enter another game? (Y) or (N)");
                        var reply = Console.ReadLine().ToLower();
                        if (reply == "n")
                        {
                            addGame = false;
                        }
                    }
                }
                else if (response == "update")
                {
                    //Allow Julia to enter in the score of a game(only in the past)
                    Console.WriteLine("Enter the game date:");
                    Console.WriteLine("Format: YYYY-MM-DD");
                    var reply = Convert.ToDateTime(Console.ReadLine());
                    var gameToUpdate = db.Games.First(game => game.Date == reply);

                    Console.WriteLine("Enter home team score:");
                    var newHomeTeamScore = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter away team score:");
                    var newAwayTeamScore = Convert.ToInt32(Console.ReadLine());

                    var homeTeamUpdate = db.Teams.First(team => team.ID == gameToUpdate.HomeTeam.ID);
                    var awayTeamUpdate = db.Teams.First(team => team.ID == gameToUpdate.AwayTeam.ID);

                    if (newHomeTeamScore > newAwayTeamScore)
                    {
                        homeTeamUpdate.Wins++;
                        awayTeamUpdate.Losses++;
                    }
                    else
                    {
                        homeTeamUpdate.Losses++;
                        awayTeamUpdate.Wins++;
                    }
                    db.SaveChanges();
                }
                else
                {
                    programRunning = false;
                }                
            }
        }
    }
}
