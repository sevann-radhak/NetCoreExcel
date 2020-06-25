using NetCoreExcel.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetCoreExcel.Services
{
    public class CarGroupService
    {
        public ICollection<CarGroup> GetCarCategories()
        {
            List<CarGroup> carGroups = new List<CarGroup>();
            string filePath = "C:\\AUTOS_GROUP.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int totalColum = worksheet.Dimension.End.Column;
                int totalRow = worksheet.Dimension.End.Row;

                for (int row = 2; row <= totalRow; row++)
                {
                    CarGroup carGroup = new CarGroup();
                    for (int col = 1; col <= totalColum; col++)
                    {
                        if (col == 1)
                        {
                            carGroup.GroupId = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 2)
                        {
                            carGroup.NMarc = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 3)
                        {
                            carGroup.CGroup = worksheet.Cells[row, col].Value.ToString();
                        }

                        if (col == 4)
                        {
                            carGroup.NGroup = worksheet.Cells[row, col].Value.ToString();
                        }
                    }

                    carGroups.Add(carGroup);
                }
            }

            return carGroups;
        }
    }
}
