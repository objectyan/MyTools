using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OY.Common.Office.Interface;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using NPOI.HPSF;

namespace OY.Common.Office
{
    class OfficeExcel : IOfficeExcel
    {
        /// <summary>
        /// Excel数据导入
        /// </summary>
        /// <param name="_excelPath">Excel文件地址</param>
        /// <param name="_sheet_Name">Excel工作页与对应的数据头</param>
        /// <returns>数据返回</returns>
        public Model.ReturnDataModel ImpExcelData(string _excelPath, List<string> _sheet_Name = null)
        {
            Model.ReturnDataModel rdm = new Model.ReturnDataModel();
            try
            {
                string RandomString = string.Empty;
                if (_sheet_Name == null)
                {
                    RandomString = System.Guid.NewGuid().ToString();
                    _sheet_Name = new List<string>();
                    _sheet_Name.Add(RandomString);
                }
                DataSet ds = new DataSet();
                //设置工作组对象
                IWorkbook workbook = null;
                //获取后缀名
                string extName = Path.GetExtension(_excelPath);
                var stream = new FileStream(_excelPath, FileMode.Open, FileAccess.Read);
                //95~03
                if (extName.ToLower().Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(stream);
                }
                //03以上
                if (extName.ToLower().Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook(stream);
                }
                //无数据时
                foreach (var item in _sheet_Name)
                {
                    DataTable dt = new DataTable(item);
                    HSSFSheet _ISheet = null;
                    //获取工作版
                    if (string.IsNullOrWhiteSpace(RandomString))
                    {
                        _ISheet = workbook.GetSheet(item) as HSSFSheet;
                    }
                    else
                    {
                        _ISheet = workbook.GetSheetAt(0) as HSSFSheet;
                    }
                    HSSFRow hssf_title = _ISheet.GetRow(0) as HSSFRow;
                    int cells = hssf_title.LastCellNum;
                    int rows = hssf_title.Sheet.LastRowNum;
                    //标题
                    for (int i = hssf_title.FirstCellNum; i < cells; i++)
                    {
                        HSSFCell cell = hssf_title.GetCell(i) as HSSFCell;
                        if (cell != null)
                        {
                            DataColumn dc = new DataColumn(hssf_title.Cells[i].StringCellValue);
                            dt.Columns.Add(dc);
                        }
                    }
                    //获取数据
                    for (int i = (_ISheet.FirstRowNum + 1); i <= rows; i++)
                    {
                        HSSFRow hssf_data = _ISheet.GetRow(i) as HSSFRow;
                        DataRow dr = dt.NewRow();
                        if (hssf_data != null)
                        {
                            for (int j = hssf_data.FirstCellNum; j < cells; j++)
                            {
                                HSSFCell cell = hssf_data.GetCell(j) as HSSFCell;
                                if (cell != null)
                                {
                                    //dr[j] = cell.StringCellValue;
                                    dr[j] = cell.ToString();
                                }
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
                rdm.Status = true;
                rdm.Data = ds;
                return rdm;
            }
            catch (Exception ex)
            {
                rdm.Status = false;
                rdm.Msg = ex.StackTrace + "\r\n" + ex.Message;
                return rdm;
            }
        }

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="_ds_Excel_Data">需要导出的数据</param>
        /// <param name="_dic_Excel_Head">需要导出的Excel标题</param>
        /// <param name="_sheet_Name">Sheet名称</param>
        /// <param name="_excel_Name">导出Excel文件名</param>
        /// <param name="_excel_Path">导出Excel文件位置</param>
        /// <returns>
        /// 导出文件路径
        /// </returns>
        public Model.ReturnDataModel ExpExcelData(System.Data.DataSet _ds_Excel_Data, Dictionary<string, string> _dic_Excel_Head = null,
            List<string> _sheet_Name = null, string _excel_Name = null, string _excel_Path = null)
        {
            Model.ReturnDataModel rdm = new Model.ReturnDataModel();
            try
            {
                #region 数据验证
                if (string.IsNullOrWhiteSpace(_excel_Path))
                {
                    _excel_Path = Path.GetTempPath();
                }
                if (string.IsNullOrWhiteSpace(_excel_Name))
                {
                    _excel_Name = System.Guid.NewGuid().ToString();
                }
                if (_sheet_Name == null)
                {
                    _sheet_Name = new List<string>();
                    _sheet_Name.Add("Sheet One");
                }
                if (!System.IO.Directory.Exists(_excel_Path))
                {
                    System.IO.Directory.CreateDirectory(_excel_Path).Attributes = FileAttributes.NotContentIndexed;
                }
                if (_excel_Path[_excel_Path.Length - 1] != '\\')
                {
                    _excel_Path += @"\";
                }
                #endregion
                #region 初始化新的Excel文件属性
                //在内存创建一个新的Excel文件
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                string info = "Object Yan";
                //创建文档的摘要信息
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = info;
                hssfworkbook.DocumentSummaryInformation = dsi;
                //创建摘要信息
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Subject = info;
                si.Author = info;
                si.ApplicationName = info;
                si.CreateDateTime = DateTime.Now;
                si.OSVersion = 1;
                hssfworkbook.SummaryInformation = si;
                #endregion

                #region 创建单元格并填充数据
                foreach (var sn_item in _sheet_Name)
                {
                    //在Excel中创建一个Sheet空间
                    HSSFSheet sheet = hssfworkbook.CreateSheet(sn_item) as HSSFSheet;
                    //创建Excel第一行
                    //列
                    int i = 0;
                    HSSFRow row_one = sheet.CreateRow(0) as HSSFRow;
                    int j = 1;
                    DataTable dt = null;
                    if (sn_item.Equals("Sheet One"))
                    {
                        dt = _ds_Excel_Data.Tables[0];
                    }
                    else
                    {
                        dt = _ds_Excel_Data.Tables[sn_item];
                    }
                    foreach (DataRow dr_item in dt.Rows)
                    {
                        HSSFRow row = sheet.CreateRow(j) as HSSFRow;
                        i = 0;
                        if (_dic_Excel_Head != null)
                        {
                            foreach (var item in _dic_Excel_Head)
                            {
                                if (j == 1)
                                {
                                    HSSFRichTextString hrts = new HSSFRichTextString(item.Value);
                                    row_one.CreateCell(i).SetCellValue(hrts.String);
                                }
                                string value = Convert.ToString(dr_item[item.Key]);
                                int width = sheet.GetColumnWidth(i);
                                int set_width = (value.Length + 1) * 256;
                                if (set_width > width)
                                {
                                    sheet.SetColumnWidth(i, set_width);
                                }
                                row.CreateCell(i).SetCellValue(value);
                                i++;
                            }
                        }
                        else
                        {
                            foreach (DataColumn item in dt.Columns)
                            {
                                if (j == 1)
                                {
                                    HSSFRichTextString hrts = new HSSFRichTextString(item.ColumnName);
                                    row_one.CreateCell(i).SetCellValue(hrts.String);
                                }
                                string value = Convert.ToString(dr_item[item.ColumnName]);
                                int width = sheet.GetColumnWidth(i);
                                int set_width = (value.Length + 1) * 256;
                                if (set_width > width)
                                {
                                    sheet.SetColumnWidth(i, set_width);
                                }
                                row.CreateCell(i).SetCellValue(value);
                                i++;
                            }
                        }
                        j++;
                    }
                }
                #endregion

                #region 将内存中的Excel写入物理存储空间

                string path = _excel_Path + _excel_Name + ".xls";
                FileStream file = new FileStream(path, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                #endregion

                rdm.Status = true;
                rdm.Data = path;
                return rdm;
            }
            catch (Exception ex)
            {
                rdm.Status = false;
                rdm.Msg = ex.StackTrace + "\r\n" + ex.Message;
                return rdm;
            }
        }
    }
}
