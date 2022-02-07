using System;
using System.Collections.Generic;
using System.Text;

namespace League_Watcher.ViewModels.Match
{
    class MatchMetadata
    {
        public string dataVersion { get; set; }
        public string matchId { get; set; }
        public List<string> participants { get; set; }
    }
}
