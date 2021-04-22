using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Extensions;
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

        public static Tuple<int, int, int, int, int, int, int> GetTicketsCreatedByWeekday()
        {
            var date = DateTime.Now.Date;
            var ticketList = Repository.GetAllTicketsAsync();
            var i = date.DayOfWeek;
            var test = (int)i;
            var beginningOfWeek = date.Subtract(TimeSpan.FromDays(test));
            var endOfWeek = beginningOfWeek.AddDays(6);

            var thisWeeksList =ticketList.Result.Where(c => c.IncidentDate.Date >= beginningOfWeek && c.IncidentDate.Date <= endOfWeek);
            

            var sunday = 0;
            var monday = 0;
            var tuesday = 0;
            var wednesday = 0;
            var thursday = 0;
            var friday = 0;
            var saturday = 0;

            foreach (var ticket in thisWeeksList)
            {

                switch (ticket.IncidentDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        sunday++;
                        break;
                    case DayOfWeek.Monday:
                        monday++;
                        break;
                    case DayOfWeek.Tuesday:
                        tuesday++;
                        break;
                    case DayOfWeek.Wednesday:
                        wednesday++;
                        break;
                    case DayOfWeek.Thursday:
                        thursday++;
                        break;
                    case DayOfWeek.Friday:
                        friday++;
                        break;
                    case DayOfWeek.Saturday:
                        saturday++;
                        break;
                }

            }



            return new Tuple<int, int, int, int, int, int, int>(sunday, monday, tuesday, wednesday, thursday, friday, saturday);
        }

        //todo: Create time log for when tickets are closed. 
        public static Tuple<int, int, int, int, int, int, int> GetTicketsClosedByWeekday()
        {
            var date = DateTime.Now.Date;
            var ticketList = Repository.GetAllTicketsAsync();
            var i = date.DayOfWeek;
            var test = (int)i;
            var beginningOfWeek = date.Subtract(TimeSpan.FromDays(test));
            var endOfWeek = beginningOfWeek.AddDays(6);

            var thisWeeksList = ticketList.Result.Where(c => c.IncidentDate.Date >= beginningOfWeek && c.IncidentDate.Date <= endOfWeek && c.Status.Equals("Closed"));


            var sunday = 0;
            var monday = 0;
            var tuesday = 0;
            var wednesday = 0;
            var thursday = 0;
            var friday = 0;
            var saturday = 0;

            foreach (var ticket in thisWeeksList)
            {

                switch (ticket.IncidentDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        sunday++;
                        break;
                    case DayOfWeek.Monday:
                        monday++;
                        break;
                    case DayOfWeek.Tuesday:
                        tuesday++;
                        break;
                    case DayOfWeek.Wednesday:
                        wednesday++;
                        break;
                    case DayOfWeek.Thursday:
                        thursday++;
                        break;
                    case DayOfWeek.Friday:
                        friday++;
                        break;
                    case DayOfWeek.Saturday:
                        saturday++;
                        break;
                }

            }

            
            return new Tuple<int, int, int, int, int, int, int>(sunday, monday, tuesday, wednesday, thursday, friday, saturday);
        }
    }

}

