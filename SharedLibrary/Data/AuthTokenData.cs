using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class AuthTokenData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public Athlete athlete { get; set; }
    }
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

    public class Sho
    {
        public string id { get; set; }
        public bool primary { get; set; }
        public string name { get; set; }
        public int resource_state { get; set; }
        public int distance { get; set; }
    }

    public class Athlete
    {
        public int id { get; set; }
        public string username { get; set; }
        public int resource_state { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string sex { get; set; }
        public bool premium { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int badge_type_id { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public object friend { get; set; }
        public object follower { get; set; }
        public int follower_count { get; set; }
        public int friend_count { get; set; }
        public int mutual_friend_count { get; set; }
        public int athlete_type { get; set; }
        public string date_preference { get; set; }
        public string measurement_preference { get; set; }
        public List<Club> clubs { get; set; }
        public string email { get; set; }
        public object ftp { get; set; }
        public double weight { get; set; }
        public List<object> bikes { get; set; }
        public List<Sho> shoes { get; set; }
    }
}
