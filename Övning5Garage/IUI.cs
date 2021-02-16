namespace Övning5Garage
{
    public interface IUI
    {
        int AskForInt(string prompt);
        string AskForString(string prompt);
        string GetInput();
        void Print(string message);
    }
}