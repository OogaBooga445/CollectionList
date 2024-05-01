using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace connect
{
    class SortByRating
    {
        public static void SortAndSaveByRating(string filePath, bool ascending = true)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }

            // Read the CSV file into a list of string arrays, separating the header
            List<string[]> data = new List<string[]>();
            string header = ""; // Store the header separately
            using (StreamReader reader = new StreamReader(filePath))
            {
                header = reader.ReadLine(); // Read and store the header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(line.Split(','));
                }
            }

            // Find the index of the rating column (assuming it's labeled as "Rating")
            int ratingColumnIndex = Array.IndexOf(header.Split(','), "Rating");

            // Check if the rating column exists in the header
            if (ratingColumnIndex == -1)
            {
                Console.WriteLine("Rating column not found in the header.");
                return;
            }

            // Sort the data by rating
            if (ascending)
            {
                data = data.OrderBy(row => row.Length > ratingColumnIndex ? row[ratingColumnIndex] : "").ToList();
            }
            else
            {
                data = data.OrderByDescending(row => row.Length > ratingColumnIndex ? row[ratingColumnIndex] : "").ToList();
            }

            // Rewrite the sorted data back to the CSV file, including the header
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(header); // Write the header first
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }

            Console.WriteLine($"Data sorted {(ascending ? "ascending" : "descending")} and saved successfully.");
        }
    }
}
