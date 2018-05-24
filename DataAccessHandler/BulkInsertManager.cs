using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccessHandler
{
    public class BulkInsertManager
    {
        public static void SqlBulkCopy(SqlConnection connection, DataTable table, string destinationTable)
        {
            connection.Open();

            try
            {
                var sqlBulkCopy = new SqlBulkCopy(connection);
                sqlBulkCopy.DestinationTableName = destinationTable;

                foreach (DataColumn column in table.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void SqlBulkCopy<T>(SqlConnection connection, IEnumerable<T> objects, string destinationTable)
        {
            try
            {
                var sqlBulkCopy = new SqlBulkCopy(connection);
                sqlBulkCopy.DestinationTableName = destinationTable;

                var table = ConvertToDataTable<T>(objects);

                foreach (DataColumn column in table.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable ConvertToDataTable<T>(IEnumerable<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }
}