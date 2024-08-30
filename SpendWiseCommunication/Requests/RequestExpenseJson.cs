using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Communication.Enums;

namespace SpendWise.Communication.Requests
{
    public class RequestExpenseJson
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; } 

        public decimal Amount { get; set; } 

        public EPaymentType PaymentType { get; set; }

    }
}
