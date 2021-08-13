using System;
using DB.Core;

namespace DB.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService(@"mongodb://localhost:27017");

            string dbFileName = Guid.NewGuid().ToString();

            Console.WriteLine($"Uploading {dbFileName}");

            fileService.UploadFile(@"C:\Users\martin.davies\Downloads\pgadmin4-5.5-x64.exe", dbFileName);

            Console.WriteLine($"Downloading {dbFileName}");
            fileService.DownloadFile(dbFileName, $"C:\\temp\\pgadmin4 - 5.5 - x64.exe");

            Console.WriteLine("Press <any> key to quit.");
            Console.ReadKey(true);

        }
    }
}
