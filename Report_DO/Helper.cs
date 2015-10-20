using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Report_DO
{
    public class Helper
    {
        private static IDictionary<string, PropertyInfo[]> propertiesCache = new Dictionary<string, PropertyInfo[]>();

        // Help with locking

        private static ReaderWriterLockSlim propertiesCacheLock = new ReaderWriterLockSlim();

        /// <summary>

        /// Get an array of PropertyInfo for this type

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <returns>PropertyInfo[] for this type</returns>

        public static PropertyInfo[] GetCachedProperties<T>()
        {
            if (propertiesCacheLock.TryEnterUpgradeableReadLock(100))
            {
                PropertyInfo[] props;
                try
                {
                    if (!propertiesCache.TryGetValue(typeof(T).FullName, out props))
                    {

                        props = typeof(T).GetProperties();

                        if (propertiesCacheLock.TryEnterWriteLock(100))
                        {

                            try
                            {

                                propertiesCache.Add(typeof(T).FullName, props);

                            }

                            finally
                            {

                                propertiesCacheLock.ExitWriteLock();

                            }

                        }

                    }

                }

                finally
                {

                    propertiesCacheLock.ExitUpgradeableReadLock();

                }

                return props;

            }

            return typeof(T).GetProperties();
        }

        public static T GetAs<T>(SqlDataReader reader)
        {

            // Create a new Object

            T newObjectToReturn = Activator.CreateInstance<T>();

            // Get all the properties in our Object

            PropertyInfo[] props = GetCachedProperties<T>();

            // For each property get the data from the reader to the object

            List<string> columnList = GetColumnList(reader);

            foreach (var t in props.Where(t => columnList.Contains(t.Name) && reader[t.Name] != DBNull.Value))
            {
                typeof(T).InvokeMember(t.Name, BindingFlags.SetProperty, null, newObjectToReturn, new[] { reader[t.Name] });
            }
            return newObjectToReturn;
        }

        public static List<string> GetColumnList(SqlDataReader reader)
        {

            var columnList = new List<string>();

            System.Data.DataTable readerSchema = reader.GetSchemaTable();

            for (int i = 0; i < readerSchema.Rows.Count; i++)
                columnList.Add(readerSchema.Rows[i]["ColumnName"].ToString());

            return columnList;
        }
    }
}
