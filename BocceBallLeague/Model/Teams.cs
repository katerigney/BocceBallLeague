using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBallLeague.Model
{
    public class Teams
    {
        public int ID { get; set; }
        public string Mascot { get; set; }
        public string Colors { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
