using System;
using System.IO;

namespace connect
{
    class Add
    {
        public static void AddRecord(string filePath)
        {
            string type = "";
            Console.WriteLine("Enter Type (Series or Movie):");
            type = Console.ReadLine();
            if (type.ToLower() == "series")
            {
                Console.WriteLine("Enter data (Title, Type(Series or Movie), Episode amount, Episodes watched, Genre, Release date, Rating, Status(Planned,Watching,Finished,On-Hold))(comma-separated):");
            }
            else if (type.ToLower() == "movie")
            {
                Console.WriteLine("Enter data (Title, Type(Series or Movie), Movie length, Time watched, Genre, Release date, Rating, Status(Planned,Watching,Finished,On-Hold))(comma-separated):");
            }
            else
            {
                Console.WriteLine("Invalid type entered. Please enter either 'Series' or 'Movie'.");
                return;
            }

            string input = Console.ReadLine();

            // Validate the input
            if (type.ToLower() == "series")
            {
                ValidateInput(input, 8);
            }
            else if (type.ToLower() == "movie")
            {
                ValidateInput(input, 8);
            }

            // Splitting the input by comma to get individual values
            string[] values = input.Split(',');

            // Validate Status input
            if (!ValidateStatus(values[7]))
            {
                Console.WriteLine("Error: Invalid Status. Please enter one of the following phrases: Planned, Watching, Finished, On-Hold.");
                // Recursively call the AddRecord method to prompt the user again
                AddRecord(filePath);
                return;
            }

            // Check if the file already exists
            bool fileExists = File.Exists(filePath);

            // Open the CSV file for appending data
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // If file doesn't exist or it's a new file, start from the first row
                if (!fileExists || new FileInfo(filePath).Length == 0)
                {
                    // Writing the values to the CSV file
                    for (int i = 0; i < values.Length; i++)
                    {
                        // If the value contains comma, enclose it within double quotes
                        if (values[i].Contains(","))
                        {
                            writer.Write("\"" + values[i] + "\"");
                        }
                        else
                        {
                            writer.Write(values[i]);
                        }

                        // Add comma if not last value
                        if (i < values.Length - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine(); // Move to the next line for the next record
                }
                else // Otherwise, start from the second row
                {
                    // Write a newline to move to the next row
                    writer.WriteLine();
                    // Writing the values to the CSV file
                    for (int i = 0; i < values.Length; i++)
                    {
                        // If the value contains comma, enclose it within double quotes
                        if (values[i].Contains(","))
                        {
                            writer.Write("\"" + values[i] + "\"");
                        }
                        else
                        {
                            writer.Write(values[i]);
                        }

                        // Add comma if not last value
                        if (i < values.Length - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine(); // Move to the next line for the next record
                }
            }

            Console.WriteLine("Record added successfully.");
        }

        static void ValidateInput(string input, int expectedValueCount)
        {
            string[] values = input.Split(',');
            if (values.Length != expectedValueCount)
            {
                Console.WriteLine($"Error: Invalid number of values. Expected {expectedValueCount} values.");
                Console.WriteLine("Please enter data again.");
                // Recursively call the AddRecord method to prompt the user again
                AddRecord(null);
            }
        }

        static bool ValidateStatus(string status)
        {
            string[] validStatuses = { "Planned", "Watching", "Finished", "On-Hold" };
            foreach (string validStatus in validStatuses)
            {
                if (status.Equals(validStatus, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
