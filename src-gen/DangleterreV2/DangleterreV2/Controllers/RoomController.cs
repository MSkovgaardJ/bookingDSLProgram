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
    [Route("Room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomHandler _RoomHandler;
        private readonly IMapper _mapper;

        public RoomController(IRoomHandler RoomHandler, IMapper mapper)
        {
            _RoomHandler = RoomHandler;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Room>>> Get(int page = 0, int pageSize = 100)
        {
            var result = await _RoomHandler.GetAll(page, pageSize);
            
            if (result == null)
            	return NotFound();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Room>> Get(Guid id)
        {
            var result = await _RoomHandler.Get(id);
            
            if (result == null)
            	return NotFound();
            				            
           	return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateRoomRequestModel rm)
        {
        	
            var model = _mapper.Map<Room>(rm);
            var result = await _RoomHandler.CreateRoom(model);
            
            if (result == null)
            	return NotFound();
            				            
            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Room>> Put([FromBody] UpdateRoomRequestModel rm)
        {
        	
        	var model = _mapper.Map<Room>(rm);
        	var result = await _RoomHandler.Update(model);
        	
        	if (result == null)
        		return NotFound();
        					            
        	return Ok(result);
        }
        
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
        	var result = await _RoomHandler.DeleteRoom(id);
        	
        	if (!result)
        	     return NotFound();
        	
        	return Ok(result);
        }
        
        [HttpPut]
        [Route("AddRoomSchedulesToAll")]
        public async Task<ActionResult<List<Room>>> AddRoomSchedulesToAll([FromBody] List<RoomSchedule> list)
        {
        	var result = await _RoomHandler.AddRoomScheduleToAllResources(list);
        	
        	if(result == null) return BadRequest();
        	
        	return Ok(result);
        }
    }
}
