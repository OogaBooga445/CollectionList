using System.Text.RegularExpressions;

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

            // Read the column names (first row) separately
            string[] columnNames;
            using (StreamReader reader = new StreamReader(filePath))
            {
                columnNames = reader.ReadLine().Split(',');
            }

            // Display existing data to the user, including column titles from the second row
            Console.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool firstLine = true; // Flag to skip the first line (column names)
                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        continue; // Skip the first line
                    }
                    Console.WriteLine(line);
                }
            }

            // Read the existing data into a 2D array, excluding the first row
            string[][] data;
            using (StreamReader reader = new StreamReader(filePath))
            {
                int rowCount = File.ReadAllLines(filePath).Length - 1; // Exclude the first row
                data = new string[rowCount][];
                string line = reader.ReadLine(); // Skip the first line (column names)
                for (int i = 0; i < rowCount; i++)
                {
                    data[i] = reader.ReadLine().Split(',');
                }
            }

            Console.WriteLine();

            // Loop to get valid row number
            int selectedRow = -1;
            while (selectedRow < 1 || selectedRow > data.Length)
            {
                Console.WriteLine("Enter the row number you want to edit (starting from 1): ");
                if (!int.TryParse(Console.ReadLine(), out selectedRow))
                {
                    Console.WriteLine("Invalid row number. Please try again.");
                }
            }
            selectedRow--; // Adjust for 0-based indexing

            // Display column titles for reference
            Console.WriteLine("Column titles:");
            for (int i = 0; i < columnNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {columnNames[i]}");
            }

            Console.WriteLine();

            // Loop to get valid column number
            int selectedColumn = -1;
            while (selectedColumn < 1 || selectedColumn > columnNames.Length)
            {
                Console.WriteLine("Enter the column number you want to edit (starting from 1): ");
                if (!int.TryParse(Console.ReadLine(), out selectedColumn))
                {
                    Console.WriteLine("Invalid column number. Please try again.");
                }
            }
            selectedColumn--; // Adjust for 0-based indexing

            // Display the current value of the selected cell
            string currentValue = data[selectedRow][selectedColumn];
            Console.WriteLine($"Current value: {currentValue}");

            Console.WriteLine();

            // Loop to get valid new value
            string newValue = string.Empty;
            while (string.IsNullOrEmpty(newValue))
            {
                Console.WriteLine("Enter the new value: ");
                newValue = Console.ReadLine();
                // Validate the new value based on the column type
                if (!IsValidInput(selectedColumn, newValue))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    newValue = string.Empty;
                }
            }

            // Update the selected cell with the new value
            data[selectedRow][selectedColumn] = newValue;

            // Write the updated data back to the CSV file, including the first row
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(string.Join(",", columnNames)); // Write the column names
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }

            Console.WriteLine("Record updated successfully.");
        }

        // Validate the input based on the column type
        static bool IsValidInput(int columnIndex, string value)
        {
            switch (columnIndex)
            {
                // For Release date column
                case 5:
                    return IsValidReleaseDate(value);
                // For Rating column
                case 6:
                    return IsValidRating(value);
                // For Status column
                case 7:
                    return IsValidStatus(value);
                // For Time columns (Movie length and Time watched)
                case 2:
                case 3:
                    return IsValidTimeFormat(value);
                default:
                    return true; // Allow any value for other columns
            }
        }

        // Validation methods
        static bool IsValidReleaseDate(string releaseDate)
        {
            return Regex.IsMatch(releaseDate, @"^\d{4}$");
        }

        static bool IsValidRating(string rating)
        {
            return Regex.IsMatch(rating, @"^\d+(\.\d)?0?$") && double.Parse(rating) >= 0 && double.Parse(rating) <= 10;
        }

        static bool IsValidStatus(string status)
        {
            string[] allowedStatusOptions = { "Planned", "Watching", "Finished", "On-Hold" };
            return allowedStatusOptions.Contains(status, StringComparer.OrdinalIgnoreCase);
        }

        static bool IsValidTimeFormat(string time)
        {
            return Regex.IsMatch(time, @"^\d{2}:\d{2}:\d{2}$");
        }
    }
}
 