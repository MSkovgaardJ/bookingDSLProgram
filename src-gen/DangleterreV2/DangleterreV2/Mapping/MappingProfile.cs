using AutoMapper;
using DangleterreV2.Persistence.Models;
using DangleterreV2.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using DangleterreV2.RequestModels;
using DangleterreV2.Persistence.Models;

namespace DangleterreV2.Mapping
{
    public class MappingProfile : Profile{
    	public MappingProfile()
    	{
    	CreateMap<CreateRoomRequestModel, Room>().ReverseMap();
    	CreateMap<UpdateRoomRequestModel, Room>().ReverseMap();
    	CreateMap<CreateSuiteRequestModel, Suite>().ReverseMap();
    	CreateMap<UpdateSuiteRequestModel, Suite>().ReverseMap();
    	CreateMap<CreateRoomBookRequestModel, RoomBook>().ReverseMap();
    	CreateMap<UpdateRoomBookRequestModel, RoomBook>().ReverseMap();
    	CreateMap<CreateNCustomerRequestModel, NCustomer>().ReverseMap();
    	CreateMap<UpdateNCustomerRequestModel, NCustomer>().ReverseMap();
    	CreateMap<CreateSpaRequestModel, Spa>().ReverseMap();
    	CreateMap<UpdateSpaRequestModel, Spa>().ReverseMap();
    	CreateMap<CreateVipCustomerRequestModel, VipCustomer>().ReverseMap();
    	CreateMap<UpdateVipCustomerRequestModel, VipCustomer>().ReverseMap();
    	CreateMap<CreateRoomScheduleRequestModel, RoomSchedule>().ReverseMap();
    	CreateMap<UpdateRoomScheduleRequestModel, RoomSchedule>().ReverseMap();
    	}	
    }
}
