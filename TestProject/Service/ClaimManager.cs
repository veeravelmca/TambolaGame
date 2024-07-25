using System.Globalization;
using TestProject.Model;

namespace TestProject.Service
{
    public class ClaimManager
    {
        public bool ValidateClaim(TicketModel ticketModel, string gameType)
        {
            return gameType.Replace(" ", "").ToLower(CultureInfo.InvariantCulture) switch
            {
                "topline" => IsLineCrossed(ticketModel, 0),
                "middleline" => IsLineCrossed(ticketModel, 1),
                "bottomline" => IsLineCrossed(ticketModel, 2),
                "fullhouse" => IsFullHouse(ticketModel),
                "earlyfive" => IsEarlyFive(ticketModel),
                _ => false,
            };
        }

        private static bool IsLineCrossed(TicketModel ticket, int line)
        {
            return Enumerable.Range(0, 5).All(i => ticket.Crossed[line, i]);
        }

        private static bool IsFullHouse(TicketModel ticket)
        {
            bool allCrossed = Enumerable.Range(0, 3)
                .SelectMany(i => Enumerable.Range(0, 5).Select(j => ticket.Crossed[i, j]))
                .All(crossed => crossed);

            return allCrossed;
        }

        private static bool IsEarlyFive(TicketModel ticket)
        {
            return Enumerable.Range(0, 3)
                .SelectMany(i => Enumerable.Range(0, 5).Where(j => ticket.Crossed[i, j]))
                .Take(5)
                .Count() >= 5;
        }
    }
}


