using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
    public class RoomBook : IEntity
    {
    	public Guid Id {get; set;}
        public string name {get; set;}
        public Room Room {get; set;} 
        public RoomSchedule plan {get; set;} 
        public NCustomer cus {get; set;} 
    }
}
