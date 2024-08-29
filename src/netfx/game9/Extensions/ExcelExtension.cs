using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game9.Extensions
{
    class ExcelExtension
    {
        public static List<TResult> LoadData<TResult>(string filePath, Action<Exception> errorAction=default)
        {
            List<TResult> result = new List<TResult>();

            try
            {

                var propObjs = typeof(TResult).GetProperties();

                using(var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read,FileShare.ReadWrite))                
                {
                    var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(fs);
                    int rowIdx = 0;
                    int fieldCount = reader.FieldCount;
                    Dictionary<string, int> mFieldName = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
                    if(fieldCount>0)
                    {
                        while (reader.Read())
                        {
                            if (rowIdx == 0)
                            {
                                for (int i = 0; i < fieldCount; i++)
                                {
                                    var value = reader[i].ToString().Replace(" ", "").Replace("%","Percent");
                                    mFieldName[value] = i;
                                }                               
                            }
                            else
                            {
                                try
                                {
                                    TResult itemObj = Activator.CreateInstance<TResult>();
                                    foreach (var propObj in propObjs)
                                    {
                                        if (mFieldName.ContainsKey(propObj.Name))
                                        {
                                            var value = reader[mFieldName[propObj.Name]]?.ToString();
                                            propObj.SetValue(itemObj, value);
                                        }
                                    }
                                    result.Add(itemObj);
                                }
                                catch (Exception ex)
                                {
                                    errorAction?.Invoke(ex);
                                }
                                
                            }
                            rowIdx++;
                        }
                    }
                    
                    

                    reader.Close();
                    fs.Close();
                }
                
            }
            catch (Exception ex)
            {
                errorAction?.Invoke(ex);
            }
            return result;
        }

        public static Models.RawDataInfo LoadDataRaw(string filePath, Action<Exception> errorAction = default)
        {
            Models.RawDataInfo result = new Models.RawDataInfo();

            try
            {

                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(fs);
                    int rowIdx = 0;
                    int fieldCount = reader.FieldCount;
                    Dictionary<string, int> mFieldName = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
                    if (fieldCount > 0)
                    {
                        List<int> timeColIdxes = new List<int>();
                        while (reader.Read())
                        {
                            if (rowIdx == 0)
                            {
                                for (int i = 0; i < fieldCount; i++)
                                {
                                    var headerValue = reader[i].ToString().Replace(" ", "").Replace("%", "Percent");
                                    result.Headers[headerValue] = i;
                                    if (headerValue.IndexOf("timestart", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                    {
                                        timeColIdxes.Add(i);
                                    }
                                    else if (headerValue.IndexOf("timeend", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                    {
                                        timeColIdxes.Add(i);                                        
                                    }
                                }
                                if(timeColIdxes.Count > 0)
                                {
                                    int additionIdx = 0;
                                    foreach(var idx in timeColIdxes)
                                    {
                                        var headerValue = reader[idx].ToString().Replace(" ", "").Replace("%", "Percent");
                                        headerValue = $"Date{headerValue.Substring(4)}";
                                        result.Headers[headerValue] = fieldCount+ additionIdx;
                                        additionIdx++;
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    List<string> values = new List<string>();
                                    for (int i = 0; i < fieldCount; i++)
                                    {
                                        var value = reader[i]?.ToString()??"";
                                        values.Add(value);
                                    }

                                    if (timeColIdxes.Count > 0)
                                    {
                                        foreach (var idx in timeColIdxes)
                                        {
                                            var value = reader[idx].ToString();
                                            value = value.Substring(0, 10).Trim();
                                            values.Add(value);
                                        }
                                    }

                                        result.Rows.Add(values);
                                }
                                catch (Exception ex)
                                {
                                    errorAction?.Invoke(ex);
                                }

                            }
                            rowIdx++;
                        }
                    }



                    reader.Close();
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                errorAction?.Invoke(ex);
            }

            return result;
        }
    }
}
