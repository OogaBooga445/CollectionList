namespace connect
{
    

class Adding {


        public static void Add() {

            string filePath = "data.csv";

            // Data to write to the CSV file
            string[] data = { "John", "Doe", "30" };

            // Write to the CSV file
            using StreamWriter writer = new StreamWriter(filePath, true);
            foreach (string value in data)
            {
                writer.Write(value + ", ");
            }
            writer.WriteLine(); // Move to the next line
            Console.WriteLine("Dati saglabāti");
        }
    }
}