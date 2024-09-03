using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWise.Domain.Enums;
using SpendWise.Domain.Reports.CashPaymentType;

namespace SpendWise.Domain.Extensions
{
   public static  class PaymentTypeExtension
    {
        public static string PaymentTypeToString(this EPaymentType paymentType)
        {
            return paymentType switch
            {
                EPaymentType.Cash => ResourcePaymentType.CASH,
                EPaymentType.CreditCard => ResourcePaymentType.CREDIT_CARD,
                EPaymentType.DebitCard => ResourcePaymentType.DEBIT_CARD,
                EPaymentType.Check => ResourcePaymentType.CHECK,
                EPaymentType.EletronicTransfer => ResourcePaymentType.ELETRONIC_TRANSFER,
                _ => throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null),

            };
        }
    }
}
