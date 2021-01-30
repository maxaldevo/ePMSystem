using ExcelDataReader;
using ePM.Dal;
using ePM_Dal;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;

namespace MS.DAL.Utils
{
    /// <summary>
    /// this class contains helper methods to facilitate all Excel Import functions
    /// </summary>
    public static class ExcelImportManager
    {
        /// <summary>
        /// returns datatable from Excel file steam
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static DataTable GetDTFromExcelFile(Stream stream)
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            }).Tables[0];
            excelReader.Close();
            stream.Close();
            return result;
        }
        /// <summary>
        /// returns streams from Excel file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Stream GetStreamFromFile(string filePath)
        {
          Stream  stream = new FileStream(filePath, FileMode.Open);
            return stream;
        }
        /// <summary>
        /// converts List<Object> to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// Returns dynamic List from Excel stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DataTable GetValidDataTableFromExcel(Stream stream,string user)
        {
            DataTable dt = new DataTable();
            List<u_TRRoom> roomsList = new List<u_TRRoom>();
            try
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                }).Tables[0];// get the first sheet data with index 0
                decimal totalRows = result.Rows.Count;
                foreach (DataRow dr in result.Rows)
                {
                    decimal index = result.Rows.IndexOf(dr);
                    if (!string.IsNullOrWhiteSpace(dr["Location"].ToString()) && !string.IsNullOrWhiteSpace(dr["Capacity"].ToString()) && !string.IsNullOrWhiteSpace(dr["Notes"].ToString()) )
                    {
                        if (!int.TryParse( dr["Capacity"].ToString(),out int x))
                        {
                            roomsList.Clear();
                           break;
                        }
                        else
                        {
                            u_TRRoom roomRow = new u_TRRoom()
                            {
                                Capacity = int.Parse(dr["Capacity"].ToString()),
                                Status = "Active",
                                UpdatedBy = user,
                                LastUpdated = DateTime.Now,
                                Notes = dr["Notes"].ToString(),
                                Location = dr["Location"].ToString()
                            };
                            roomsList.Add(roomRow);
                        }
                       
                    }
                }
               
                excelReader.Close();
                stream.Close();
                if (roomsList.Count > 0)
                {
                    dt = Utils.ExcelImportManager.ToDataTable(roomsList);
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);
                }
              
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
            }
            finally
            {
                stream.Close();
            }
            return dt;
        }
        /// <summary>
        /// Returns Invalid rows
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<int> GetInvalidRoomRowsFromExcel(Stream stream)
        {
            List<int> InvalidRows = new List<int>();
            List<u_TRRoom> roomsList = new List<u_TRRoom>();
            try
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                }).Tables[0];// get the first sheet data with index 0
                decimal totalRows = result.Rows.Count;
                foreach (DataRow dr in result.Rows)
                {
                    int index = result.Rows.IndexOf(dr);
                    if (!string.IsNullOrWhiteSpace(dr["Location"].ToString()) && !string.IsNullOrWhiteSpace(dr["Capacity"].ToString()) && !string.IsNullOrWhiteSpace(dr["Notes"].ToString()))
                    {
                        if (!int.TryParse(dr["Capacity"].ToString(), out int x))
                        {
                            InvalidRows.Add(index + 2);
                        }
                    }
                }

                excelReader.Close();
                stream.Close();


            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
            }
            finally
            {
                stream.Close();
            }
            return InvalidRows;
        }
        /// <summary>
        /// This Function Takes a datatable and table name and make dynamic column mapping 
        /// then bulk upload data into db and returns number of inserted rows or the exception message
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string UploadBulkData(DataTable dt,string tableName)
        {
            //this function now will work dynamically
            //try to report the progress later
            string insertedRowCount = "0";
            try
            {
                if (dt.Rows.Count>0)
                {
                    string consString = ConfigurationManager.ConnectionStrings["KipicAzure"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.CheckConstraints))
                        {

                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = tableName;// "dbo.u_TRRoom";
                            #region optional column mapping
                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            // sqlBulkCopy.ColumnMappings.Add("Id", "PersonnelId");
                            //sqlBulkCopy.ColumnMappings.Add("Location", "Location");
                            //sqlBulkCopy.ColumnMappings.Add("Capacity", "Capacity");
                            //sqlBulkCopy.ColumnMappings.Add("Notes", "Notes");
                            //sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                            //sqlBulkCopy.ColumnMappings.Add("LastUpdated", "LastUpdated");
                            //sqlBulkCopy.ColumnMappings.Add("UpdatedBy", "UpdatedBy");
                            #endregion 
                            foreach (DataColumn col in dt.Columns)
                            {
                                sqlBulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                            }

                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            insertedRowCount= SqlBulkCopyHelper.GetRowsCopied(sqlBulkCopy).ToString();
                            con.Close();
                        }
                    }
                  
                }
               
            }
            catch (Exception ex)
            {

                ExceptionsManager.AddException(ex);
                insertedRowCount = ex.Message;
                String innerMessage = (ex.InnerException != null)
                      ? ex.InnerException.Message
                      : "";
                if (innerMessage!="")
                {
                    insertedRowCount += " _ " + innerMessage;
                }
            }
            return insertedRowCount;
        }
        /// <summary>
        /// Obsolete, Download Excel File, so far it downloads the file, but it seems to be corrupt?
        /// </summary>
        /// <param name="contex"></param>
        /// <param name="file"></param>
        public static string DownloadExcelTemplate(HttpContext contex, string file)
        {
            string output = "";
            HttpResponse response = contex.Response;
            try
            {
                FileInfo fileInfo = new FileInfo(contex.Server.MapPath(file));

                response.Clear();
                response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                // response.AddHeader("Content-Length", fileInfo.Length.ToString());
                if (fileInfo.Extension ==".xls")
                {
                    response.ContentType = "application/excel";
                }
                else if (fileInfo.Extension == ".xlsx")
                {
                    response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                response.Flush();
                response.TransmitFile(fileInfo.FullName);
                response.SuppressContent = true;
                contex.ApplicationInstance.CompleteRequest();
                response.Close();
                output = "Success";
            }
            catch (Exception ex)
            {

                ExceptionsManager.AddException(ex);
                output = ex.Message;
                String innerMessage = (ex.InnerException != null)
                      ? ex.InnerException.Message
                      : "";
                if (innerMessage != "")
                {
                    output += " _ " + innerMessage;
                }
            }
            return output;
        }
        /// <summary>
        /// Create number only cell with min and max
        /// </summary>
        /// <param name="package"></param>
        /// <param name="columnName"></param>
        /// <param name="colTitle"></param>
        /// <param name="promptTitle"></param>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void AddIntCell(ExcelPackage package, string columnName, string colTitle, string promptTitle, string prompt,int min, int max)
        {
            string validationRange = string.Concat(columnName + 2, ":", columnName + 10000);//validation for all cell
            columnName = string.Concat(columnName, 1);//strat from first column
            var validation = package.Workbook.Worksheets[0].DataValidations.AddIntegerValidation(validationRange);
            package.Workbook.Worksheets[0].Cells[columnName].Value = colTitle;
            validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            validation.ShowInputMessage = true;
            validation.PromptTitle = promptTitle;
            validation.Prompt = prompt;
            validation.ShowErrorMessage = true;
            validation.Formula.Value = min;
            validation.Formula2.Value = max;
            //If the cells are not filled, allow blanks or fill with a valid value, 
            //otherwise it could generate a error when saving 
            validation.AllowBlank = true;
        }
        public static void AddPhoneCell(ExcelPackage package, string columnName, string colTitle, string promptTitle, string prompt)
        {
            string validationRange = string.Concat(columnName, ":", columnName);
            columnName = string.Concat(columnName, 1);
            var validation = package.Workbook.Worksheets[0].DataValidations.AddTextLengthValidation(validationRange);
            package.Workbook.Worksheets[0].Cells[columnName].Value = colTitle;
            validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            validation.ShowInputMessage = true;
            validation.PromptTitle = promptTitle;
            validation.Prompt = prompt;
            validation.ShowErrorMessage = true;
            validation.Formula.Value = 8;
            validation.Formula2.Value = 8;

        }
        /// <summary>
        /// three to five chars. CURRENTLY NOT AS PLANNED
        /// </summary>
        /// <param name="package"></param>
        /// <param name="columnName"></param>
        /// <param name="colTitle"></param>
        /// <param name="endRange"></param>
        /// <param name="promptTitle"></param>
        /// <param name="prompt"></param>
        public static void AddTextCellWithPrompt(ExcelPackage package, string columnName, string colTitle, int endRange, string promptTitle, string prompt)
        {
            string validationRange = string.Concat(columnName + 2, ":", columnName + endRange);
            columnName = string.Concat(columnName, 1);
            var validation = package.Workbook.Worksheets[0].DataValidations.AddTextLengthValidation(validationRange);
            package.Workbook.Worksheets[0].Cells[columnName].Value = colTitle;
            validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            validation.ShowInputMessage = true;
            validation.PromptTitle = promptTitle;
            validation.Prompt = prompt;
            validation.ShowErrorMessage = true;
            validation.Formula.Value = 3;
            validation.Formula2.Value = 5;

        }
        public static void AddTextCell(ExcelPackage package, string columnName, string colTitle)
        {
            columnName = string.Concat(columnName, 1);
            package.Workbook.Worksheets[0].Cells[columnName].Value = colTitle;
        }

    }
}