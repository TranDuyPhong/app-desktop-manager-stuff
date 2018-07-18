using MetroFramework;
using MetroFramework.Controls;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs.Constants.Excels.Export
{
    public static class ManipulationExportExcel
    {
        private delegate GlobalConstants.ResponseResult ExportExcelDelegate(string authorWork, string titleWork, string titleSheet, MetroGrid grid);

        // Method ExportExcel
        public static GlobalConstants.ResponseResult ExportExcel(string authorWork, string titleWork, string titleSheet, MetroGrid grid)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            string filePath = "";

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Excel files (*.xls)|*.xls";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            else
            {
                return res;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                res.TypeResponse = GlobalConstants.EnumResponse.NotExsistPath;

                return res;
            }

            try
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    package.Workbook.Properties.Author = authorWork;

                    package.Workbook.Properties.Title = titleWork;

                    package.Workbook.Worksheets.Add(titleSheet);

                    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

                    workSheet.Name = titleSheet;

                    workSheet.Cells.Style.Font.Size = 12;

                    workSheet.Cells.Style.Font.Name = "Tahoma";

                    if(grid.InvokeRequired)
                    {
                        var del = new ExportExcelDelegate(ExportExcel);

                        grid.Invoke(del);
                    }

                    int countColHeader = grid.Columns.Count;

                    workSheet.Cells[1, 1].Value = "Thống kê thông tin " + titleWork;

                    workSheet.Cells[1, 1, 1, countColHeader].Merge = true;

                    workSheet.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;

                    workSheet.Cells[1, 1, 1, countColHeader].Style.Font.Size = 14;

                    workSheet.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    foreach (DataGridViewColumn column in grid.Columns)
                    {
                        var cell = workSheet.Cells[rowIndex, colIndex];

                        var fill = cell.Style.Fill;

                        fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                        fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 174, 219));

                        cell.Value = column.HeaderText;

                        colIndex++;
                    }

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        if(grid.Rows[i].IsNewRow)
                        {
                            break;
                        }

                        rowIndex++;

                        colIndex = 1;

                        for (int j = 0; j < countColHeader; j++)
                        {
                            workSheet.Cells[rowIndex, colIndex].Value = grid[j, i].Value == null ? "" : grid[j, i].Value.ToString();

                            colIndex++;
                        }
                    }

                    Byte[] b = package.GetAsByteArray();

                    File.WriteAllBytes(filePath, b);

                    res.TypeResponse = GlobalConstants.EnumResponse.ExportSuccess;
                }
            }
            catch
            {
                res.TypeResponse = GlobalConstants.EnumResponse.ExportFail;
            }

            return res;
        }
    }
}
