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
}
