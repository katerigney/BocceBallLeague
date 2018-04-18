using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBallLeague.Model
{
    public class Players
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public int Number { get; set; }
        public string ThrowingArm { get; set; }
        public int? TeamID { get; set; }
        public Teams Team { get; set; }

    }
}
