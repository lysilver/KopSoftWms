using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using YL.Utils.Extensions;
using YL.Utils.Pub;

namespace YL.Utils.Excel
{
    /// <summary>
    /// NPOI linux 报错
    /// https://www.cnblogs.com/Robbery/p/10115234.html
    /// sudo ln -s /lib/x86_64-linux-gnu/libdl.so.2 /lib/x86_64-linux-gnu/libdl.so
    /// sudo apt install libgdiplus
    /// sudo ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
    /// </summary>
    public class NpoiUtil
    {
        private static readonly int Max = 65530; //
        public static string[] excel = { ".xlsx", ".xls" };

        #region NPOI excel Export

        /// <summary>
        /// return File(buffer, "application/ms-excel", "list.xlsx");
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static byte[] Export(DataTable dt, ExcelVersion version = ExcelVersion.V2007)
        {
            IWorkbook workbook;
            ICellStyle cellStyle;
            IFont font;
            switch (version)
            {
                case ExcelVersion.V2007:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                case ExcelVersion.V2003:
                    workbook = new HSSFWorkbook();
                    cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                default:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;
            }
            string sheetname = "sheet1";
            ISheet sheet = workbook.CreateSheet(sheetname);
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.CellStyle = cellStyle;
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }
            //数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.CellStyle = cellStyle;
                    cell.SetCellValue(dt.Rows[i][j]?.ToString());
                }
            }
            AutoSizeColumns(sheet);
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buffer = stream.ToArray();
            return buffer;
        }

        public static MemoryStream ExportDataTableToExcel(DataTable sourceTable, ExcelVersion version = ExcelVersion.V2007)
        {
            IWorkbook workbook;
            ICellStyle cellStyle;
            IFont font;
            switch (version)
            {
                case ExcelVersion.V2007:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                case ExcelVersion.V2003:
                    workbook = new HSSFWorkbook();
                    cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                default:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;
            }

            int dtRowsCount = sourceTable.Rows.Count;
            int _ = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dtRowsCount) / Max));
            int SheetNum = 1;
            int rowIndex = 1;
            int tempIndex = 1; //标示
            ISheet sheet = workbook.CreateSheet("sheet" + SheetNum);
            for (int i = 0; i < dtRowsCount; i++)
            {
                if (i == 0 || tempIndex == 1)
                {
                    IRow headerRow = sheet.CreateRow(0);
                    foreach (DataColumn column in sourceTable.Columns)
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                var dataRow = sheet.CreateRow(tempIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(sourceTable.Rows[i][column].ToString());
                }
                if (tempIndex == Max)
                {
                    SheetNum++;
                    sheet = workbook.CreateSheet("sheet" + SheetNum);//
                    tempIndex = 0;
                }
                rowIndex++;
                tempIndex++;
                AutoSizeColumns(sheet);
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }

        public static byte[] ExportToByte(DataTable dt, ExcelVersion version = ExcelVersion.V2007)
        {
            IWorkbook workbook;
            ICellStyle cellStyle;
            IFont font;
            switch (version)
            {
                case ExcelVersion.V2007:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                case ExcelVersion.V2003:
                    workbook = new HSSFWorkbook();
                    cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                default:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;
            }
            int count = dt.Rows.Count;
            int sheetCount = 1;
            if (count >= Max)
            {
                sheetCount = GetLen(count);
            }
            for (int i = 0; i < sheetCount; i++)
            {
                var sheetname = "sheet" + (i + 1);

                ISheet sheet = workbook.CreateSheet(sheetname);
                IRow row = sheet.CreateRow(0);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    cell.CellStyle = cellStyle;
                    cell.SetCellValue(dt.Columns[j].ColumnName);
                }
                var newDt = dt.Clone();
                dt.Rows.Cast<DataRow>().Skip(Max * i).Take(Max).ToList().ForEach(r => newDt.ImportRow(r));
                //数据
                for (int k = 0; k < newDt.Rows.Count; k++)
                {
                    IRow row1 = sheet.CreateRow(k + 1);
                    for (int m = 0; m < newDt.Columns.Count; m++)
                    {
                        ICell cell = row1.CreateCell(m);
                        cell.CellStyle = cellStyle;
                        cell.SetCellValue(newDt.Rows[k][m]?.ToString());
                    }
                }
                AutoSizeColumns(sheet);
            }

            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buffer = stream.ToArray();
            return buffer;
        }

        public static byte[] Export<T>(List<T> list, ExcelVersion version = ExcelVersion.V2007, string[] ignoreExport = null)
        {
            if (list.IsNullLt())
            {
                return null;
            }
            IWorkbook workbook;
            ICellStyle cellStyle;
            IFont font;
            switch (version)
            {
                case ExcelVersion.V2007:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                case ExcelVersion.V2003:
                    workbook = new HSSFWorkbook();
                    cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    font = (HSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;

                default:
                    workbook = new XSSFWorkbook();
                    cellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    font = (XSSFFont)workbook.CreateFont();
                    font.FontName = "宋体";
                    cellStyle.SetFont(font);
                    break;
            }

            int count = list.Count;
            int sheetCount = 1;
            if (count >= Max)
            {
                sheetCount = GetLen(count);
            }
            var entityProperties = typeof(T).GetProperties();
            for (int i = 0; i < sheetCount; i++)
            {
                string sheetname = "sheet" + (i + 1);
                ISheet sheet = workbook.CreateSheet(sheetname);
                IRow row = sheet.CreateRow(0);
                //Type entityType = list[0].GetType();
                //PropertyInfo[] entityProperties = entityType.GetProperties();
                int colIndex = 0;
                for (int j = 0; j < entityProperties.Length; j++)
                {
                    if (ignoreExport != null && ignoreExport.Contains(entityProperties[j].Name))
                    {
                        continue;
                    }
                    ICell cell = row.CreateCell(colIndex++);
                    cell.CellStyle = cellStyle;
                    cell.SetCellValue(entityProperties[j].Name);
                }
                var start = i * Max;
                var remaining = Math.Max(0, Math.Min(Max, count - start));
                var maxList = list.Skip(start).Take(remaining).ToList();
                //数据
                for (int k = 0; k < maxList.Count; k++)
                {
                    IRow row1 = sheet.CreateRow(k + 1);
                    // var properties = maxList[k].GetType().GetProperties();
                    for (int m = 0; m < entityProperties.Length; m++)
                    {
                        if (ignoreExport != null && ignoreExport.Contains(entityProperties[m].Name))
                        {
                            continue;
                        }
                        ICell cell = row1.CreateCell(m);
                        cell.CellStyle = cellStyle;
                        var id = entityProperties[m].GetValue(maxList[k])?.ToString();
                        cell.SetCellValue(id);
                    }
                }
                AutoSizeColumns(sheet);
            }
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buffer = stream.ToArray();
            return buffer;
        }

        private DocumentSummaryInformation SetDocumentSummaryInformation()
        {
            //文档摘要信息
            DocumentSummaryInformation dsi = new DocumentSummaryInformation
            {
                Company = ""
            };
            return dsi;
        }

        private SummaryInformation SetSummaryInformation()
        {
            SummaryInformation si = PropertySetFactory.NewSummaryInformation();
            si.Author = ""; //填加xls文件作者信息
            si.ApplicationName = ""; //填加xls文件创建程序信息
            si.LastAuthor = ""; //填加xls文件最后保存者信息
            si.Comments = ""; //填加xls文件作者信息
            si.Title = ""; //填加xls文件标题信息
            si.Subject = "";//填加文件主题信息
            si.CreateDateTime = DateTime.Now;
            return si;
        }

        /// <summary>
        /// 自动设置列宽
        /// </summary>
        /// <param name="sheet"></param>
        private static void AutoSizeColumns(ISheet sheet)
        {
            if (sheet.PhysicalNumberOfRows > 0)
            {
                IRow headerRow = sheet.GetRow(0);
                for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
                {
                    sheet.AutoSizeColumn(i);
                }
            }
        }

        private static int GetLen(int rowsCount)
        {
            int len = (int)Math.Ceiling((double)rowsCount / Max);
            return len < 1 ? 1 : len;
        }

        #endregion NPOI excel Export

        #region NPOI excel import

        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:
                    return null;

                case CellType.Boolean: //BOOLEAN:
                    return cell.BooleanCellValue;

                case CellType.Numeric: //NUMERIC:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        return cell.DateCellValue;
                    }
                    else
                    {
                        return cell.NumericCellValue;
                    }

                case CellType.String: //STRING:
                    return cell.StringCellValue;

                case CellType.Error: //ERROR:
                    return cell.ErrorCellValue;

                case CellType.Formula: //FORMULA:
                default:
                    return "=" + cell.CellFormula;
            }
        }

        public static DataTable Import(string filepath)
        {
            var dt = new DataTable();
            string fileExt = Path.GetExtension(filepath).ToLower();
            IWorkbook workbook;
            ISheet sheet;
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else
                {
                    workbook = new HSSFWorkbook(fs);
                }
                if (workbook == null)
                {
                    return null;
                }
                else
                {
                    int sheetCount = workbook.NumberOfSheets;
                    int columns = 0;
                    if (sheetCount > 0)
                    {
                        sheet = workbook.GetSheetAt(0);
                        IRow header = sheet.GetRow(sheet.FirstRowNum);
                        for (int i = 0; i < header.LastCellNum; i++)
                        {
                            object obj = GetValueType(header.GetCell(i));
                            if (obj == null || obj.ToString() == string.Empty)
                            {
                                dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            }
                            else
                            {
                                dt.Columns.Add(new DataColumn(obj.ToString()));
                            }
                        }
                        columns = dt.Columns.Count;
                    }
                    for (int i = 0; i < sheetCount; i++)
                    {
                        sheet = workbook.GetSheetAt(i);
                        for (int j = sheet.FirstRowNum + 1; j <= sheet.LastRowNum; j++)
                        {
                            DataRow dr = dt.NewRow();
                            bool hasValue = false;
                            for (int k = 0; k < columns; k++)
                            {
                                dr[k] = GetValueType(sheet.GetRow(j).GetCell(k));
                                if (dr[k] != null && dr[k].ToString() != string.Empty)
                                {
                                    hasValue = true;
                                }
                            }
                            if (hasValue)
                            {
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            return dt;
        }

        /// <summary>
        ///导入
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="fileExt">文件名后缀</param>
        /// <returns></returns>
        public static DataTable Import(Stream fs, string fileExt)
        {
            fs.Seek(0, SeekOrigin.Begin);
            var dt = new DataTable();
            IWorkbook workbook;
            ISheet sheet;
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook(fs);
            }
            else
            {
                workbook = new HSSFWorkbook(fs);
            }
            if (workbook == null)
            {
                return null;
            }
            else
            {
                int sheetCount = workbook.NumberOfSheets;
                int columns = 0;
                if (sheetCount > 0)
                {
                    sheet = workbook.GetSheetAt(0);
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueType(header.GetCell(i));
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        }
                        else
                        {
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        }
                    }
                    columns = dt.Columns.Count;
                }
                for (int i = 0; i < sheetCount; i++)
                {
                    sheet = workbook.GetSheetAt(i);
                    for (int j = sheet.FirstRowNum + 1; j <= sheet.LastRowNum; j++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        for (int k = 0; k < columns; k++)
                        {
                            dr[k] = GetValueType(sheet.GetRow(j).GetCell(k));
                            if (dr[k] != null && dr[k].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }

        #endregion NPOI excel import
    }
}