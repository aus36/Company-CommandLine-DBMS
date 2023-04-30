//Class for handling input and executing commands
using CSCI428_SQLProject.Commands;

namespace CSCI428_SQLProject;

public class AppController
{
	//Properties
	public bool IsDone { get; set; }

	//Default Constructor
	public AppController()
	{
        IsDone = false;
	}

	//Methods
	public void Start() //Starts the program and controls flow
	{
		string input;
        Console.WriteLine("Welcome to the Contoso Industries DBMS portal!");
		Console.WriteLine("==============================================\n");
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
                    IsDone = HandleInput(input);
					break;
                }
            }
            if (IsDone)
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

            case "LIST":
                List list = new();
                list.Initialize(input.Split(" "));
                list.Execute();
                return false;

            case "ADD":
                Add add = new();
                add.Initialize(input.Split(" "));
                add.Execute();
                return false;

            case "UPDATE":
                Update update = new();
                update.Initialize(input.Split(" "));
                update.Execute();
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
        Console.WriteLine("                                                  HELP MENU                                                     ");
        Console.WriteLine("================================================================================================================");
        Console.WriteLine("LIST [type] [page] [count] [orderby] [direction] - Lists person records in the database.");
        Console.WriteLine("\tArgs:");
        Console.WriteLine("\t\ttype - Either ALL or (Retiree, Employee, PreHire) - Lists all records or records of a specific type");
        Console.WriteLine("\t\tpage - (int) - page number");
        Console.WriteLine("\t\tcount - (int) - number of records per page");
        Console.WriteLine("\t\torderby - (string) field - field to sort the data by");
        Console.WriteLine("\t\tdirection - (string) Ascending or Descending - determines sort direction\n");
        Console.WriteLine("ADD [data] - Adds a new record to the database.");
        Console.WriteLine("\tArgs:");
        Console.WriteLine("\t\tdata - (field:value array) ex: ID 245 FirstName Austin LastName Hale - determines data for new record\n");
        Console.WriteLine("UPDATE [personID] [data] - Updates a record in the database.");
        Console.WriteLine("\tArgs:");
        Console.WriteLine("\t\tpersonID - (int) - The ID number of the person record to update");
        Console.WriteLine("\t\tdata - (field:value array) ex: ID 245 FirstName Austin LastName Hale - determines data for the record\n");
        Console.WriteLine("DELETE [personID or *] - Deletes a record from the database.");
        Console.WriteLine("\tArgs:");
        Console.WriteLine("\t\tpersonID (int) - Deletes the record of the person with this ID");
        Console.WriteLine("\t\t* - Deletes all person records in the DB\n");
        Console.WriteLine("HELP - Displays command menu.\n");
        Console.WriteLine("QUIT - Exits the program.");
        Console.WriteLine("=================================================================================================================");
    }
}