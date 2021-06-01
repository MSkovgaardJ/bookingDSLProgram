using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
	public class Room : IEntity
	{
		public Guid Id {get; set;}
        public string name {get; set;}
        public int capacity {get; set;}
        public bool normalRoom {get; set;}
        public int bookedFrom {get; set;}
        public int bookedUntil {get; set;}
        public List<RoomSchedule> plan {get; set;} 
    }
}
