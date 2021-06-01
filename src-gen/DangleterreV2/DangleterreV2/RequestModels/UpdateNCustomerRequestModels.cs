using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
using System;
		
namespace DangleterreV2.RequestModels
{
    public class UpdateNCustomerRequestModel
    {
    public Guid Id {get; set;}
		public string name {get; set;}
		public bool vip {get; set;}
		public int phoneNumber {get; set;}
		public int points {get; set;}
    }
}
