﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public class DXElement : DXContainer<XElement>
    {
        public DXElement(XElement element)
            : base(element)
        {
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                result = GetAttribute(indexes[0]).AsDynamic();
                return true;
            }
            return base.TryGetIndex(binder, indexes, out result);
        }

        XAttribute GetAttribute(object index)
        {
            if (index is string)
                return inner.Attribute((string)index);

            if (index is int)
                return inner.Attributes().ElementAtOrDefault((int)index);

            return null;
        }

        protected override Func<XElement, object> GetConverterForType(Type type)
        {
            return converters.GetOrDefault(type);
        }

        static Dictionary<Type, Func<XElement, object>> converters = new Dictionary<Type, Func<XElement, object>>
        {
            { typeof(DateTime), x => (DateTime)x },
            { typeof(DateTime?), x => (DateTime?)x },
            { typeof(DateTimeOffset), x => (DateTimeOffset)x },
            { typeof(DateTimeOffset?), x => (DateTimeOffset?)x },
            { typeof(Guid), x => (Guid)x },
            { typeof(Guid?), x => (Guid?)x },
            { typeof(TimeSpan), x => (TimeSpan)x },
            { typeof(TimeSpan?), x => (TimeSpan?)x },
            { typeof(bool), x => (bool)x },
            { typeof(bool?), x => (bool?)x },
            { typeof(decimal), x => (decimal)x },
            { typeof(decimal?), x => (decimal?)x },
            { typeof(double), x => (double)x },
            { typeof(double?), x => (double?)x },
            { typeof(float), x => (float)x },
            { typeof(float?), x => (float?)x },
            { typeof(int), x => (int)x },
            { typeof(int?), x => (int?)x },
            { typeof(long), x => (long)x },
            { typeof(long?), x => (long?)x },
            { typeof(string), x => (string)x },
            { typeof(uint), x => (uint)x },
            { typeof(uint?), x => (uint?)x },
            { typeof(ulong), x => (ulong)x },
            { typeof(ulong?), x => (ulong?)x }
        };
    }
}
