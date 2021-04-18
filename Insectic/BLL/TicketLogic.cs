using System;
using System.Collections.Generic;
using System.Linq;
using Insectic.InsecticData;
using Insectic.Models;

namespace Insectic.BLL
{
    public static class TicketLogic
    {
        private static readonly ITicketRepository Repository = new TicketApiRepository();
        public static Tuple<int, int, int, int> CountTicketPriority()
        {
            var tickets = Repository.GetAllTicketsAsync()!.Result.ToList();

            var urgentTicketCount = 0;
            var highTicketCount = 0;
            var routineTicketCount = 0;
            var lowTicketCount = 0;

            
            
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
            

            return new Tuple<int, int, int, int>(urgentTicketCount, highTicketCount, routineTicketCount,
                lowTicketCount);
        }

        public static Tuple<int, int, int, int, int, int, int> CountTicketCategory()
        {
            var tickets = Repository.GetAllTicketsAsync()!.Result.ToList();

            var funcError = 0;
            var logicError = 0;
            var syntacticError = 0;
            var errorHandling = 0;
            var calcError = 0;
            var secDefect = 0;
            var patchError = 0;

            foreach (var t in tickets.Where(x => x.Status!.ToLower() != "closed"))
            {
                switch (t.Category!.ToLower())
                {
                    case "functionality error":
                        funcError++;
                        break;
                    case "logic error":
                        logicError++;
                        break;
                    case "syntactic error":
                        syntacticError++;
                        break;
                    case "error handling error":
                        errorHandling++;
                        break;
                    case "calculation error":
                        calcError++;
                        break;
                    case "patch error":
                        patchError++;
                        break;
                    case "security defect":
                        secDefect++;
                        break;
                }
            }

            return new Tuple<int, int, int, int, int, int, int>(funcError, logicError, syntacticError, errorHandling,
                calcError, secDefect, patchError);
        }

        public static Tuple<int, int, int, int, int,int> CountTicketStatus()
        {
            var tickets = Repository.GetAllTicketsAsync()!.Result.ToList();

            var awtgAssignment = 0;
            var inProgress = 0;
            var pendingReview = 0;
            var closed = 0;
            var assigned = 0;



            foreach (var t in tickets)
            {
                switch (t.Status!.ToLower())
                {

                    case "closed":
                        closed++;
                        break;
                    case "in progress":
                        inProgress++;
                        break;
                    case "awtg assignment":
                        awtgAssignment++;
                        break;
                    case "assigned":
                        assigned++;
                        break;
                    case "pending closure":
                        pendingReview++;
                        break;

                }
            }

            var openTickets = awtgAssignment + inProgress + pendingReview + closed + assigned;
            return new Tuple<int, int, int, int, int, int>(openTickets, awtgAssignment, inProgress, pendingReview, assigned,closed);
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
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.UserId);
            }
            if (sortBy == "IncidentDate")
            {
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.IncidentDate);
            }
            if (sortBy == "DueDate")
            {
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.DueDate);
            }
            if (sortBy == "Status")
            {
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.Status);
            }
            if (sortBy == "Category")
            {
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.Category);
            }
            if (sortBy == "Priority")
            {
                return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.Priority);
            }
           
            return Repository.GetAllTicketsAsync()!.Result.ToList().OrderBy(f => f.TicketId);
        }

        public static List<TicketJsonModel> GetPastDueTickets()
        {
            var list = Repository.GetAllTicketsAsync()!.Result.ToList();
            return list.Where(t => t.DueDate < DateTime.Now).ToList();
        }
    }

}

