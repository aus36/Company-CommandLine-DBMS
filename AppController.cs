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
		while (!this.IsDone)
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
                }

			//Parse and execute command from input
			this.IsDone = true; //DUETO: remove this later when commands are done
		}
	}

	public static bool ValidateInput(string input) //Checks to see if entered string is valid input
	{
		switch (input.Split(" ")[0])
		{
			default: 
				return false;

			case ("LIST"):
				return true;

            case ("ADD"):
                return true;

            case ("UPDATE"):
                return true;

            case ("DELETE"):
                return true;
        }
	}
}