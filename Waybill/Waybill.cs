
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Waybill.Mapping;
using Waybill.Models.AppDbContext;
using Waybill.Repositories;
using Waybill.Repositories.Interfaces;
using Waybill.Services;
using Waybill.Services.Interfaces;

namespace Waybill
{
    class Waybill
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = ConfigureServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Console.WriteLine("Enter rows, seperate each with enter key");
            if (int.TryParse(Console.ReadLine(), out var firstRowIndex) && int.TryParse(Console.ReadLine(), out var lastRowIndex))
            {
                int[] range = { firstRowIndex, lastRowIndex };
                string sourceFilePath = args[0];
                string templateFilePath = args[1];
                string savingDirectory = args[2];
                string senderSettingsPath = args[3];
                await Run(sourceFilePath, range, templateFilePath, savingDirectory, senderSettingsPath, new ExcelManager(serviceProvider.GetService<IExcelService>()));
            }
            else throw new Exception("Cannot convert given input to Integer");
        }

        public static async Task Run(string sourceFilePath, int[] range, string templateFilePath, string savingDirectory, string senderSettingsPath, ExcelManager excelManager) =>
            await excelManager.CreateFile(sourceFilePath, range, templateFilePath, savingDirectory, senderSettingsPath);

        private static IServiceCollection ConfigureServices() =>
            new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseSqlite(@"Data Source=C:\Users\apaz02\source\repos\Waybill\Waybill\waybill.db")) // to be changed
                .AddSingleton<IComputerRepository, ComputerRepository>()
                .AddSingleton<ILocalisationRepository, LocalisationRepository>()
                .AddSingleton<IComputerService, ComputerService>()
                .AddSingleton<ILocalisationService, LocalisationService>()
                .AddSingleton<IExcelService, ExcelService>()
                .AddAutoMapper(typeof(MappingProfile));
    }
}   
