using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
    public class Spa : IEntity
    {
    	public Guid Id {get; set;}
        public string name {get; set;}
    }
}
