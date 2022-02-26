using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using YL.Utils.Reflection;

namespace YL.Utils.Extensions
{
    public static class CollectionExt
    {
        public static List<T> EmitToList<T>(this DataTable dt)
        {
            //确认参数有效
            if (dt == null)
                return null;

            List<T> list = new List<T>();
            var objBuilder = EmitUtil.CreateBuilder(typeof(T));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //创建泛型对象
                T _t = (T)objBuilder();
                //获取对象所有属性
                PropertyInfo[] propertyInfo = _t.GetType().GetProperties();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    foreach (PropertyInfo info in propertyInfo)
                    {
                        //属性名称和列名相同时赋值
                        if (dt.Columns[j].ColumnName.ToUpper().Equals(info.Name.ToUpper()))
                        {
                            if (dt.Rows[i][j] != DBNull.Value)
                            {
                                info.SetValue(_t, dt.Rows[i][j], null);
                            }
                            else
                            {
                                info.SetValue(_t, null, null);
                            }
                            break;
                        }
                    }
                }
                list.Add(_t);
            }
            return list;
        }

        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> list = new List<T>();

            //确认参数有效,若无效则返回Null
            if (dt == null)
                return list;
            else if (dt.Rows.Count == 0)
                return list;

            Dictionary<string, string> dicField = new Dictionary<string, string>();
            Dictionary<string, string> dicProperty = new Dictionary<string, string>();
            Type type = typeof(T);

            //创建字段字典，方便查找字段名
            type.GetFields().ForEach(aFiled =>
            {
                dicField.Add(aFiled.Name.ToLower(), aFiled.Name);
            });

            //创建属性字典，方便查找属性名
            type.GetProperties().ForEach(aProperty =>
            {
                dicProperty.Add(aProperty.Name.ToLower(), aProperty.Name);
            });

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //创建泛型对象
                T _t = Activator.CreateInstance<T>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string memberKey = dt.Columns[j].ColumnName.ToLower();

                    //字段赋值
                    if (dicField.ContainsKey(memberKey))
                    {
                        FieldInfo theField = type.GetField(dicField[memberKey]);
                        var dbValue = dt.Rows[i][j];
                        if (dbValue.GetType() == typeof(DBNull))
                            dbValue = null;
                        if (dbValue != null)
                        {
                            Type memberType = theField.FieldType;
                            if (memberType.IsGenericType && memberType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                NullableConverter newNullableConverter = new NullableConverter(memberType);
                                dbValue = newNullableConverter.ConvertFrom(dbValue);
                            }
                            else
                            {
                                dbValue = Convert.ChangeType(dbValue, memberType);
                            }
                        }
                        theField.SetValue(_t, dbValue);
                    }
                    //属性赋值
                    if (dicProperty.ContainsKey(memberKey))
                    {
                        PropertyInfo theProperty = type.GetProperty(dicProperty[memberKey]);
                        var dbValue = dt.Rows[i][j];
                        if (dbValue.GetType() == typeof(DBNull))
                            dbValue = null;
                        if (dbValue != null)
                        {
                            Type memberType = theProperty.PropertyType;
                            if (memberType.IsGenericType && memberType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                NullableConverter newNullableConverter = new NullableConverter(memberType);
                                dbValue = newNullableConverter.ConvertFrom(dbValue);
                            }
                            else
                            {
                                dbValue = Convert.ChangeType(dbValue, memberType);
                            }
                        }
                        theProperty.SetValue(_t, dbValue);
                    }
                }
                list.Add(_t);
            }
            return list;
        }

        public static DataTable ToDataTable(this IEnumerable<ExpandoObject> dataList)
        {
            DataTable dt = new DataTable();
            if (dataList.IsEmpty())
                return null;
            else if (dataList.Count() == 0)
                return dt;
            else
            {
                var aEntity = dataList.FirstOrDefault();
                var properties = aEntity.GetProperties();
                properties.ForEach(aProperty =>
                {
                    dt.Columns.Add(aProperty);
                });
                dataList.ForEach((aData, index) =>
                {
                    dt.Rows.Add(dt.NewRow());
                    properties.ForEach(aProperty =>
                    {
                        dt.Rows[index][aProperty] = aData.GetProperty(aProperty);
                    });
                });
            }

            return dt;
        }

        public static string ToCsvStr(this DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    colum = dt.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum].ToString());
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static DataTable ToDataTable(string tableName, Dictionary<string, Type> columnMappings)
        {
            var table = new DataTable(tableName);
            foreach (var column in columnMappings)
            {
                var dataColumn = new DataColumn(column.Key, column.Value);
                table.Columns.Add(dataColumn);
            }
            return table;
        }
    }
}