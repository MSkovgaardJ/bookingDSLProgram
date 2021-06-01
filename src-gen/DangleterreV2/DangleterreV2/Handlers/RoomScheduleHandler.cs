using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DangleterreV2.Persistence.Repositories;
using DangleterreV2.Persistence.Models;
using DangleterreV2.RequestModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DangleterreV2.Handlers
{
    public interface IRoomScheduleHandler
    {
        Task<Guid> CreateRoomSchedule(RoomSchedule model);
        Task<bool> DeleteRoomSchedule(Guid id);
        Task<List<RoomSchedule>> GetAll(int page, int pageSize);
        Task<RoomSchedule> Update(RoomSchedule model);
        Task<RoomSchedule> Get(Guid id);
    }
    
    public class RoomScheduleHandler : IRoomScheduleHandler
    {
        private readonly IRoomScheduleRepository _RoomScheduleRepository;

        public RoomScheduleHandler(IRoomScheduleRepository RoomScheduleRepository
                             )
        {
            _RoomScheduleRepository = RoomScheduleRepository;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateRoomSchedule(RoomSchedule model)
		{
			return await _RoomScheduleRepository.Insert(model);
		}
		
		public async Task<bool> DeleteRoomSchedule(Guid id)
		{
			return await _RoomScheduleRepository.Delete(id);	
		}
		
		public async Task<List<RoomSchedule>> GetAll(int page, int pageSize)
		{
			var all = await _RoomScheduleRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<RoomSchedule>();
			var protectiveCopy = all.Select(e => map.Map<RoomSchedule, RoomSchedule>(e)).ToList();
			var finalResult = new List<RoomSchedule>();
			
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<RoomSchedule> Update(RoomSchedule model)
		{
			return await _RoomScheduleRepository.Put(model);
		}
		
		public async Task<RoomSchedule> Get(Guid id)
		{
			var result = await _RoomScheduleRepository.GetById(id);
			var map = CreateMapperConf<RoomSchedule>();
			var finalResult = map.Map<RoomSchedule, RoomSchedule>(result);
			return finalResult;	
		}
        
    }
}
