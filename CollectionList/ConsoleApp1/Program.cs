namespace connect
{
  class Program {

      public static void Main(string[] args) {
              Registry.Register();
              Log_in.Login();
              while (true)
              {
                  Console.WriteLine("\nPlease choose an action:");
                  Console.WriteLine("1. Add a record");
                  Console.WriteLine("2. Edit a record");
                  Console.WriteLine("3. Read the watchlist");
                  Console.WriteLine("4. Remove a record");
                  Console.WriteLine("5. Sorting the watchlist");
                  Console.WriteLine("6. Exit");

                  Console.Write("Enter your choice: ");
                  string choice = Console.ReadLine();

                  switch (choice)
                  {
                      case "1":
                          Console.WriteLine("\nAdding a new record...");
                          Add.AddRecord("data.csv");
                          break;
                      case "2":
                          Console.WriteLine("\nEditing a record...");
                          Edit.EditRecord("data.csv");
                          break;
                      case "3":
                          Console.WriteLine("\nReading the watchlist...");
                          Reader.Read();
                          break;
                      case "4":
                          Console.WriteLine("\nRemoving a record");
                          Remove.RemoveRecord("data.csv");
                          break;
                      case "5":
                          Console.WriteLine("\nPlease choose the sorting method:");
                          Console.WriteLine("1. Sort by rating (ascending)");
                          Console.WriteLine("2. Sort by rating (descending)");
                          Console.WriteLine("3. Sort by title (ascending)");
                          Console.WriteLine("4. Sort by title (descending)");
                          Console.Write("Enter your choice: ");
                          string sortChoice = Console.ReadLine();

                          switch (sortChoice)
                          {
                              case "1":
                                  Console.WriteLine("\nSorting by rating (ascending)...");
                                  SortByRating.SortAndSaveByRating("data.csv", true);
                                  break;
                              case "2":
                                  Console.WriteLine("\nSorting by rating (descending)...");
                                  SortByRating.SortAndSaveByRating("data.csv", false);
                                  break;
                              case "3":
                                  Console.WriteLine("\nSorting by title (ascending)...");
                                  SortByTitle.SortAndSaveByTitle("data.csv", true);
                                  break;
                              case "4":
                                  Console.WriteLine("\nSorting by title (descending)...");
                                  SortByTitle.SortAndSaveByTitle("data.csv", false);
                                  break;
                              default:
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                                break;
                          }
                          break;
                      case "6":
                          Console.WriteLine("Exiting the program. Goodbye!");
                          return;
                      default:
                          Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                          break;
                  }
              }
          }
      }
  }