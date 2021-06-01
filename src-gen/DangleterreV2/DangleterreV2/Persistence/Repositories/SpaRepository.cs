using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface ISpaRepository : IBaseRepository<Spa>
    {
    }
    
    public class SpaRepository : BaseRepository<Spa>, ISpaRepository
    {
        public SpaRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
