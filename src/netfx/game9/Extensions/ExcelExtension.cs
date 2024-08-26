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
                                    var value = reader[i].ToString().Replace(" ", "");
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
    }
}
