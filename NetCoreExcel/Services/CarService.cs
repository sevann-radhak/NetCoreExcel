using NetCoreExcel.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetCoreExcel.Services
{
    public class CarService
    {
        public ICollection<CarRequest> GetCarRequest()
        {
            List<CarRequest> cars = new List<CarRequest>();
            string filePath = "C:\\AUTOS.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int totalColum = worksheet.Dimension.End.Column;
                int totalRow = worksheet.Dimension.End.Row;

                for (int row = 2; row <= totalRow; row++)
                {
                    CarRequest car = new CarRequest();
                    for (int col = 1; col <= totalColum; col++)
                    {
                        if (col == 1)
                        {
                            car.Amis = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 2)
                        {
                            car.Marca = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 3)
                        {
                            car.Tipo = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 4)
                        {
                            car.Descripcion = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 5)
                        {
                            car.Modelo = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 6)
                        {
                            car.Bucket = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 7)
                        {
                            car.LoJack = worksheet.Cells[row, col].Value.ToString();
                        }
                    }

                    cars.Add(car);
                }
            }

            return cars;
        }
    }
}
