using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Communication.Responses
{
    public class ResponsesExpensesJson
    {
        public List<ResponseShortExpenseJson> Expenses { get; set; } = [];
    }


}
