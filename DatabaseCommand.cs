//Contains all calls to the database for each command, these are run when a command is executed

using CSCI428_SQLProject.Commands;
using Microsoft.EntityFrameworkCore;

namespace CSCI428_SQLProject;

internal class DatabaseCommand //Class for handling actual interaction with database for each command
{
    public static void LIST(Arguments args)
    {
        Console.WriteLine("LISTING... (This isn't implemented yet so just pretend its doing something)");
    }

    public static void ADD(Arguments args)
    {
        Console.WriteLine("ADDING... (This isn't implemented yet so just pretend its doing something)");
    }

    public static void UPDATE(Arguments args)
    {
        Console.WriteLine("UPDATING... (This isn't implemented yet so just pretend its doing something)");
    }

    public static void DELETE(Arguments args)
    {
        Console.WriteLine("DELETING... (This isn't implemented yet so just pretend its doing something)");
    }
}