using TestProject.Model;
using TestProject.Service;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'exit' to close the Game.");

            while (true)
            {
                var ticket = new TicketModel();
                ticket.Crossed[0, 0] = true;
                ticket.Crossed[0, 1] = true;
                ticket.Crossed[0, 2] = true;
                ticket.Crossed[0, 3] = true;
                ticket.Crossed[0, 4] = true;

                Console.WriteLine("Enter the game type (Top line, Middle line, Bottom line, Full house, Early five):");
                string gameType = Console.ReadLine();

                if (gameType.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting the Game...");
                    Environment.Exit(0);
                }
                bool isValid = ClaimManager.ValidateClaim(ticket, gameType);
                Console.WriteLine(isValid ? "Accepted" : "Rejected");
            }
        }
    }
}
