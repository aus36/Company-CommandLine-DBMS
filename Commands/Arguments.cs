//Class to keep track of arguments for a command, the Databasecommand is passed this object

namespace CSCI428_SQLProject.Commands;

internal class Arguments
{
    //Properties
    public string? CommandType { get; set; }

    public string? Type { get; set; }

    public int? Page { get; set; }

    public int? Count { get; set; }

    public string? Orderby { get; set; }

    public string? Direction { get; set; }

    public string[]? Data { get; set; }

    public int? PersonId { get; set; }

    public bool? Asterisk { get; set; } = false;

    //Default Constructor
    public Arguments(string[] args)
    {
        CommandType = args[0]; //Finds out what command is being executed

        switch (CommandType) //Initializes arg values based on command type
        {
            default: //If not valid command, break (Should never happen due to validation in AppController)
                break;

            case "LIST":
                Type = args[1];
                Page = Int32.Parse(args[2]);
                Count = Int32.Parse(args[3]);
                Orderby = args[4];
                Direction = args[5];
                ; break;

            case "ADD":
                Data = args[1..];
                ; break;

            case "UPDATE":
                PersonId = Int32.Parse(args[1]);
                Data = args[2..];
                ; break;

            case "DELETE":
                if (args[1] == "*")
                {
                    Asterisk = true;
                }
                else
                {
                    PersonId = Int32.Parse(args[1]);
                }
                break;

        }
    }
}