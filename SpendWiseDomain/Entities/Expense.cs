using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Domain.Enums;

namespace SpendWise.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }

        public string? Description { get; set; } 

        public string Title { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public EPaymentType PaymentType { get; set; }




    }
}
