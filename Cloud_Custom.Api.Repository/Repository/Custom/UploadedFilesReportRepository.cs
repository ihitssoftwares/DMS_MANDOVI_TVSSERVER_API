using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class UploadedFilesReportRepository : IUploadedFilesReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly HttpClient _httpClient;
        public UploadedFilesReportRepository(ISqlConnectionProvider sql, HttpClient httpClient)
        {
            _sql = sql;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(120);
        }
        public async Task<UploadedFilesReport> GetList(
    UserBase user,
    string module,
    string month)
        {
            try
            {
                // =========================================
                // STEP 1: GET FOLDER PATH
                // =========================================

                IDbDataParameter[] pathParams =
                {
            new SqlParameter("@ModuleName", module),
            new SqlParameter("@Month", month)
        };

                var ds = await _sql.GetDataSetAsync(
                    "[DMS].[SP_UPLOADED_FILES_GET_PATH]",
                    pathParams
                );

                if (ds == null || ds.Tables.Count == 0)
                {
                    return new UploadedFilesReport
                    {
                        Module = module,
                        Month = month,
                        List = new List<UploadedFilesReportList>(),
                        PythonTotalFiles = 0,
                        TableTotalFiles = 0
                    };
                }


                // =========================================
                // STEP 2: GET FOLDER PATH
                // =========================================

                string folderPath = "";

                if (ds.Tables[0].Rows.Count > 0)
                {
                    folderPath = Convert.ToString(
                        ds.Tables[0].Rows[0]["FolderPath"]
                    );
                }

                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    return new UploadedFilesReport
                    {
                        Module = module,
                        Month = month,
                        List = new List<UploadedFilesReportList>(),
                        PythonTotalFiles = 0,
                        TableTotalFiles = 0
                    };
                }


                // =========================================
                // STEP 3: PYTHON PAYLOAD
                // =========================================

                var payload = new
                {
                    //module_name = module,
                    //month = month,
                    folderpath = folderPath
                };

                string jsonPayload =
                    JsonConvert.SerializeObject(payload);


                // =========================================
                // STEP 4: CALL PYTHON
                // =========================================

                var content = new StringContent(
                    jsonPayload,
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.PostAsync(
                    "http://127.0.0.1:5050/api/uploadedfilescount",
                    content
                );

                string responseContent =
                    await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    return new UploadedFilesReport
                    {
                        Module = module,
                        Month = month,
                        List = new List<UploadedFilesReportList>(),
                        PythonTotalFiles = 0,
                        TableTotalFiles = 0
                    };
                }


                // =========================================
                // STEP 5: READ PYTHON RESPONSE
                // =========================================

                dynamic pythonResponse =
                    JsonConvert.DeserializeObject<dynamic>(
                        responseContent
                    );


                int pythonTotalFiles = 0;

                if (pythonResponse.total_files != null)
                {
                    pythonTotalFiles =
                        Convert.ToInt32(
                            pythonResponse.total_files
                        );
                }


                List<string> pythonFileNames = new List<string>();

                if (pythonResponse.files != null)
                {
                    pythonFileNames =
                        JsonConvert.DeserializeObject<List<string>>(
                            pythonResponse.files.ToString()
                        );
                }

                // =========================================
                // STEP 6: SEND PYTHON FILE NAMES
                // TO NEW SP
                // =========================================

                string fileNamesJson =
                    JsonConvert.SerializeObject(
                        pythonFileNames
                    );


                IDbDataParameter[] compareParams =
                {
            new SqlParameter("@ModuleName", module),

            new SqlParameter(
                "@FileNames",
                fileNamesJson
            )
        };


                var compareDs =
                    await _sql.GetDataSetAsync(
                        "[DMS].[SP_UPLOADED_FILES_COMPARE]",
                        compareParams
                    );


                // =========================================
                // STEP 7: READ COMPARISON RESULT
                // =========================================

                var result =
                    new UploadedFilesReport
                    {
                        Module = module,
                        Month = month,
                        List = new List<UploadedFilesReportList>(),
                        PythonTotalFiles = pythonTotalFiles,
                        TableTotalFiles = 0
                    };


                if (compareDs != null &&
                    compareDs.Tables.Count > 0)
                {
                    foreach (DataRow row in compareDs.Tables[0].Rows)
                    {
                        result.List.Add(
                            new UploadedFilesReportList
                            {
                                ServerFileName =
                                    Convert.ToString(
                                        row["ServerFileName"]
                                    ),

                                IsFileExists =
                                    Convert.ToBoolean(
                                        row["IsFileExists"]
                                    )
                            }
                        );
                    }
                }


                // =========================================
                // STEP 8: TABLE TOTAL
                // =========================================

                //if (compareDs != null &&
                //    compareDs.Tables.Count > 1 &&
                //    compareDs.Tables[1].Rows.Count > 0)
                //{
                //    result.TableTotalFiles =
                //        Convert.ToInt32(
                //            compareDs.Tables[1]
                //                .Rows[0]["TableTotalFiles"]
                //        );
                //}
                // =========================================
                // STEP 8: TOTAL FILES
                // =========================================

                //if (compareDs != null &&
                //    compareDs.Tables.Count > 1 &&
                //    compareDs.Tables[1].Rows.Count > 0)
                //{
                //    result.PythonTotalFiles =
                //        Convert.ToInt32(
                //            compareDs.Tables[1]
                //                .Rows[0]["ServerTotalFiles"]
                //        );

                //    result.TableTotalFiles =
                //        Convert.ToInt32(
                //            compareDs.Tables[1]
                //                .Rows[0]["TableTotalFiles"]
                //        );
                //}
                if (compareDs != null &&
    compareDs.Tables.Count > 1 &&
    compareDs.Tables[1].Rows.Count > 0)
                {
                    result.TableTotalFiles =
                        Convert.ToInt32(
                            compareDs.Tables[1]
                                .Rows[0]["TableTotalFiles"]
                        );
                }


                return result;
            }
            catch (Exception ex)
            {
                return new UploadedFilesReport
                {
                    Module = module,
                    Month = month,
                    List = new List<UploadedFilesReportList>(),
                    PythonTotalFiles = 0,
                    TableTotalFiles = 0
                };
            }
        }
    }
}