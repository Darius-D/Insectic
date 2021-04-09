using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.InsecticData;
using Insectic.Models;

namespace Insectic.BLL
{
    public static class TicketLogic
    {

        public static Tuple<int, int, int, int> CountTicketCategory()
        {
            var tickets = TicketApiRepository.GetAllTickets();

            var urgentTicketCount = 0;
            var highTicketCount = 0;
            var routineTicketCount = 0;
            var lowTicketCount = 0;

            if (tickets != null)
            {
                foreach (var t in tickets.Where(x => x.Status!.ToLower() != "closed"))
                {

                    switch (t.Priority!.ToLower())
                    {
                        case "urgent":
                            urgentTicketCount++;
                            break;
                        case "high":
                            highTicketCount++;
                            break;
                        case "routine":
                            routineTicketCount++;
                            break;
                        case "low":
                            lowTicketCount++;
                            break;
                    }
                }
            }

            return new Tuple<int, int, int, int>(urgentTicketCount, highTicketCount, routineTicketCount, lowTicketCount);
        }


        public static string TruncateAtWord(TicketJsonModel ticket, int charLength = 20)
        {
            if (ticket.TicketDescription!.Length < charLength) 
                return ticket.TicketDescription;
            var nextSpace = ticket.TicketDescription.LastIndexOf(" ", charLength, StringComparison.Ordinal);
            return $"{ticket.TicketDescription.Substring(0, (nextSpace > 0) ? nextSpace : charLength).Trim()}…";
        }

        public static IEnumerable<TicketJsonModel> FilterCollection(string sortBy)
        {
            if (sortBy == "UserId")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.UserId);
            }
            if (sortBy == "IncidentDate")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.IncidentDate);
            }
            if (sortBy == "DueDate")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.DueDate);
            }
            if (sortBy == "Status")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.Status);
            }
            if (sortBy == "Category")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.Category);
            }
            if (sortBy == "Priority")
            {
                return TicketApiRepository.GetAllTickets().OrderBy(f => f.Priority);
            }
           
            return TicketApiRepository.GetAllTickets().OrderBy(f => f.TicketId);
        }

    }

}

