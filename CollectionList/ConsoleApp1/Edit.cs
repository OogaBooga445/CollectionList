using System;
using System.IO;

namespace connect
{
    class Edit
    {
        public static void EditRecord(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            // Display existing data to the user
            Console.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // Read the existing data into a 2D array
            string[][] data;
            using (StreamReader reader = new StreamReader(filePath))
            {
                int rowCount = File.ReadAllLines(filePath).Length;
                data = new string[rowCount][];
                for (int i = 0; i < rowCount; i++)
                {
                    data[i] = reader.ReadLine().Split(',');
                }
            }

            Console.WriteLine();
            Console.WriteLine("Enter the row number you want to edit (starting from 1): ");
            if (!int.TryParse(Console.ReadLine(), out int selectedRow) || selectedRow < 1 || selectedRow >= data.Length)
            {
                Console.WriteLine("Invalid row number.");
                return;
            }
            selectedRow--; // Adjust for 0-based indexing

            // Display column titles for reference
            string[] columnTitles = data[0];
            Console.WriteLine("Column titles:");
            for (int i = 0; i < columnTitles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {columnTitles[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter the column number you want to edit (starting from 1): ");
            if (!int.TryParse(Console.ReadLine(), out int selectedColumn) || selectedColumn < 1 || selectedColumn >= columnTitles.Length)
            {
                Console.WriteLine("Invalid column number.");
                return;
            }
            selectedColumn--; // Adjust for 0-based indexing

            // Display the current value of the selected cell
            string currentValue = data[selectedRow][selectedColumn];
            Console.WriteLine($"Current value: {currentValue}");

            Console.WriteLine();
            Console.WriteLine("Enter the new value: ");
            string newValue = Console.ReadLine();

            // Update the selected cell with the new value
            data[selectedRow][selectedColumn] = newValue;

            // Write the updated data back to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }

            Console.WriteLine("Record updated successfully.");
        }
    }
}
