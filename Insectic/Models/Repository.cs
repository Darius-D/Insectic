using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class Repository
    {
        private static List<TicketForm> tickets = new List<TicketForm>();

        public static IEnumerable<TicketForm> Tickets => tickets;

        public static void AddTicket(TicketForm ticket)
        {
            tickets.Add(ticket);
        }

        public static Tuple<int,int,int,int> CountTicketCategory(IEnumerable<TicketForm> tickets)
        {
            var urgentCount = 0;
            var highCount = 0;
            var routineCount = 0;
            var lowCount = 0;

            foreach (var t in tickets)
            {

                if (t.Priority == 1) urgentCount++;

                if (t.Priority==2) highCount++;

                if (t.Priority == 3) routineCount++;

                if (t.Priority == 4) lowCount++;
            }
            return new Tuple<int, int, int, int>(urgentCount,highCount,routineCount,lowCount);
        }

    }
}
