using System;
using System.Collections.Generic;

namespace DangleterreV2.Persistence.Models
{
	public class NCustomer : IEntity
	{
		public Guid Id {get; set;}
        public string name {get; set;}
        public bool vip {get; set;}
        public int phoneNumber {get; set;}
        public int points {get; set;}
    }
}
