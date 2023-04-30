namespace CSCI428_SQLProject
{
    internal abstract class AppCommand : IAppCommand //Base class for all commands, has methods for initializing and executing commands
    {
        //Properties
        public string[]? Args { get; set; }

        //Methods
        public abstract void Initialize(string[] args);
        public abstract void Execute();
    }
}
