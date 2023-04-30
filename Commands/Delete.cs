namespace CSCI428_SQLProject.Commands;

internal class Delete : AppCommand
{
    //Methods
    public override void Initialize(string[] args)
    {
       this.Args = args;
    }
    public override void Execute()
    {
        Console.WriteLine("Do stuff with args here");
    }
}
