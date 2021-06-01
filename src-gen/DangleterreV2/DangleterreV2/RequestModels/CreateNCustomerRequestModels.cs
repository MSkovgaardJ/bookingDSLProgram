using DangleterreV2.Persistence.Models;
using System.Collections.Generic;
namespace DangleterreV2.RequestModels
{
    public class CreateNCustomerRequestModel
			{
		public string name {get; set;}
		public bool vip {get; set;}
		public int phoneNumber {get; set;}
		public int points {get; set;}
    }
}
