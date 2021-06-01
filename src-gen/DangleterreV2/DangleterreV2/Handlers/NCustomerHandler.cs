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
    public interface INCustomerHandler
    {
        Task<Guid> CreateNCustomer(NCustomer model);
        Task<bool> DeleteNCustomer(Guid id);
        Task<List<NCustomer>> GetAll(int page, int pageSize);
        Task<NCustomer> Update(NCustomer model);
        Task<NCustomer> Get(Guid id);
    }
    
    public class NCustomerHandler : INCustomerHandler
    {
        private readonly INCustomerRepository _NCustomerRepository;

        public NCustomerHandler(INCustomerRepository NCustomerRepository
                             )
        {
            _NCustomerRepository = NCustomerRepository;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateNCustomer(NCustomer model)
		{
			return await _NCustomerRepository.Insert(model);
		}
		
		public async Task<bool> DeleteNCustomer(Guid id)
		{
			return await _NCustomerRepository.Delete(id);	
		}
		
		public async Task<List<NCustomer>> GetAll(int page, int pageSize)
		{
			var all = await _NCustomerRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<NCustomer>();
			var protectiveCopy = all.Select(e => map.Map<NCustomer, NCustomer>(e)).ToList();
			var finalResult = new List<NCustomer>();
			
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<NCustomer> Update(NCustomer model)
		{
			return await _NCustomerRepository.Put(model);
		}
		
		public async Task<NCustomer> Get(Guid id)
		{
			var result = await _NCustomerRepository.GetById(id);
			var map = CreateMapperConf<NCustomer>();
			var finalResult = map.Map<NCustomer, NCustomer>(result);
			return finalResult;	
		}
        
    }
}
