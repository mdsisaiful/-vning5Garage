using System;

namespace Övning5Garage
{
    public class UI : IUI
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Print(prompt);
                answer = GetInput();
                if (String.IsNullOrWhiteSpace(answer))
                {
                    Print("Invalid input!");
                }
                else
                {
                    success = true;
                }
            } while (!success);

            return answer;
        }


        public int AskForInt(string prompt)
        {
            bool success = false;
            int answer;

            do
            {
                string input = AskForString(prompt);
                success = int.TryParse(input, out answer);
                if (!success)
                {
                    Print("Only number inputs are allowed!");
                }

            } while (!success);

            return answer;
        }


    }
}