using AutoMapper;
using Entities;
using Utility.Dtos;

namespace AccountsAndUsers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountReadDto>().ReverseMap();
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserWriteDto>().ReverseMap();
            CreateMap<Account, AccountWriteDto>().ReverseMap();
            CreateMap<Account, SingleAccountReadDto>().ReverseMap();
            CreateMap<Account, AccountUpdateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();  
        }
    }
}
