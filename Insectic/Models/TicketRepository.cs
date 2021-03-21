using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class TicketRepository
    {
        private static List<TicketForm> tickets = new List<TicketForm>();

        public static IEnumerable<TicketForm> Tickets => tickets;

        public static void AddTicket(TicketForm ticket)
        {
            tickets.Add(ticket);
        }

        public static Tuple<int,int,int,int> CountTicketCategory(IEnumerable<TicketForm> tic)
        {
            var urgentCount = 0;
            var highCount = 0;
            var routineCount = 0;
            var lowCount = 0;

            foreach (var t in tic)
            {

                switch (t.Priority)
                {
                    case 1:
                        urgentCount++;
                        break;
                    case 2:
                        highCount++;
                        break;
                    case 3:
                        routineCount++;
                        break;
                    case 4:
                        lowCount++;
                        break;
                }
            }
            return new Tuple<int, int, int, int>(urgentCount,highCount,routineCount,lowCount);
        }
        public static string TruncateAtWord(TicketForm ticket, int length)
        {
            if ( ticket.TicketDescription.Length < length)
                return ticket.TicketDescription;
            var nextSpace = ticket.TicketDescription.LastIndexOf(" ", length, StringComparison.Ordinal);
            return $"{ticket.TicketDescription.Substring(0, (nextSpace > 0) ? nextSpace : length).Trim()}…";
        }
    }
}
