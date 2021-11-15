using E.S.Common.Helpers.Attirbutes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace E.S.Common.Helpers.Extensions
{
    public static class CollectionExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> items)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            var table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];

            foreach (T item in items)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item);

                table.Rows.Add(values);
            }
            return table;
        }

        public static DataTable ToDataTableAdvance<T>(this IList<T> items)
        {
            var table = new DataTable();

            if (!items.Any())
                return table;

            var firstItem = items[0];

            var properties = firstItem.GetType().GetProperties();

            foreach (var property in firstItem.GetType().GetProperties())
            {
                var pType = property.PropertyType;

                var dataTableType = property.GetCustomAttributes(typeof(DataTableTypeAttribute), false).Cast<DataTableTypeAttribute>().FirstOrDefault();

                if (dataTableType != null)
                    table.Columns.Add(dataTableType.Name ?? property.Name, dataTableType.Type);
                else
                    table.Columns.Add(property.Name, pType);
            }

            object[] values = new object[properties.Length];

            foreach (T item in items)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = properties[i].GetValue(item);

                table.Rows.Add(values);
            }

            return table;
        }

        public static IEnumerable<IEnumerable<TSource>> ToBatches<TSource>(
                  this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];

                bucket[count++] = item;
                if (count != size)
                    continue;

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket != null && count > 0)
                yield return bucket.Take(count).ToArray();
        }
    }
}
