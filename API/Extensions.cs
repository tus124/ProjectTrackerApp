using System.Data;
using System.Reflection;
using System.Text;

namespace ProjectTrackerAPI;

public static class Extensions
{
    public static Stream ToStream(this string str)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(str);
        MemoryStream stream = new MemoryStream(byteArray);

        return stream;
    }

    public static List<T> DataReaderMapToList<T>(this IDataReader dr)
    {
        List<T> list = new List<T>();
        T obj = default(T);
        var columns = new HashSet<string>();

        // Build a set of column names for quick lookup
        for (int i = 0; i < dr.FieldCount; i++)
        {
            columns.Add(dr.GetName(i).ToLower());
        }

        while (dr.Read())
        {
            obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                // Check if the column exists in the data reader
                if (columns.Contains(prop.Name.ToLower()))
                {
                    if (!dr.IsDBNull(dr.GetOrdinal(prop.Name)))
                    {
                        // Special handling for DateTime fields
                        if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        {
                            DateTime dateTimeValue = dr.GetDateTime(dr.GetOrdinal(prop.Name));
                            prop.SetValue(obj, dateTimeValue, null);
                        }
                        else
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                }
            }
            list.Add(obj);
        }

        return list;
    }
}
