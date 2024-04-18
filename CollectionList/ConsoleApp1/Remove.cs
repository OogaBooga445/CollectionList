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

            Console.WriteLine("Enter the name of the movie or series you want to remove: ");
            string input = Console.ReadLine();

            string tempFile = Path.GetTempFileName(); // Create a temporary file

            bool found = false;

            // Read the CSV file and write to the temporary file, excluding rows with the matching value
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                string line;
                bool isFirstRow = true;

                while ((line = reader.ReadLine()) != null)
                {
                    // If it's the first row or the first column value doesn't match the input, keep the row
                    if (isFirstRow || line.Split(',')[0].Trim() != input)
                    {
                        writer.WriteLine(line); // Write the line to the temporary file
                    }
                    else
                    {
                        found = true; // Record found and removed
                    }

                    isFirstRow = false;
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

            Console.WriteLine("Record(s) removed successfully.");
        }
    }
}
