using System;
using DangleterreV2.Configuration;
using DangleterreV2.Persistence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DangleterreV2.Persistence.Repositories
{
    public interface IRoomScheduleRepository : IBaseRepository<RoomSchedule>
    {
    }
    
    public class RoomScheduleRepository : BaseRepository<RoomSchedule>, IRoomScheduleRepository
    {
        public RoomScheduleRepository(IMongoClient client, IOptions<PersistenceConfiguration> config) : base(client, config)
        {
        }
    }
}
