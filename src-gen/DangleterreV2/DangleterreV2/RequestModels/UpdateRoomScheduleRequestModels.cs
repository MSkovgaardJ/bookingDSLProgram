using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
using System;
		
namespace DangleterreV2.RequestModels
{
    public class UpdateRoomScheduleRequestModel
    {
    	public Guid Id {get; set;}
public string name {get; set;}
public int start {get; set;}
public int end {get; set;}
    }
}
