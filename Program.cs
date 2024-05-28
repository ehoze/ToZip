using System;
using System.IO;
using System.IO.Compression;

namespace ToZip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Przeciągnij tutaj folder aby go spakować do pliku .zip");
            }

            string folderPath = args[0];
            
            if (Directory.Exists(folderPath))
            {
                string zipFilePath = folderPath.TrimEnd(Path.DirectorySeparatorChar) + ".zip";
    
                try
                {
                    if(File.Exists(zipFilePath))
                    {
                        File.Delete(zipFilePath);
                    }

                    ZipFile.CreateFromDirectory(folderPath, zipFilePath);
                    Console.WriteLine($"Folder {folderPath} został spakowany do pliku {zipFilePath}");

                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Podana ścieżka nie jest prawidłowym folderem.");
            }
        }
    }
}
