using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrashBandicoot.Models
{
    public class LevelRanking
    {
        public int GameNumber { get; set; }
        public string GameName { get; set; }
        public int LevelNumber { get; set; }
        public string LevelName { get; set; }
        public TimeSpan PlatinumTime { get; set; }
        public PlayerTime[] PlayerTimes { get; set; }
    }
}
