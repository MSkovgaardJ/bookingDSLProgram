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
    public interface ISpaHandler
    {
        Task<Guid> CreateSpa(Spa model);
        Task<bool> DeleteSpa(Guid id);
        Task<List<Spa>> GetAll(int page, int pageSize);
        Task<Spa> Update(Spa model);
        Task<Spa> Get(Guid id);
    }
    
    public class SpaHandler : ISpaHandler
    {
        private readonly ISpaRepository _SpaRepository;

        public SpaHandler(ISpaRepository SpaRepository
                             )
        {
            _SpaRepository = SpaRepository;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateSpa(Spa model)
		{
			return await _SpaRepository.Insert(model);
		}
		
		public async Task<bool> DeleteSpa(Guid id)
		{
			return await _SpaRepository.Delete(id);	
		}
		
		public async Task<List<Spa>> GetAll(int page, int pageSize)
		{
			var all = await _SpaRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<Spa>();
			var protectiveCopy = all.Select(e => map.Map<Spa, Spa>(e)).ToList();
			var finalResult = new List<Spa>();
			
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<Spa> Update(Spa model)
		{
			return await _SpaRepository.Put(model);
		}
		
		public async Task<Spa> Get(Guid id)
		{
			var result = await _SpaRepository.GetById(id);
			var map = CreateMapperConf<Spa>();
			var finalResult = map.Map<Spa, Spa>(result);
			return finalResult;	
		}
        
    }
}
