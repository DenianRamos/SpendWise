using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using SpendWise.Domain.Entities;
using SpendWise.Domain.Enums;
using SpendWise.Domain.Extensions;
using SpendWise.Domain.Reports;
using SpendWise.Domain.Reports.CashPaymentType;
using SpendWise.Domain.Repositories;

namespace SpendWise.Application.UseCase.Expenses.Reports.Excel
{
    internal class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase


    {
        private const string CURRENCY_SYMBOL = "€";
        private IExpenseReadOnlyRepository _repository;
        public GenerateExpensesReportExcelUseCase(IExpenseReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<byte[]> Execute(DateOnly month)
        {


            var expenses = await _repository.FilterByMonth(month);

            if (expenses.Count == 0)
            {
                return [];
            }
            using var workBook = new XLWorkbook();
            workBook.Author = "SpendWise";
            workBook.Style.Font.FontName = "Arial";
            workBook.Style.Font.FontSize = 12;


            var workSheet = workBook.Worksheets.Add(month.ToString("Y"));
            InsertHeader(workSheet);
            var row = 2;

            foreach (var expense in expenses)
            {
                if (expense == null) continue;

                workSheet.Cell($"A{row}").Value = expense.Title;
                workSheet.Cell($"B{row}").Value = expense.Date;
                workSheet.Cell($"C{row}").Value = expense.PaymentType.PaymentTypeToString();
                workSheet.Cell($"D{row}").Value = expense.Amount;
                workSheet.Cell($"D{row}").Style.NumberFormat.Format = $"{CURRENCY_SYMBOL} #,##0.00";
                workSheet.Cell($"E{row}").Value = expense.Description;

                row++;
            }
            workSheet.Columns().AdjustToContents();
            var file = new MemoryStream();
            workBook.SaveAs(file);

            return file.ToArray();

        }


        private void InsertHeader(IXLWorksheet workSheet)
        {

            workSheet.Cell("A1").Value = ResourceReportGenerationMessage.TITLE;
            workSheet.Cell("B1").Value = ResourceReportGenerationMessage.DATE;
            workSheet.Cell("C1").Value = ResourceReportGenerationMessage.PAYMENT_TYPE;
            workSheet.Cell("D1").Value = ResourceReportGenerationMessage.AMOUNT;
            workSheet.Cell("E1").Value = ResourceReportGenerationMessage.DESCRIPTION;

            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

            workSheet.Cells("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Cells("B1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Cells("C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Cells("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            workSheet.Cells("E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}
