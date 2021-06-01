using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
namespace DangleterreV2.RequestModels
{
    public class CreateRoomBookRequestModel
    {
public string name {get; set;}
public Room Room {get; set;} 
public RoomSchedule plan {get; set;} 
public NCustomer cus {get; set;} 
    }
}
