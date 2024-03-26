namespace connect
{
    class Add
    {
        public static void CreateAndDisplayArray()
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns:");
            int columns = int.Parse(Console.ReadLine());

            string[,] array = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Enter value for element at position [{i},{j}]: ");
                    array[i, j] = Console.ReadLine();
                }
            }

            Console.WriteLine("\nArray:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Write data to CSV file
            string filePath = "data.csv";
            WriteToCsv(array, filePath);
            Console.WriteLine("Data has been written to CSV file.");
        }

        private static void WriteToCsv(string[,] data, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        writer.Write(data[i, j]);

                        if (j < data.GetLength(1) - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
