using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface IVipCustomerRepository : IBaseRepository<VipCustomer>
    {
    }
    
    public class VipCustomerRepository : BaseRepository<VipCustomer>, IVipCustomerRepository
    {
        public VipCustomerRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
