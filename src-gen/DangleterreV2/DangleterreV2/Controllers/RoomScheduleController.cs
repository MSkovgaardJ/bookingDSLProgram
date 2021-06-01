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
    [Route("RoomSchedule")]
    public class RoomScheduleController : ControllerBase
    {
        private readonly IRoomScheduleHandler _RoomScheduleHandler;
        private readonly IMapper _mapper;

        public RoomScheduleController(IRoomScheduleHandler RoomScheduleHandler, IMapper mapper)
        {
            _RoomScheduleHandler = RoomScheduleHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<RoomSchedule>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _RoomScheduleHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RoomSchedule>> Get(Guid id)
        {
            var result = await _RoomScheduleHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateRoomScheduleRequestModel rm)
        {
        	
            var model = _mapper.Map<RoomSchedule>(rm);
            var result = await _RoomScheduleHandler.CreateRoomSchedule(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<RoomSchedule>> Put([FromBody] UpdateRoomScheduleRequestModel rm)
        {
        	
        	var model = _mapper.Map<RoomSchedule>(rm);
        	var result = await _RoomScheduleHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _RoomScheduleHandler.DeleteRoomSchedule(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
    }
}
