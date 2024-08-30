using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendWise.Communication.Responses
{
    public class ResponseShortExpenseJson
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
