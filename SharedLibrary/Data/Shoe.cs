using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{   
    public class Shoe
    {
        public string id { get; set; }
        public bool primary { get; set; }
        public string name { get; set; }
        public int resource_state { get; set; }
        public double distance { get; set; }
    }
}
