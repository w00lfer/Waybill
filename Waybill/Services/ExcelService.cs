using AutoMapper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Waybill.Models;
using Waybill.Services.Interfaces;

namespace Waybill.Services
{
    class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;
        public ExcelService(IMapper mapper) => _mapper = mapper;

        public List<ShipmentDTO> ReadDataFromSourceFile(string sourceFilePath, int[] range)
        {
           // return Task.Run(() =>
            {
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(sourceFilePath)))
                {
                    Console.WriteLine("LOL");
                    var worksheet = excelPackage.Workbook.Worksheets[0];
                    var dataFromExcel = new List<ShipmentDTO>();
                    for (int i = range[0]; i <= range[1]; i++)
                    {
                        dataFromExcel.Add(new ShipmentDTO
                        {
                            CompanyName = worksheet.GetValue<string>(i, 17),
                            UserName = worksheet.GetValue<string>(i, 13),
                            TelephoneNumber = worksheet.GetValue<string>(i, 15),
                            StreetAddress = worksheet.GetValue<string>(i, 19),
                            City = worksheet.GetValue<string>(i, 18),
                            ModelName = worksheet.GetValue<string>(i, 11),
                            SerialNumber = worksheet.GetValue<string>(i, 8),

                        });
                    }
                    worksheet.Dispose();
                    return dataFromExcel;
                }
            }
        }

        public void SaveDataToDestinationFile(List<ShipmentDTO> excelData, string destinationFilePath, string savingDirectory)
        {
            //return Task.Run(() =>
            //{
                var incorrectDataIndexes = new List<int>();
                CheckExcelData(excelData, incorrectDataIndexes);
                var shipments = _mapper.Map<List<Shipment>>(excelData);
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(destinationFilePath)))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                    for(int i = 6; i < shipments.Count+6; i++)
                    {
                        worksheet.SetValue(i, 7, shipments[i-6].CompanyName);
                        worksheet.SetValue(i, 8, shipments[i-6].UserName);
                        worksheet.SetValue(i, 9, shipments[i-6].TelephoneNumber);
                        worksheet.SetValue(i, 11, shipments[i-6].StreetAddress);
                        worksheet.SetValue(i, 12, shipments[i-6].ZipCode);
                        worksheet.SetValue(i, 10, shipments[i-6].City);
                        worksheet.SetValue(i, 7, "1");
                        worksheet.SetValue(i, 14, shipments[i-6].Weight);
                        worksheet.SetValue(i, 15, shipments[i-6].ModelName);
                        worksheet.SetValue(i, 16, shipments[i-6].Price);
                        worksheet.SetValue(i, 19, shipments[i-6].SerialNumber);
                        worksheet.SetValue(i, 21, "Produkcja komputerów");
                        if (incorrectDataIndexes.Contains(i - 6) == true) SetColorForWrongFilledRow(worksheet, i - 6);
                    }
                excelPackage.SaveAs(new FileInfo(savingDirectory + "\\2.xlsx"));
                excelPackage.Dispose();
            }
          //  });
        }

        private void CheckExcelData(List<ShipmentDTO> excelData, List<int> incorrectDataIndexes)
        {
            for (int i = 0; i < excelData.Count; i++)
                if (IsAnyNullOrEmpty(excelData[i])) incorrectDataIndexes.Add(i);
        }

        private bool IsAnyNullOrEmpty(ShipmentDTO shipmentDTO)
        {
            foreach (PropertyInfo pi in shipmentDTO.GetType().GetProperties())
            {
                string value = (string)pi.GetValue(shipmentDTO);
                if (String.IsNullOrEmpty(value)) return true;
            }
            return false;
        }
        private void SetColorForWrongFilledRow(ExcelWorksheet worksheet, int rowIndex)
        {
            worksheet.Row(rowIndex).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Row(rowIndex).Style.Fill.BackgroundColor.SetColor(Color.MediumVioletRed);
        }
    }
}
