using AutoMapper;
using IEM.Business.Models;
using IEM.Data.Models;

namespace IEM.Business.DataServices
{
    public class BusinessEntityMapping : Profile
    {
        public BusinessEntityMapping()
        {
            CreateMap<UserModel, User>()
                .ForMember(user => user.Id, act => act
                .MapFrom(userModel => userModel.UserID))
                .ReverseMap();

            CreateMap<IncomeModel, Income>()
                .ForMember(income => income.Id, act => act
                .MapFrom(incomeModel => incomeModel.IncomeID))
                .ReverseMap();

            CreateMap<ExpenditureModel, Expenditure>()
                .ForMember(exp => exp.Id, act => act
                .MapFrom(expModel => expModel.ExpID))
                .ReverseMap();
        }
    }
}
