using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface ISuiteRepository : IBaseRepository<Suite>
    {
    }
    
    public class SuiteRepository : BaseRepository<Suite>, ISuiteRepository
    {
        public SuiteRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
