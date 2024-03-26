namespace connect 
{
    class Add
    {
        public static void WriteToCsv(string filePath)
        {
            // Create the jagged array
            int[][] data = {
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            };

            // Specify the path for the CSV file
            filePath = "data.csv";

            // Write data to CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int[] row in data)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        writer.Write(row[i]);

                        if (i < row.Length - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Data has been written to CSV file.");
        }
    }
}
