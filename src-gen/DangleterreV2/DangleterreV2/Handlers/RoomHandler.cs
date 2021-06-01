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
    public interface IRoomHandler
    {
        Task<Guid> CreateRoom(Room model);
        Task<bool> DeleteRoom(Guid id);
        Task<List<Room>> GetAll(int page, int pageSize);
        Task<Room> Update(Room model);
        Task<Room> Get(Guid id);
        Task<List<Room>> AddRoomScheduleToAllResources(List<RoomSchedule> collection);
    }
    
    public class RoomHandler : IRoomHandler
    {
        private readonly IRoomRepository _RoomRepository;
       IRoomScheduleHandler _RoomScheduleHandler;

        public RoomHandler(IRoomRepository RoomRepository
                             , IRoomScheduleHandler RoomScheduleHandler
                             )
        {
            _RoomRepository = RoomRepository;
            _RoomScheduleHandler = RoomScheduleHandler;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateRoom(Room model)
		{
			foreach(var sub in model.plan)
			{
				if (sub.Id.Equals(Guid.NewGuid())){
					sub.Id = new Guid();
					await _RoomScheduleHandler.CreateRoomSchedule(sub);
				}
			}
			return await _RoomRepository.Insert(model);
		}
		
		public async Task<bool> DeleteRoom(Guid id)
		{
			return await _RoomRepository.Delete(id);	
		}
		
		public async Task<List<Room>> GetAll(int page, int pageSize)
		{
			var all = await _RoomRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<Room>();
			var protectiveCopy = all.Select(e => map.Map<Room, Room>(e)).ToList();
			var finalResult = new List<Room>();
			
			foreach(var item in protectiveCopy) item.plan = new List<RoomSchedule>();
			foreach(var item in all)
			{
				var protectedSingle = protectiveCopy.ToList().Find(x => x.Id.Equals(item.Id));
				foreach(var single in item.plan)
				{
					var res = await _RoomScheduleHandler.Get(single.Id);
					if (res != null) protectedSingle.plan.Add(res);
				}
				finalResult.Add(protectedSingle);
			}
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<Room> Update(Room model)
		{
			foreach(var single in model.plan) if(single != null) await _RoomScheduleHandler.Update(single);
			return await _RoomRepository.Put(model);
		}
		
		public async Task<Room> Get(Guid id)
		{
			var result = await _RoomRepository.GetById(id);
			var map = CreateMapperConf<Room>();
			var finalResult = map.Map<Room, Room>(result);
			if(result.plan != null)
			{
				var list = new List<RoomSchedule>();
				foreach(var item in result.plan)
				{
					var res = await _RoomScheduleHandler.Get(item.Id);
					if (res != null) list.Add(res);
				}
				finalResult.plan = list;
			}
			return finalResult;	
		}
        
        public async Task<List<Room>> AddRoomScheduleToAllResources(List<RoomSchedule> collection)
        {
        	var all = await GetAll(0, 1000);
        	
        	foreach(var res in all)
        	{
        		res.plan.AddRange(collection);
        		await this.Update(res);
        	}
        	
        	return all.ToList();
        }
    }
}
