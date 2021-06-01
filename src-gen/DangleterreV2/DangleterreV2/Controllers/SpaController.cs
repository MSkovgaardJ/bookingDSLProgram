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
    [Route("Spa")]
    public class SpaController : ControllerBase
    {
        private readonly ISpaHandler _SpaHandler;
        private readonly IMapper _mapper;

        public SpaController(ISpaHandler SpaHandler, IMapper mapper)
        {
            _SpaHandler = SpaHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Spa>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _SpaHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Spa>> Get(Guid id)
        {
            var result = await _SpaHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateSpaRequestModel rm)
        {
        	
            var model = _mapper.Map<Spa>(rm);
            var result = await _SpaHandler.CreateSpa(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Spa>> Put([FromBody] UpdateSpaRequestModel rm)
        {
        	
        	var model = _mapper.Map<Spa>(rm);
        	var result = await _SpaHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _SpaHandler.DeleteSpa(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
