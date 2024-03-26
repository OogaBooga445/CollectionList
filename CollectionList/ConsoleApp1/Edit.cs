// using Microsoft.VisualBasic.FileIO;

// namespace connect
// {
//     class Editor {
//         public static void Edit() {

//             using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Specify the path to the CSV file
//         string filePath = "path_to_your_csv_file.csv";

//         // Example changes (you can modify this dictionary according to your needs)
//         var changes = new Dictionary<string, string>
//         {
//             { "old_value_1", "new_value_1" },
//             { "old_value_2", "new_value_2" }
//         };

//         // Edit the CSV file
//         EditCsv(filePath, changes);

//         Console.WriteLine("CSV file has been edited.");
//     }

//     static void EditCsv(string filePath, Dictionary<string, string> changes)
//     {
//         // Create a temporary file path
//         string tempFilePath = Path.GetTempFileName();

//         using (TextFieldParser parser = new TextFieldParser(filePath))
//         using (StreamWriter writer = new StreamWriter(tempFilePath))
//         {
//             parser.TextFieldType = FieldType.Delimited;
//             parser.SetDelimiters(",");

//             while (!parser.EndOfData)
//             {
//                 // Read and parse a row from the CSV file
//                 string[] fields = parser.ReadFields();

//                 // Apply changes to the row if necessary
//                 if (changes.ContainsKey(fields[0]))
//                 {
//                     fields[1] = changes[fields[0]];
//                 }

//                 // Write the modified row to the temporary file
//                 writer.WriteLine(string.Join(",", fields));
//             }
//         }

//         // Replace the original file with the temporary file
//         File.Replace(tempFilePath, filePath, null);
//     }
// }

//         }
//     }
// }