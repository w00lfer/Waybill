using AutoMapper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            {
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(sourceFilePath)))
                {
                    var worksheet = excelPackage.Workbook.Worksheets[0];
                    var dataFromExcel = new List<ShipmentDTO>();
                    for (int i = range[0]; i <= range[1]; i++)
                    {
                        dataFromExcel.Add(new ShipmentDTO
                        {
                            CompanyName = worksheet.GetValue<string>(i, 17),
                            UserName = $"{worksheet.GetValue<string>(i, 13)} {worksheet.GetValue<string>(i,12 )}",
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

        public void SaveDataToDestinationFile(SenderSettings senderSettings, List<ShipmentDTO> excelData, string templateFilePath, string savingDirectory)
        {
            var incorrectDataRowIndexes =  CheckExcelDataForWrongFilledRows(excelData);
            var shipments = _mapper.Map<List<Shipment>>(excelData);
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo($@"{savingDirectory}\{DateTime.Today.ToShortDateString()}{excelData[0].UserName}.xlsm"), new FileInfo(templateFilePath)))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                worksheet.DataValidations.Clear();
                for (int i = 6; i < shipments.Count + 6; i++) //  i = 6 because 1-5 rows are used for template in destination file
                {
                    SetSenderData(worksheet, i, senderSettings);
                    SetReceiverData(worksheet, i, shipments[i - 6]);
                    if (incorrectDataRowIndexes.Contains(i - 6) == true) SetColorForWrongFilledRow(worksheet, i);
                }
                excelPackage.Save();
            }
        }

        private void SetSenderData(ExcelWorksheet worksheet, int rowIndex, SenderSettings senderSettings)
        {
            worksheet.SetValue(rowIndex, 1, senderSettings.CompanyName);
            worksheet.SetValue(rowIndex, 2, senderSettings.UserName);
            worksheet.SetValue(rowIndex, 3, senderSettings.TelephoneNumber);
            worksheet.SetValue(rowIndex, 4, senderSettings.City);
            worksheet.SetValue(rowIndex, 5, senderSettings.StreetAddress);
            worksheet.SetValue(rowIndex, 6, senderSettings.ZipCode);
        }

        private void SetReceiverData(ExcelWorksheet worksheet, int rowIndex, Shipment shipment)
        {
            worksheet.SetValue(rowIndex, 7, shipment.CompanyName);
            worksheet.SetValue(rowIndex, 8, shipment.UserName);
            worksheet.SetValue(rowIndex, 9, shipment.TelephoneNumber);
            worksheet.SetValue(rowIndex, 10, shipment.City);
            worksheet.SetValue(rowIndex, 11, shipment.StreetAddress);
            worksheet.SetValue(rowIndex, 12, shipment.ZipCode);
            worksheet.SetValue(rowIndex, 13, "1"); // sets number of packages to 1
            worksheet.SetValue(rowIndex, 14, shipment.Weight);
            worksheet.SetValue(rowIndex, 16, shipment.Price);
            worksheet.SetValue(rowIndex, 15, shipment.ModelName);
            worksheet.SetValue(rowIndex, 19, shipment.SerialNumber);
            worksheet.SetValue(rowIndex, 22, "Department name");
        }

        private List<int> CheckExcelDataForWrongFilledRows(List<ShipmentDTO> excelData)
        {
            var incorrectDataRowIndexes = new List<int>();
            for (int i = 0; i < excelData.Count; i++)
                if (IsAnyNullOrEmpty(excelData[i]))
                    incorrectDataRowIndexes.Add(i);
            return incorrectDataRowIndexes;
        }

        private bool IsAnyNullOrEmpty(ShipmentDTO shipmentDTO)
        {
            foreach (PropertyInfo pi in shipmentDTO.GetType().GetProperties())
            {
                string value = (string)pi.GetValue(shipmentDTO);
                if (string.IsNullOrEmpty(value)) return true;
            }
            return false;
        }

        // Sets color for row which has one or more cells empty to let user know about that
        private void SetColorForWrongFilledRow(ExcelWorksheet worksheet, int rowIndex)
        {
            worksheet.Row(rowIndex).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Row(rowIndex).Style.Fill.BackgroundColor.SetColor(Color.MediumVioletRed);
        }
    }
}
