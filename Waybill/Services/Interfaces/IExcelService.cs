using System.Collections.Generic;
using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Services.Interfaces
{
    public interface IExcelService
    {
        public List<ShipmentDTO> ReadDataFromSourceFile(string sourceFilePath, int[] range);
        public void SaveDataToDestinationFile(List<ShipmentDTO> excelData, string destinationFilePath, string savingDirectory);
    }
}
