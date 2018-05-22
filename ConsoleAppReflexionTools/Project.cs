using System;

namespace ConsoleAppReflexionTools
{
    public class Project
    {
        public int ProjectID { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public override string ToString()
        {
            return $"Project {ProjectID}, Name {Name}, Description {Description}";
        }
    }
}
