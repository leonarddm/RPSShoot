using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSShoot.Console
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int HP { get; set; } = 3;
        public char ChoiceKey { get; set; }
        public Choice Choice { get; set; }
        public bool IsWinner { get; set; } = false;
    }
}
