namespace CSCI428_SQLProject.Commands;

internal class Update : AppCommand
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
        DatabaseCommand.UPDATE(Args!);
        Console.WriteLine("Update successful.");
    }

    public override bool Validate(string[] args)
    {
        if (true /*validation logic here*/)
        {
            Console.WriteLine("Invalid arguments.");
            return false;
        }
        return true;
    }
}
