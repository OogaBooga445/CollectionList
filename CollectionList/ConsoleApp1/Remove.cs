using System;
using System.IO;

namespace connect
{
    class Remove
    {
        public static void RemoveRecord(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read and display the column titles
                string columnTitles = reader.ReadLine();
                Console.WriteLine(columnTitles);
                Console.Clear();
                Console.WriteLine(@"

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/  
            ");
                Console.WriteLine();

                // Display the data (excluding the first line)
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    foreach (string value in values)
                    {
                        Console.Write(value + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter the name of the movie or series you want to remove: ");
            string input = Console.ReadLine();

            string tempFile = Path.GetTempFileName(); // Create a temporary file

            bool found = false;

            // Read the CSV file and write to the temporary file, excluding rows with the matching value
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                // Write the column titles to the temporary file
                writer.WriteLine(reader.ReadLine());

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    // If the first column value doesn't match the input, keep the row
                    if (values[0].Trim() != input)
                    {
                        writer.WriteLine(line); // Write the line to the temporary file
                    }
                    else
                    {
                        found = true; // Record found and removed
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching record found.");
                File.Delete(tempFile); // Delete the temporary file if no record was removed
                return;
            }

            // Replace the original file with the temporary file
            File.Delete(filePath);
            File.Move(tempFile, filePath);

            Console.WriteLine("Record removed successfully.");
        }
    }
}
