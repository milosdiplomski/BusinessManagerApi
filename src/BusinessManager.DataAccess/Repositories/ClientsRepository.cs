using BusinessManager.DataAccess.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data;
using BusinessManagerApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManager.DataAccess.Repositories
{
    public class ClientsRepository : GenericRepository<Clients>, IClientsRepository
    {
        public ClientsRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}
