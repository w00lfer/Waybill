using System.Threading.Tasks;
using Waybill.Helpers;
using Waybill.Services.Interfaces;

namespace Waybill
{
    public class ExcelManager
    {
        IExcelService _excelService;

        public ExcelManager(IExcelService excelService) => _excelService = excelService;

        public async Task CreateFile(string sourceFilePath, int[] range, string templateFilePath, string savingDirectory, string senderSettingsPath)
        {
            var excelData =  _excelService.ReadDataFromSourceFile(sourceFilePath, range);
            _excelService.SaveDataToDestinationFile(await SettingsReader.GetSenderSettings(senderSettingsPath), excelData, templateFilePath, savingDirectory);
        }
    }
}
