using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class Club
    {
        public int id { get; set; }
        public int resource_state { get; set; }
        public string name { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public string cover_photo { get; set; }
        public string cover_photo_small { get; set; }
        public string sport_type { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public bool @private { get; set; }
        public int member_count { get; set; }
        public bool featured { get; set; }
        public bool verified { get; set; }
        public string url { get; set; }
    }
}
