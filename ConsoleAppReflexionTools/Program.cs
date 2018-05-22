using System;

namespace ConsoleAppReflexionTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begining ... ");
            Project project = new Project
            {
                ProjectID = 1,
                Name = "Irrigation ",
                Description = "Working on ranches! "
            };

            ProjectBackup projectBackup = GenericTools.PassClassToDifferentClass<Project, ProjectBackup>(project);


            Console.WriteLine($"Project Source {project.ToString()}");
            Console.WriteLine($"Project Destiny {projectBackup.ToString()}");

            Console.WriteLine("Finishing ... ");
            Console.ReadKey();

        }
    }
}
