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
            // Read the CSV file into a list of string arrays
            List<string[]> data = new List<string[]>();
            using (StreamReader reader = new StreamReader(filePath))
            {
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

            // Rewrite the sorted data back to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }

            Console.WriteLine($"Data sorted {(ascending ? "ascending" : "descending")} and saved successfully.");
        }
    }
}
