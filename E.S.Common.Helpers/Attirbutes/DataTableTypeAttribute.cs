using System;
using System.Collections.Generic;
using System.Text;

namespace E.S.Common.Helpers.Attirbutes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTableTypeAttribute : Attribute
    {
        public DataTableTypeAttribute(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        public Type Type { get; }
        public string Name { get; }
    }
}
