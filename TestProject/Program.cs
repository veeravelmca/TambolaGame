using System.Net.Sockets;
using TestProject.Model;
using TestProject.Service;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new TicketModel();
            var claimService = new ClaimManager();

            // Example input
            ticket.Crossed[0, 0] = true;
            ticket.Crossed[0, 1] = true;
            ticket.Crossed[0, 2] = true;
            ticket.Crossed[0, 3] = true;
            ticket.Crossed[0, 4] = true;

            Console.WriteLine("Enter the game type (Top line, Middle line, Bottom line, Full house, Early five):");
            string gameType = Console.ReadLine();

            bool isValid = claimService.ValidateClaim(ticket, gameType);
            Console.WriteLine(isValid ? "Accepted" : "Rejected");
        }
    }
}
