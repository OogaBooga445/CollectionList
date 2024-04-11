using System;
using System.Collections.Generic;

namespace connect
{
    class Sort
    {
        public static void SortCsv(string filePath, int columnToSortBy, bool ascending)
        {
            // Read all lines from the CSV file
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Parse the CSV data into a list of string arrays
            List<string[]> data = new List<string[]>();
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                data.Add(values);
            }

            // Sort the data based on the specified column and order
            data.Sort((x, y) =>
            {
                if (ascending)
                    return x[columnToSortBy].CompareTo(y[columnToSortBy]);
                else
                    return y[columnToSortBy].CompareTo(x[columnToSortBy]);
            });

            // Write the sorted data back to the CSV file
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }
    }
}
