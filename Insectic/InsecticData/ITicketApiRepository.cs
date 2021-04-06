using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.Models;

namespace Insectic.InsecticData
{
    interface ITicketApiRepository
    {

        List<TicketJsonModel> GetAllTickets();
        TicketJsonModel GetTicket(string guid);
        void AddTicket(TicketJsonModel ticket);
        void EditTicket();
        void DeleteTicket();

    }
}
