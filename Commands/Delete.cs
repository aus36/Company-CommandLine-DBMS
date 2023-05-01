namespace CSCI428_SQLProject.Commands;

internal class Delete : AppCommand
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
        DatabaseCommand.DELETE(ArgsObject!);
        Console.WriteLine("Delete successful.");
    }

    public override bool Validate(string[] args)
    {
        if (args.Length != 2 /* || (args[1] != "*" && args[1] != "check for ID stuff here") */ )
        {
            Console.WriteLine("Invalid arguments.");
            return false;
        }
        return true;
    }
}
