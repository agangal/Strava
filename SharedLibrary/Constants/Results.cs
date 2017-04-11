using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{  
    public class Results
    {
        public string data;
        public ResultStatus result;
    }
    public enum ResultStatus
    {
        Unauthorized,
        Successful,
        Failed
    }
}
