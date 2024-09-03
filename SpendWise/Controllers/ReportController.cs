﻿using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpendWise.Application.UseCase.Expenses.Reports.Excel;
using SpendWise.Application.UseCase.Expenses.Reports.Pdf;
using SpendWise.Communication.Requests;

namespace SpendWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public async Task<IActionResult> GetExcel([FromHeader] DateOnly month, IGenerateExpensesReportExcelUseCase useCase)
        {
            byte[] file = await useCase.Execute(month);
            if ( file.Length > 0)
            {
                return File(file, MediaTypeNames.Application.Octet, "report.xlsx");
            }

            return NoContent();
        }

        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPdf(
            [FromServices] IGenerateExpensesReportPdfUseCase useCase,
            [FromQuery] DateOnly month)
        {
            byte[] file = await useCase.Execute(month);
            if ( file.Length > 0)
            {
                return File(file, MediaTypeNames.Application.Pdf, "report.pdf");
            }

            return NoContent();
        }
    }
}
