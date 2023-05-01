namespace CSCI428_SQLProject.Commands;

internal class Update : AppCommand
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
        DatabaseCommand.UPDATE(ArgsObject!);
        Console.WriteLine("Update successful.");
    }

    public override bool Validate(string[] args)
    {
        //Already handled by AppController, redundant function no longer needed
        return true;
    }
}
