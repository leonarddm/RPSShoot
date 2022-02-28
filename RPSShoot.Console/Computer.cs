using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSShoot.Console
{
    public class Computer
    {
        public string Name { get; set; } = "Gong [Computer]";
        public int HP { get; set; } = 3;
        public int ChoiceId { get; set; } = 0;
        public Choice Choice { get; set; }
        public bool IsWinner { get; set; } = false;
    }
}
