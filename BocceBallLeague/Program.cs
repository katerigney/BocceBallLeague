using BocceBallLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBallLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();

            //All the teams, with their win / loss record
            //All the Players and what team they are on
            //All the Upcoming games(games who Date Happened is in the future)

            var upcoming = db.Games.Where(game => game.Date > DateTime.Today);
            foreach (var game in upcoming)
            {
                Console.WriteLine($"There is an upcoming game on {game.Date.ToString("MMMM dd, yyyy")}.");
                
            }

            Console.WriteLine($"--------------------------------------------");


            //Past games

            var past = db.Games.Where(game => game.Date < DateTime.Today);
            foreach (var game in past)
            {
                Console.WriteLine($"Games were played on {game.Date}.");

            }



            /*var firstTeam = new Model.Teams
            {
                Mascot = "Bradenton Manatees",
                Colors = "Aqua/Blue",
                Records = new Model.Record()
                {
                    Wins = 0,
                    Losses=9
                }
            };
            db.Teams.Add(firstTeam);
            db.SaveChanges();*/




            Console.ReadLine();
        }
    }
}
