using DatabaseHelper.SQL;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace G19_ProductImport
{
    internal class Program
    {
        static void Main()
        {
            const string filePath = @"D:\products2.txt";
            const string connectionString = "Server=DESKTOP-1LMJK76\\SQLEXPRESS; Database=G19; Integrated Security=true; TrustServerCertificate=true";

            DatabaseHelper.SQL.DatabaseHelper database = new DatabaseHelper.SQL.DatabaseHelper(connectionString);
            DatabaseImporter importer = new DatabaseImporter(connectionString);

            importer.ImportData(FileManager.ReadData(filePath));       
            
            //database.OpenConnection();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var categories = FileManager.ReadData(filePath);
                foreach (var category in categories)
                {
                    Console.WriteLine(category);
                    foreach(var product in category.Products)
                    {
                        Console.WriteLine($"\t{product}");
                    }
                }

                //importer.ImportData(categories);
                //var importer = new DatabaseImporter(connectionString);
                //Console.WriteLine("Data imported.");
                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.ElapsedMilliseconds} - Time");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //finally
            //{
            //    database.CloseConnection();
            //}            
        }
    }
}