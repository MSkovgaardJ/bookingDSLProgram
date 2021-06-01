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
    [Route("NCustomer")]
    public class NCustomerController : ControllerBase
    {
        private readonly INCustomerHandler _NCustomerHandler;
        private readonly IMapper _mapper;

        public NCustomerController(INCustomerHandler NCustomerHandler, IMapper mapper)
        {
            _NCustomerHandler = NCustomerHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<NCustomer>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _NCustomerHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<NCustomer>> Get(Guid id)
        {
            var result = await _NCustomerHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateNCustomerRequestModel rm)
        {
        	
            var model = _mapper.Map<NCustomer>(rm);
            var result = await _NCustomerHandler.CreateNCustomer(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<NCustomer>> Put([FromBody] UpdateNCustomerRequestModel rm)
        {
        	
        	var model = _mapper.Map<NCustomer>(rm);
        	var result = await _NCustomerHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _NCustomerHandler.DeleteNCustomer(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
