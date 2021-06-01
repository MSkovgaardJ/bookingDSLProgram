using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
namespace DangleterreV2.RequestModels
{
	public class CreateRoomRequestModel
	{
public string name {get; set;}
public int capacity {get; set;}
public bool normalRoom {get; set;}
public int bookedFrom {get; set;}
public int bookedUntil {get; set;}
public List<RoomSchedule> plan {get; set;} 
    }
}
