//Class for handling input and executing commands
using CSCI428_SQLProject.Commands;

namespace CSCI428_SQLProject;

public class AppController
{
	//Properties
	public bool IsDone { get; set; }
    public bool TestValid { get; set; } = false; //exists purely for unit testing purposes

	//Default Constructor
	public AppController()
	{
        IsDone = false;
	}

	//Methods
	public void Start() //Starts the program and controls flow
	{
		string input;
        Console.WriteLine("Welcome to the Company Industries DBMS portal!");
		Console.WriteLine("==============================================");
        Console.WriteLine("|                   RULES                    |");
        Console.WriteLine("|* All parameter counts are exact            |");
        Console.WriteLine("|* All parameters/commands are case sensitive|");
        Console.WriteLine("|* All parameters are space delimited        |");
        Console.WriteLine("|* All parameters stated in help are required|");
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
                    Console.WriteLine("Invalid Command. Please try again or enter HELP to see the available commands.");
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

    public bool HandleInput(string input) //Checks to see if entered string is valid input
    {
        switch (input.Split(" ")[0])
        {
			default:
				Console.WriteLine("This command is not yet implemented.");
				return false;

            case "LIST":
                if(input.Split(" ").Length != 6) //Validation check
                {
                    Console.WriteLine("Invalid number of arguments.");
                    TestValid = false;
                    return false;
                }
                TestValid = true;
                List list = new();
                list.Initialize(input.Split(" "));
                list.Execute();
                return false;

            case "ADD":
                if (input.Split(" ").Length < 3) //Validation check
                {
                    Console.WriteLine("Invalid number of arguments.");
                    TestValid = false;
                    return false;
                }
                TestValid = true;
                Add add = new();
                add.Initialize(input.Split(" "));
                add.Execute();
                return false;

            case "UPDATE":
                if(input.Split(" ").Length < 3) //Validation check
                {
                    Console.WriteLine("Invalid number of arguments.");
                    TestValid = false;
                    return false;
                }
                TestValid = true;
                Update update = new();
                update.Initialize(input.Split(" "));
                update.Execute();
                return false;

            case "DELETE":
                if(input.Split(" ").Length != 2) //Validation check
                {
                    Console.WriteLine("Invalid number of arguments.");
                    TestValid = false;
                    return false;
                }
                TestValid = true;
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
        Console.WriteLine("\tArgs (5)");
        Console.WriteLine("\ttype - Either ALL or (Retiree, Employee, PreHire) - Lists all records or records of a specific type");
        Console.WriteLine("\tpage - (int) - page number");
        Console.WriteLine("\tcount - (int) - number of records per page");
        Console.WriteLine("\torderby - (string) field - field to sort the data by");
        Console.WriteLine("\tdirection - (string) ASC or DESC - determines sort direction");
        Console.WriteLine("\tex: LIST Employee 1 1 FirstName Descending\n");
        Console.WriteLine("ADD [data] - Adds a new record to the database.");
        Console.WriteLine("\tArgs (13)");
        Console.WriteLine("\tdata - (field:value array) data for new record");
        Console.WriteLine("\tex: ADD FirstName Austin LastName Hale WorkerType Employee EmploymentDate 04/05/2020 MonthlySalary 900.0 JobTitle Janitor");
        Console.WriteLine("\t If worker type = PreHire: last 2 fields are OfferExtendedDate (date here) and OfferAcceptedDate (date here)");
        Console.WriteLine("\t If worker type = Employee: last 2 fields are JobTitle (string here) and MonthlySalary (float here)");
        Console.WriteLine("\t If worker type = Retiree: last 2 fields are RetirementProgram (string here) and RetirementDate (date here)\n");
        Console.WriteLine("UPDATE [personID] [data] - Updates a record in the database.");
        Console.WriteLine("\tArgs (7)");
        Console.WriteLine("\tpersonID - (int) - The ID number of the person record to update");
        Console.WriteLine("\tdata - (field:value array) Everything from ADD but with ");
        Console.WriteLine("\tex: UPDATE 15 FirstName John LastName Doe EmploymentDate 05/02/2021\n");
        Console.WriteLine("DELETE [personID or *] - Deletes a record from the database.");
        Console.WriteLine("\tArgs (1)");
        Console.WriteLine("\tpersonID (int) - Deletes the record of the person with this ID");
        Console.WriteLine("\tor");
        Console.WriteLine("\t* - Deletes all person records in the DB");
        Console.WriteLine("\tex: DELETE 15 or DELETE *\n");
        Console.WriteLine("HELP - Displays command menu.\n");
        Console.WriteLine("QUIT - Exits the program.");
        Console.WriteLine("=================================================================================================================");
    }
}