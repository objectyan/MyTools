using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OY.Common.Model;

namespace OY.Common.Office.Interface
{
    /// <summary>
    /// OFFICE操作之Excel
    /// </summary>
    interface IOfficeExcel
    {
        /*
         * Excel数据导入 ImpExcelData
         * Excel数据导出 ExpExcelData
         */

        /// <summary>
        /// Excel数据导入
        /// </summary>
        /// <param name="_excelPath">Excel文件地址</param>
        /// <param name="_sheet_Name">Excel工作页与对应的数据头</param>
        /// <returns>数据返回</returns>
        ReturnDataModel ImpExcelData(string _excelPath, List<string> _sheet_Name = null);

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
        ReturnDataModel ExpExcelData(System.Data.DataSet _ds_Excel_Data, Dictionary<string, string> _dic_Excel_Head = null,
            List<string> _sheet_Name = null, string _excel_Name = null, string _excel_Path = null);
    }
}
