using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            
            FoundFiles = new List<FileInfo>();

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                return;
            }



            RecursiveSearch(FoundFiles, fileName, rootDir);

            Console.WriteLine("Found {0} files.", FoundFiles.Count);

            foreach (FileInfo fil in FoundFiles)
            {
                Console.WriteLine("{0}", fil.FullName);
            }

            Console.ReadKey();
        }

        static List<FileInfo> FoundFiles;

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo fil in currentDirectory.GetFiles())
            {
                if (fil.Name == fileName)
                    foundFiles.Add(fil);
            }
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }
    }
}
