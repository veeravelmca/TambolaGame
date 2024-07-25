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
            for (int i = 0; i < 5; i++)
            {
                if (!ticket.Crossed[line, i])
                    return false;
            }
            return true;
        }

        private bool IsFullHouse(TicketModel ticket)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!ticket.Crossed[i, j])
                        return false;
                }
            }
            return true;
        }

        private bool IsEarlyFive(TicketModel ticket)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ticket.Crossed[i, j])
                        count++;
                    if (count >= 5)
                        return true;
                }
            }
            return false;
        }
    }
}


