
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Waybill.Mapping;
using Waybill.Models;
using Waybill.Repositories;
using Waybill.Repositories.Interfaces;
using Waybill.Services;
using Waybill.Services.Interfaces;

namespace Waybill
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = ConfigureServices();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            int[] range = new int[] { 3, 8 };// hardcoded range of rows for first try
            string sourceFilePath = @"C:\Users\apaz02\Desktop\formatka\source.xlsx"; // hardcoded path for first try
            string destinationFilePath = @"C:\users/apaz02\desktop\formatka\destination.xlsx"; // hardcoded path for first try
            string savingDirectory = @"C:\users\apaz02\desktop\formatka\output"; // hardcoded path for irst try
            CreateFile(sourceFilePath, range, destinationFilePath, savingDirectory, serviceProvider);
        }
        public static void CreateFile(string sourceFilePath, int[] range, string destinationFilePath, string savingDirectory, ServiceProvider serviceProvider)
        {
            var excelManager = new ExcelManager(serviceProvider.GetService<IExcelService>());
            excelManager.CreateFile(sourceFilePath, range, destinationFilePath, savingDirectory);
        }
        private static IServiceCollection ConfigureServices()
        {
            return new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=(local)\\sqlexpress; Database=WaybillDb; Trusted_Connection=True; MultipleActiveResultSets=True"))
                .AddSingleton<IComputerRepository, ComputerRepository>()
                .AddSingleton<ILocalisationRepository, LocalisationRepository>()
                .AddSingleton<IComputerService, ComputerService>()
                .AddSingleton<ILocalisationService, LocalisationService>()
                .AddSingleton<IExcelService, ExcelService>()
                .AddAutoMapper(typeof(MappingProfile));
        }
    }
}   
