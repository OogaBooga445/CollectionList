using Microsoft.VisualBasic.FileIO;

namespace connect
{
    class Editor
    {
        public static void EditCsv(string filePath, Dictionary<string, string> changes)
        {
            string tempFilePath = Path.GetTempFileName();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (changes.ContainsKey(fields[0]))
                    {
                        fields[1] = changes[fields[0]];
                    }

                    writer.WriteLine(string.Join(",", fields));
                }
            }

            File.Replace(tempFilePath, filePath, null);
        }

        public static void Edit()
        {

            string filePath = "data.csv";

            var changes = new Dictionary<string, string>
            {
                { "old_value_1", "new_value_1" },
                { "old_value_2", "new_value_2" }
            };
            EditCsv(filePath, changes);

            Console.WriteLine("CSV file has been edited.");
        }
    }
}
