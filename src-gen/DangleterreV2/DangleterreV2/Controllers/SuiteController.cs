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
    [Route("Suite")]
    public class SuiteController : ControllerBase
    {
        private readonly ISuiteHandler _SuiteHandler;
        private readonly IMapper _mapper;

        public SuiteController(ISuiteHandler SuiteHandler, IMapper mapper)
        {
            _SuiteHandler = SuiteHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Suite>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _SuiteHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Suite>> Get(Guid id)
        {
            var result = await _SuiteHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateSuiteRequestModel rm)
        {
        	
            var model = _mapper.Map<Suite>(rm);
            var result = await _SuiteHandler.CreateSuite(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Suite>> Put([FromBody] UpdateSuiteRequestModel rm)
        {
        	
        	var model = _mapper.Map<Suite>(rm);
        	var result = await _SuiteHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _SuiteHandler.DeleteSuite(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
