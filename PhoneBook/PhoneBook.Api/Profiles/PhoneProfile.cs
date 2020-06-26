using AutoMapper;
using PhoneBook.Api.Models;
using PhoneBook.Core.Entities;

namespace PhoneBook.Api.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<CreatePhoneDto, Phone>();
            CreateMap<UpdatePhoneDto, Phone>();

            CreateMap<Phone, PhoneDto>();
        }
    }
}
