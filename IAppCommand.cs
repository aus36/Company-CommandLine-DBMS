namespace CSCI428_SQLProject;

internal interface IAppCommand
{
    public void Initialize(string[] args);
    public void Execute();
}