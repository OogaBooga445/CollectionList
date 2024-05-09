using System.Text.RegularExpressions;

namespace connect
{
    class Add
    {
        public static void AddRecord(string filePath)
        {
            string type = "";
            Console.WriteLine("Enter Type (Series or Movie):");

            while (true)
            {
                type = Console.ReadLine();
                if (type.ToLower() == "series" || type.ToLower() == "movie")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid type entered. Please enter either 'Series' or 'Movie'.");
                }
            }

            if (type.ToLower() == "series")
            {
                Console.WriteLine("Enter data (Title, Type(Series or Movie), Episode amount, Episodes watched, Genre, Release date (YYYY), Rating (0.0 - 10.0), Status(Planned,Watching,Finished,On-Hold))(comma-separated):");
            }
            else if (type.ToLower() == "movie")
            {
                Console.WriteLine("Enter data (Title, Type(Series or Movie), Movie length (HH:MM:SS), Time watched (HH:MM:SS), Genre, Release date (YYYY), Rating (0.0 - 10.0), Status(Planned,Watching,Finished,On-Hold))(comma-separated):");
            }

            string input = Console.ReadLine();

            // Validate the input
            bool isValid = ValidateInput(input, type.ToLower());

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please try again.");
                AddRecord(filePath);
                return;
            }

            // Append the validated data to the file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {

                writer.WriteLine("\n" + input);
            }

            Console.WriteLine("Record added successfully.");
        }

        static bool ValidateInput(string input, string type)
        {
            string[] values = input.Split(',');

            if (type == "series" && values.Length != 8)
            {
                Console.WriteLine($"Error: Invalid number of values. Expected 8 values, but received {values.Length}.");
                return false;
            }
            else if (type == "movie" && values.Length != 8)
            {
                Console.WriteLine($"Error: Invalid number of values. Expected 8 values, but received {values.Length}.");
                return false;
            }

            // Validate the status input
            string status = values[7].Trim();
            if (!IsValidStatus(status))
            {
                Console.WriteLine("Error: Invalid status. Please enter one of the following options for status: Planned, Watching, Finished, On-Hold.");
                return false;
            }
            // Validate the release date input
            string releaseDate = values[5].Trim();
            if (!IsValidReleaseDate(releaseDate))
            {
                Console.WriteLine("Error: Invalid release date format. Please enter a four-digit year (YYYY).");
                return false;
            }
            // Validate the rating input
            string rating = values[6].Trim();
            if (!IsValidRating(rating))
            {
                Console.WriteLine("Error: Invalid rating format. Please enter a rating between 0.0 and 10.0 with one decimal place.");
                return false;
            }

            return true;
        }

        static bool IsValidStatus(string status)
        {
            // Define the allowed status options
            string[] allowedStatusOptions = { "Planned", "Watching", "Finished", "On-Hold" };

            // Check if the status input matches any of the allowed options
            foreach (string option in allowedStatusOptions)
            {
                if (status.Equals(option, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsValidReleaseDate(string releaseDate)
        {
            // Check if the release date is a valid four-digit year
            return Regex.IsMatch(releaseDate, @"^\d{4}$");
        }

        static bool IsValidRating(string rating)
        {
            // Check if the rating is in the format 0.0 - 10.0 with one decimal place
            return Regex.IsMatch(rating, @"^\d+(\.\d)?0?$") && double.Parse(rating) >= 0 && double.Parse(rating) <= 10;
        }
    }
}
