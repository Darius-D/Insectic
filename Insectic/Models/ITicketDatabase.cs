using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    interface ITicketDatabase
    {
        Task<List<TicketModel>> GetTickets();

        Task GetTicket();




    }
}
