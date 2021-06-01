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
    public interface ISuiteHandler
    {
        Task<Guid> CreateSuite(Suite model);
        Task<bool> DeleteSuite(Guid id);
        Task<List<Suite>> GetAll(int page, int pageSize);
        Task<Suite> Update(Suite model);
        Task<Suite> Get(Guid id);
    }
    
    public class SuiteHandler : ISuiteHandler
    {
        private readonly ISuiteRepository _SuiteRepository;

        public SuiteHandler(ISuiteRepository SuiteRepository
                             )
        {
            _SuiteRepository = SuiteRepository;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateSuite(Suite model)
		{
			return await _SuiteRepository.Insert(model);
		}
		
		public async Task<bool> DeleteSuite(Guid id)
		{
			return await _SuiteRepository.Delete(id);	
		}
		
		public async Task<List<Suite>> GetAll(int page, int pageSize)
		{
			var all = await _SuiteRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<Suite>();
			var protectiveCopy = all.Select(e => map.Map<Suite, Suite>(e)).ToList();
			var finalResult = new List<Suite>();
			
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<Suite> Update(Suite model)
		{
			return await _SuiteRepository.Put(model);
		}
		
		public async Task<Suite> Get(Guid id)
		{
			var result = await _SuiteRepository.GetById(id);
			var map = CreateMapperConf<Suite>();
			var finalResult = map.Map<Suite, Suite>(result);
			return finalResult;	
		}
        
    }
}
