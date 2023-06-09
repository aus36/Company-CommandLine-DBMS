﻿namespace CSCI428_SQLProject.Commands;

internal class Add : AppCommand
{
    //Properties
    public Dictionary<String, String>? Data { get; set; }

    //Methods
    public override void Initialize(string[] args)
    {
        Args = args;
        ArgsObject = new Arguments(args);
    }
    public override void Execute()
    {
        if (!Validate(Args!))
        {
            return;
        }
        DatabaseCommand.ADD(ArgsObject!);
        Console.WriteLine("Add successful.");
    }

    public override bool Validate(string[] args)
    {
        if (args.Length != 13)
        {
            Console.WriteLine("Invalid number of arguments.");
            return false;
        }
        return true;
    }
}
