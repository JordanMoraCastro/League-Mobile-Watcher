using System;
using System.Collections.Generic;
using System.Text;

namespace League_Watcher.ViewModels
{
    class SummonerMasteryViewModel
    {
        public int championId { get; set; }
        public int championLevel { get; set; }
        public int championPoints { get; set; }
        public object lastPlayTime { get; set; }
        public int championPointsSinceLastLevel { get; set; }
        public int championPointsUntilNextLevel { get; set; }
        public bool chestGranted { get; set; }
        public int tokensEarned { get; set; }
        public string summonerId { get; set; }
    }
}
