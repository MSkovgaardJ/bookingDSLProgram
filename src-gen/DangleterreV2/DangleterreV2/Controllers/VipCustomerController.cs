using System;
using System.Threading.Tasks;
using DangleterreV2.Handlers;
using DangleterreV2.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using DangleterreV2.Persistence.Models;

namespace DangleterreV2.Controllers
{
    [Route("VipCustomer")]
    public class VipCustomerController : ControllerBase
    {
        private readonly IVipCustomerHandler _VipCustomerHandler;
        private readonly IMapper _mapper;

        public VipCustomerController(IVipCustomerHandler VipCustomerHandler, IMapper mapper)
        {
            _VipCustomerHandler = VipCustomerHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<VipCustomer>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _VipCustomerHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VipCustomer>> Get(Guid id)
        {
            var result = await _VipCustomerHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateVipCustomerRequestModel rm)
        {
        	if(!(rm.vip )) 
        		return BadRequest("Operation failed due to request failing the following constraint: " + 
        								"rm.vip ");
        	if(!(rm.points < 20 )) 
        		return BadRequest("Operation failed due to request failing the following constraint: " + 
        								"rm.points < 20 ");
        	
            var model = _mapper.Map<VipCustomer>(rm);
            var result = await _VipCustomerHandler.CreateVipCustomer(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<VipCustomer>> Put([FromBody] UpdateVipCustomerRequestModel rm)
        {
        	if(!(rm.vip )) 
        		return BadRequest("Operation failed due to request failing the following constraint: " + 
        								"rm.vip ");
        	if(!(rm.points < 20 )) 
        		return BadRequest("Operation failed due to request failing the following constraint: " + 
        								"rm.points < 20 ");
        	
        	var model = _mapper.Map<VipCustomer>(rm);
        	var result = await _VipCustomerHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _VipCustomerHandler.DeleteVipCustomer(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
