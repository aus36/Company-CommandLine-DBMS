namespace CSCI428_SQLProject
{
    internal abstract class AppCommand : IAppCommand //Base class for all commands, has methods for initializing and executing commands
    {
        //Properties
        public string[]? Args { get; set; }

        //Methods
        public abstract void Initialize(string[] args); //Initializes command with arguments

        public abstract void Execute(); //Executes command

        public abstract void Validate(); //Validates input to ensure args are correct
    }
}
