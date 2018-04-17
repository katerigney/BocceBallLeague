using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBallLeague.Model
{
    public class Record
    {
        public int RecordID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        //[ForeignKey("Teams")]
        //public int? TeamsId { get; set; }
        //public Teams Teams { get; set; }

    }
}
