namespace CSCI428_SQLProject.Commands;

internal class List : AppCommand
{
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
        DatabaseCommand.LIST(ArgsObject!);
        Console.WriteLine("List successful.");
    }

    public override bool Validate(string[] args)
    {
        if (args.Length != 6)
        {
            Console.WriteLine("Invalid number of arguments.");
            return false;
        }
        return true;
    }
}
