using System.Collections.Generic;
using Waybill.Models;

namespace Waybill.Services.Interfaces
{
    public interface IExcelService
    {
        public List<ShipmentDTO> ReadDataFromSourceFile(string sourceFilePath, int[] range);
        public void SaveDataToDestinationFile(SenderSettings senderSettings, List<ShipmentDTO> excelData, string templateFilePath, string savingDirectory);
    }
}
