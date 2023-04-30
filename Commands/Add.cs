﻿namespace CSCI428_SQLProject.Commands;

internal class Add : AppCommand
{
    //Methods
    public override void Initialize(string[] args)
    {
        Args = args;
    }
    public override void Execute()
    {
        if (!Validate(Args!))
        {
            return;
        }
        DatabaseCommand.ADD(Args!);
        Console.WriteLine("Add successful.");
    }

    public override bool Validate(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Invalid number of arguments.");
            return false;
        }
        return true;
    }
}
