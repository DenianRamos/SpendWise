using AutoMapper;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;
using SpendWise.Domain.Entities;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();

    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisterExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }
}