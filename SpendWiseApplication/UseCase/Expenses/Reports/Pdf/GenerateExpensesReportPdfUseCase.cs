
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using SpendWise.Application.UseCase.Expenses.Colors;
using SpendWise.Application.UseCase.Expenses.Fonts;
using SpendWise.Domain.Extensions;
using SpendWise.Domain.Reports;
using SpendWise.Domain.Repositories;

namespace SpendWise.Application.UseCase.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
    {
        private IExpenseReadOnlyRepository _repository;
        private const string CURRENT_SIMBOL = "€";
        private const int HEIGHT = 25;


        public GenerateExpensesReportPdfUseCase(IExpenseReadOnlyRepository repository)
        {
            _repository = repository;
            GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
        }

        public async Task<byte[]> Execute(DateOnly month)
        {

            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            var document = CreateDocument(month);
            var page = CreatePage(document);

            CreateHeaderWithProfileName(page);
            var totalExpenses = expenses.Sum(expense => expense.Amount);
            CreateTotalSpenseSection(page, month, totalExpenses);
            foreach (var expense in expenses)
            {
                var table = CreateExpenseTable(page);

                var row = table.AddRow();

                row.Height = HEIGHT;

                AddExpenseTitle(row.Cells[0], expense.Title);

                AddHeaderForAmount(row.Cells[3]);

                row = table.AddRow();

                row.Height = HEIGHT;
                row.Cells[0].AddParagraph(expense.Date.ToString("D"));

                SetStyleBaseExpenseInformation(row.Cells[0]);

                row.Cells[0].Format.LeftIndent = 20;


                row.Cells[1].AddParagraph(expense.Date.ToString("t"));
                SetStyleBaseExpenseInformation(row.Cells[1]);
                row.Cells[2].AddParagraph(expense.PaymentType.PaymentTypeToString());
                SetStyleBaseExpenseInformation(row.Cells[2]);

                AddAmountForExpense(row.Cells[3], expense.Amount);

                if (string.IsNullOrWhiteSpace(expense.Description) == false)
                {
                    var descriptionRow = table.AddRow();
                    descriptionRow.Height = HEIGHT;
                    descriptionRow.Cells[0].AddParagraph(expense.Description);
                    descriptionRow.Cells[0].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 10, Color = ColorHelper.BLACK };
                    descriptionRow.Cells[0].Shading.Color = ColorHelper.GREEN_LIGHT;
                    descriptionRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    descriptionRow.Cells[0].MergeRight = 2;
                    descriptionRow.Cells[0].Format.LeftIndent = 20;

                    row.Cells[3].MergeDown = 1;
                }

                AddWhiteSpace(table);
            }





            return RenderDocument(document);
        }

        private Document CreateDocument(DateOnly month)
        {
            var document = new Document();

            document.Info.Title = $"{ResourceReportGenerationMessage.EXPENSES_FOR} {month.ToString("Y")}";
            document.Info.Author = "Author: Denian";

            var style = document.Styles["Normal"];
            style.Font.Name = "WorkSans-Regular";

            return document;
        }

        private Section CreatePage(Document document)
        {
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }

        private Byte[] RenderDocument(Document document)
        {
            var render = new PdfDocumentRenderer
            {
                Document = document
            };
            render.RenderDocument();

            using var file = new MemoryStream();
            render.PdfDocument.Save(file, false);

            return file.ToArray();
        }

        private void CreateHeaderWithProfileName(Section page)
        {

            var table = page.AddTable();
            table.AddColumn(300);


            var row = table.AddRow();
            row.Cells[0].AddParagraph("Hey, Denian Ramos");
            row.Cells[0].Format.Font = new Font { Name = FontHelper.RALEWAY_BOLD, Size = 16 };
        }

        private Table CreateExpenseTable(Section page)
        {
            var table = page.AddTable();

            var column = table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

            return table;
        }

        private void CreateTotalSpenseSection(Section page, DateOnly month, decimal totalExpenses)
        {


            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            var title = string.Format(ResourceReportGenerationMessage.TOTAL_SPEND, month.ToString("Y"));

            paragraph.Format.Font.Name = FontHelper.WORKSANS_BOLD;

            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });

            paragraph.AddLineBreak();


            paragraph.AddFormattedText($"{totalExpenses}{CURRENT_SIMBOL}",
                new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
        }

        private void AddExpenseTitle(Cell cell, string expenseTitle)
        {
            cell.AddParagraph(expenseTitle);
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BOLD, Size = 14, Color = ColorHelper.BLACK };
            cell.Shading.Color = ColorHelper.RED_LIGHT;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
            cell.Format.LeftIndent = 20;
        }

        private void SetStyleBaseExpenseInformation(Cell cell)
        {
            cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12, Color = ColorHelper.BLACK };
            cell.Shading.Color = ColorHelper.GREEN_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }

        private void AddAmountForExpense(Cell cell, decimal amount)
        {
            cell.AddParagraph($"{amount} {CURRENT_SIMBOL}");
            cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 14, Color = ColorHelper.BLACK };
            cell.Shading.Color = ColorHelper.WHITE;
            cell.VerticalAlignment = VerticalAlignment.Center;

        }   
        private void AddHeaderForAmount(Cell cell)
        {
            cell.AddParagraph(ResourceReportGenerationMessage.AMOUNT);
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BOLD, Size = 14, Color = ColorHelper.WHITE };
            cell.Shading.Color = ColorHelper.RED_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }

        private void AddWhiteSpace(Table table)
        {
            var row = table.AddRow();
            row.Height = 30;
            row.Borders.Visible = false;
        }
    }
}