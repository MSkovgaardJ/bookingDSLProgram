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
    public interface IVipCustomerHandler
    {
        Task<Guid> CreateVipCustomer(VipCustomer model);
        Task<bool> DeleteVipCustomer(Guid id);
        Task<List<VipCustomer>> GetAll(int page, int pageSize);
        Task<VipCustomer> Update(VipCustomer model);
        Task<VipCustomer> Get(Guid id);
    }
    
    public class VipCustomerHandler : IVipCustomerHandler
    {
        private readonly IVipCustomerRepository _VipCustomerRepository;

        public VipCustomerHandler(IVipCustomerRepository VipCustomerRepository
                             )
        {
            _VipCustomerRepository = VipCustomerRepository;
        }
        
        private IMapper CreateMapperConf<T>()
	        		{
	        			var config = new MapperConfiguration(cfg =>
	        			{
	        				cfg.CreateMap<T, T>();
	        			});
	        			return config.CreateMapper();
	        		}

		public async Task<Guid> CreateVipCustomer(VipCustomer model)
		{
			return await _VipCustomerRepository.Insert(model);
		}
		
		public async Task<bool> DeleteVipCustomer(Guid id)
		{
			return await _VipCustomerRepository.Delete(id);	
		}
		
		public async Task<List<VipCustomer>> GetAll(int page, int pageSize)
		{
			var all = await _VipCustomerRepository.GetPaged(page, pageSize);	
			var map = CreateMapperConf<VipCustomer>();
			var protectiveCopy = all.Select(e => map.Map<VipCustomer, VipCustomer>(e)).ToList();
			var finalResult = new List<VipCustomer>();
			
			
			if(finalResult.Count == 0) finalResult = protectiveCopy.ToList();
			return finalResult;
		}
		
		public async Task<VipCustomer> Update(VipCustomer model)
		{
			return await _VipCustomerRepository.Put(model);
		}
		
		public async Task<VipCustomer> Get(Guid id)
		{
			var result = await _VipCustomerRepository.GetById(id);
			var map = CreateMapperConf<VipCustomer>();
			var finalResult = map.Map<VipCustomer, VipCustomer>(result);
			return finalResult;	
		}
        
    }
}
