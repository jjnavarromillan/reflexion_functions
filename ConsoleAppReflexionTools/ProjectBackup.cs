using System;

namespace ConsoleAppReflexionTools
{
    public class ProjectBackup
    {
        public int ProjectBackupID { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public override string ToString()
        {
            return $"ProjectBackup {ProjectBackupID}, Name {Name}, Description {Description}";
        }
    }
}
