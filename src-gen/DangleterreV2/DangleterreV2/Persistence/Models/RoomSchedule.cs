using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
    public class RoomSchedule : IEntity
    {
    	public Guid Id {get; set;}
        public string name {get; set;}
        public int start {get; set;}
        public int end {get; set;}
    }
}
