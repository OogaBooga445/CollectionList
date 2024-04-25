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

            // Sort the data by rating (assuming rating is in the 7th column)
            if (ascending)
            {
                data = data.OrderBy(row => row.Length > 7 ? row[7] : "").ToList();
            }
            else
            {
                data = data.OrderByDescending(row => row.Length > 7 ? row[7] : "").ToList();
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

            Console.WriteLine($"Data sorted by {(ascending ? "ascending" : "descending")} order and saved successfully.");
        }
    }
}
