using AutoMapper;
using Bank.Controllers.DTO;
using Bank.Services;

namespace Bank.Mappings.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountIn, CreateAccountRequestBody>();
        }
    }
}