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
    public interface IRoomBookHandler
    {
        Task<Guid> CreateRoomBook(RoomBook model);
        Task<bool> DeleteRoomBook(Guid id);
        Task<List<RoomBook>> GetAll(int page, int pageSize);
        Task<RoomBook> Update(RoomBook model);
        Task<RoomBook> Get(Guid id);
    }
    
    public class RoomBookHandler : IRoomBookHandler
    {
        private readonly IRoomBookRepository _RoomBookRepository;
       IRoomHandler _RoomHandler;
       IRoomScheduleHandler _RoomScheduleHandler;
       INCustomerHandler _NCustomerHandler;

        public RoomBookHandler(IRoomBookRepository RoomBookRepository
                             , IRoomHandler RoomHandler
                             , IRoomScheduleHandler RoomScheduleHandler
                             , INCustomerHandler NCustomerHandler
                             )
        {
            _RoomBookRepository = RoomBookRepository;
            _RoomHandler = RoomHandler;
            _RoomScheduleHandler = RoomScheduleHandler;
            _NCustomerHandler = NCustomerHandler;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateRoomBook(RoomBook model)
		{
			if(model.Room.Id.Equals(Guid.NewGuid())){
			      model.Room.Id = new Guid();
			      await _RoomHandler.CreateRoom(model.Room);
			   }
			if(model.plan.Id.Equals(Guid.NewGuid())){
			      model.plan.Id = new Guid();
			      await _RoomScheduleHandler.CreateRoomSchedule(model.plan);
			   }
			if(model.cus.Id.Equals(Guid.NewGuid())){
			      model.cus.Id = new Guid();
			      await _NCustomerHandler.CreateNCustomer(model.cus);
			   }
			return await _RoomBookRepository.Insert(model);
		}
		
		public async Task<bool> DeleteRoomBook(Guid id)
		{
			return await _RoomBookRepository.Delete(id);	
		}
		
		public async Task<List<RoomBook>> GetAll(int page, int pageSize)
		{
			var all = await _RoomBookRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<RoomBook>();
			var protectiveCopy = all.Select(e => map.Map<RoomBook, RoomBook>(e)).ToList();
			var finalResult = new List<RoomBook>();
			
			foreach (var item in protectiveCopy) item.Room = await _RoomHandler.Get(item.Room.Id);
			foreach (var item in protectiveCopy) item.plan = await _RoomScheduleHandler.Get(item.plan.Id);
			foreach (var item in protectiveCopy) item.cus = await _NCustomerHandler.Get(item.cus.Id);
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<RoomBook> Update(RoomBook model)
		{
			if(model.Room != null) await _RoomHandler.Update(model.Room);
			if(model.plan != null) await _RoomScheduleHandler.Update(model.plan);
			if(model.cus != null) await _NCustomerHandler.Update(model.cus);
			return await _RoomBookRepository.Put(model);
		}
		
		public async Task<RoomBook> Get(Guid id)
		{
			var result = await _RoomBookRepository.GetById(id);
			var map = CreateMapperConf<RoomBook>();
			var finalResult = map.Map<RoomBook, RoomBook>(result);
			if(finalResult.Room != null) finalResult.Room = await _RoomHandler.Get(finalResult.Room.Id);
			if(finalResult.plan != null) finalResult.plan = await _RoomScheduleHandler.Get(finalResult.plan.Id);
			if(finalResult.cus != null) finalResult.cus = await _NCustomerHandler.Get(finalResult.cus.Id);
			return finalResult;	
		}
        
    }
}
