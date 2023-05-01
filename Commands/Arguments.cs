//Class to keep track of arguments for a command, the Databasecommand is passed this object

namespace CSCI428_SQLProject.Commands;

internal class Arguments
{
    //Properties
    public string CommandType { get; set; }

    public string? Type { get; set; }

    public int? Page { get; set; }

    public int? Count { get; set; }

    public string? Orderby { get; set; }

    public string? Direction { get; set; }

    public Dictionary<String, String>? Data { get; set; }

    public int? PersonId { get; set; }

    public bool Asterisk { get; set; } = false;

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
                string[] str = args[1..];
                Data = new Dictionary<string, string>();
                for (int i = 0; i < str.Length; i += 2)
                {
                    if(i + 1 < str.Length)
                    {
                        Data.Add(str[i], str[i + 1]);
                    }
                }
                ; break;

            case "UPDATE":
                PersonId = Int32.Parse(args[1]);
                string[] str2 = args[2..];
                Data = new Dictionary<string, string>();
                for (int i = 0; i < str2.Length; i += 2)
                {
                    if (i + 1 < str2.Length)
                    {
                        Data.Add(str2[i], str2[i + 1]);
                    }
                }
                ; break;

            case "DELETE":
                if(args.Length != 2)
                {
                    break;
                }
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

    //Methods
    public override string ToString() //Just for testing purposes
    {
        switch (CommandType)
        {
            default: //Should never be triggered due to validation in AppController, just here for convention
                return "Invalid command type";
            case "LIST":
                return $"Type: {Type}\nPage: {Page}\nCount: {Count}\nOrderby: {Orderby}\nDirection: {Direction}";
            case "ADD":
                return $"Data: {Data}";
            case "UPDATE":
                return $"PersonId: {PersonId}\nData: {Data}";
            case "DELETE":
                return $"PersonId: {PersonId}\nAsterisk: {Asterisk}";
        }
    }
}