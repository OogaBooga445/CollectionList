using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace connect
{
    class Editor
    {
        public static void EditCsv(string filePath, int row, int column, string newValue)
{
    // Create a temporary file to write the modified content
    string tempFilePath = Path.GetTempFileName();

    try
    {
        bool rowFound = false;

        using (TextFieldParser parser = new TextFieldParser(filePath))
        using (StreamWriter writer = new StreamWriter(tempFilePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            int currentRow = 0;

            // Iterate through the CSV rows
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                // If the current row matches the specified row
                if (currentRow == row)
                {
                    rowFound = true;

                    // Ensure the specified column is within the range
                    if (column >= 0 && column < fields.Length)
                    {
                        // Modify the value in the specified column
                        fields[column] = newValue;
                    }
                    else
                    {
                        Console.WriteLine("Column index out of range.");
                    }
                }

                // Write the modified or unmodified row to the temporary file
                writer.WriteLine(string.Join(",", fields));

                currentRow++;
            }

            // If the specified row was not found in the CSV
            if (!rowFound)
            {
                Console.WriteLine("Row index out of range.");
            }
        }

        // Replace the original file with the modified one
        File.Replace(tempFilePath, filePath, null);
        Console.WriteLine("CSV file has been edited.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}


        public static void Edit()
        {
            string filePath = "data.csv";

            // Get user input for row, column, and new value
            Console.WriteLine("Enter the row number to edit:");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number to edit:");
            int column = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new value:");
            string newValue = Console.ReadLine();

            // Edit the CSV file
            EditCsv(filePath, row, column, newValue);
        }
    }
}
