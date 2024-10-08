﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.Application.UseCase.Expenses.Delete;
using SpendWise.Application.UseCase.Expenses.GetAll;
using SpendWise.Application.UseCase.Expenses.GetById;
using SpendWise.Application.UseCase.Expenses.Register;
using SpendWise.Application.UseCase.Expenses.Register.User;
using SpendWise.Application.UseCase.Expenses.Reports.Excel;
using SpendWise.Application.UseCase.Expenses.Reports.Pdf;
using SpendWise.Application.UseCase.Expenses.Update;
using SpendWise.Application.UseCase.Login;
using SpendWise.Domain.Security;

namespace SpendWise.Application
{
    public static  class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCase(services);

            
        }
    public static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCase (IServiceCollection services)
        {
            services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
            services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>(); 
            services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
            services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();
           
           

        }
        
    
    

    }
}
