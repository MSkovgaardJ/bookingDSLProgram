using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
using System;
		
namespace DangleterreV2.RequestModels
{
    public class UpdateRoomBookRequestModel
    {
    	public Guid Id {get; set;}
public string name {get; set;}
public Room Room {get; set;} 
public RoomSchedule plan {get; set;} 
public NCustomer cus {get; set;} 
    }
}
