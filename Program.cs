// ehz
using System;
using System.IO;
using System.IO.Compression;

namespace ToZip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = args[0];

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                Console.WriteLine("Podana ścieżka jest pusta lub nieprawidłowa.");
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Podana ścieżka nie jest prawidłowym folderem.");
                return;
            }

            string zipFilePath = folderPath.TrimEnd(Path.DirectorySeparatorChar) + ".zip";
            try
            {
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                }
                ZipFile.CreateFromDirectory(folderPath, zipFilePath);
                Console.WriteLine($"Folder {folderPath} został spakowany do pliku {zipFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return;
            }
        }
    }
}
