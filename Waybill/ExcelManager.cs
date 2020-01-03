using System.Threading.Tasks;
using Waybill.Services.Interfaces;

namespace Waybill
{
    public class ExcelManager
    {
        IExcelService _excelService;

        public ExcelManager(IExcelService excelService) => _excelService = excelService;

        public void CreateFile(string sourceFilePath, int[] range, string destinationFilePath, string savingDirectory)
        {
            var excelData =  _excelService.ReadDataFromSourceFile(sourceFilePath, range);
             _excelService.SaveDataToDestinationFile(excelData, destinationFilePath, savingDirectory);
        }

    }
}
