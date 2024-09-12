using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Communication.Requests;
using SpendWise.Communication.Responses;

namespace SpendWise.Application.UseCase.Login
{
    public interface ILoginUseCase
    {
        Task<ResponseRegisteredUserJson>Execute (RequestLoginJson request);
    }
}
