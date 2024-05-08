namespace connect {
    class Reader {

        public static void Read() {

            string filePath = "data.csv";
            
            using StreamReader reader = new StreamReader(filePath);
            Console.Clear();
            Console.WriteLine(@"

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/  
            ");
            Console.WriteLine();

            // Initialize an array to store the maximum width of each column
            int[] maxWidths = new int[8];

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                // Update the maximum width for each column
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Length > maxWidths[i])
                    {
                        maxWidths[i] = values[i].Length;
                    }
                }
            }

            // Reset the reader position to the beginning of the file
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                // Output each value with proper spacing to align the columns
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write(values[i].PadRight(maxWidths[i] + 2));
                }
                Console.WriteLine();
            }
        }
    }
}
