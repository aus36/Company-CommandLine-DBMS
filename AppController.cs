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
        bool done = false;
        Console.WriteLine("Welcome to the Fuck You industries DBMS portal!");
		Console.WriteLine("===============================================\n");
		while (true)
		{
			//Take input and retry until valid input
			bool validInput = false;
			while (!validInput)
			{
				Console.WriteLine("Enter a command: ");
                input = Console.ReadLine()!;
                validInput = ValidateInput(input);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please try again or enter HELP to see the available commands.");
                }
                else //Parse and execute command from input
                {
                    done = HandleInput(input);
					break;
                }
            }
            if (done)
            {
                break;
            }
        }
		Console.WriteLine("\nThank you for using our system! Have a great day.");
	}

	public static bool ValidateInput(string input) //Checks to see if entered string is valid input
	{
        return input.Split(" ")[0] switch
        {
            ("LIST") => true,
            ("ADD") => true,
            ("UPDATE") => true,
            ("DELETE") => true,
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

			case "QUIT":
				return true;
        }
    }
}