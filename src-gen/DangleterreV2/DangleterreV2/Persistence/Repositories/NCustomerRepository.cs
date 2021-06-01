using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface INCustomerRepository : IBaseRepository<NCustomer>
    {
    }
    
    public class NCustomerRepository : BaseRepository<NCustomer>, INCustomerRepository
    {
        public NCustomerRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
