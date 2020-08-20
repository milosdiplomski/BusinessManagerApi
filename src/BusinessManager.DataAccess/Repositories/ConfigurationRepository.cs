using BusinessManager.DataAccess.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data;
using BusinessManagerApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManager.DataAccess.Repositories
{
    public class ConfigurationRepository : GenericRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}
