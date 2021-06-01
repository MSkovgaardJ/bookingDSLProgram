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
    [Route("RoomBook")]
    public class RoomBookController : ControllerBase
    {
        private readonly IRoomBookHandler _RoomBookHandler;
        private readonly IMapper _mapper;

        public RoomBookController(IRoomBookHandler RoomBookHandler, IMapper mapper)
        {
            _RoomBookHandler = RoomBookHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<RoomBook>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _RoomBookHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RoomBook>> Get(Guid id)
        {
            var result = await _RoomBookHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateRoomBookRequestModel rm)
        {
        	
            var model = _mapper.Map<RoomBook>(rm);
            var result = await _RoomBookHandler.CreateRoomBook(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<RoomBook>> Put([FromBody] UpdateRoomBookRequestModel rm)
        {
        	
        	var model = _mapper.Map<RoomBook>(rm);
        	var result = await _RoomBookHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _RoomBookHandler.DeleteRoomBook(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
