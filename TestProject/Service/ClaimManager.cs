using TestProject.Model;

namespace TestProject.Service
{
    public class ClaimManager
    {
        public bool ValidateClaim(TicketModel ticketModel, string gameType)
        {
            switch (gameType)
            {
                case "Top line":
                    return IsLineCrossed(ticketModel, 0);
                case "Middle line":
                    return IsLineCrossed(ticketModel, 1);
                case "Bottom line":
                    return IsLineCrossed(ticketModel, 2);
                case "Full house":
                    return IsFullHouse(ticketModel);
                case "Early five":
                    return IsEarlyFive(ticketModel);
                default:
                    return false;
            }
        }

        private bool IsLineCrossed(TicketModel ticket, int line)
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


