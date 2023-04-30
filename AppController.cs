using CSCI428_SQLProject.Commands;

namespace CSCI428_SQLProject;
 //Class for handling all input from console (contains all functionality for console commands)
public class AppController 
{
	//Properties
	public bool IsDone { get; set; }

	//Default Constructor
	public AppController()
	{
		this.IsDone = false;
	}

	//Methods
	public void Start()
	{
		string input;
        Console.WriteLine("Welcome to the Fuck You industries DBMS portal!");
		Console.WriteLine("===============================================\n");
		while (true)
		{
			//Take input and retry until valid input
			bool validInput;
			while (true)
			{
				Console.WriteLine("\nEnter a command: ");
                input = Console.ReadLine()!;
                validInput = ValidateCommand(input);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please try again or enter HELP to see the available commands.");
                }
                else //Parse and execute command from input
                {
                    this.IsDone = HandleInput(input);
					break;
                }
            }
            if (this.IsDone)
            {
                break;
            }
        }
		Console.WriteLine("\nThank you for using our system! Have a great day.");
	}

	public static bool ValidateCommand(string input) //Checks to see if entered string is valid input
	{
        return input.Split(" ")[0] switch
        {
            ("LIST") => true,
            ("ADD") => true,
            ("UPDATE") => true,
            ("DELETE") => true,
            ("QUIT") => true,
            ("HELP") => true,
            _ => false,
        };
    }

    public static bool HandleInput(string input) //Checks to see if entered string is valid input
    {
        switch (input.Split(" ")[0])
        {
			default:
				Console.WriteLine("This command is not yet implemented.");
				return false;

            case "DELETE":
                Delete delete = new();
				delete.Initialize(input.Split(" "));
				delete.Execute();
				return false;

            case "HELP":
                PrintHelpMenu();
                return false;

			case "QUIT":
				return true;
        }
    }

    public static void PrintHelpMenu()
    {
        Console.WriteLine("                 HELP MENU                   ");
        Console.WriteLine("=============================================");
        Console.WriteLine("LIST - Lists all records in the database.");
        Console.WriteLine("ADD - Adds a new record to the database.");
        Console.WriteLine("UPDATE - Updates a record in the database.");
        Console.WriteLine("DELETE - Deletes a record from the database.");
        Console.WriteLine("QUIT - Exits the program.");
        Console.WriteLine("HELP - Displays command menu.");
        Console.WriteLine("=============================================");
    }
}