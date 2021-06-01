using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface IRoomBookRepository : IBaseRepository<RoomBook>
    {
    }
    
    public class RoomBookRepository : BaseRepository<RoomBook>, IRoomBookRepository
    {
        public RoomBookRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
