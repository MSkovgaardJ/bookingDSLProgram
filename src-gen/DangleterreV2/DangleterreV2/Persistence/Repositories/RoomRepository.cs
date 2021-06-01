using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
    }
    
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
