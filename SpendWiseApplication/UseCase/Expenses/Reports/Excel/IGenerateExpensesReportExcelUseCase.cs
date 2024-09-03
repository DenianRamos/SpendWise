using System;
using System.Threading.Tasks;

namespace SpendWise.Application.UseCase.Expenses.Reports.Excel
{
    public interface IGenerateExpensesReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}