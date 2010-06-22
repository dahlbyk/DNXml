using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public class DXAttribute : DXObject<XAttribute>
    {
        public DXAttribute(XAttribute attribute) : base(attribute)
        {
        }

        protected override Func<XAttribute, object> GetConverterForType(Type type)
        {
            return converters.GetOrDefault(type);
        }

        static Dictionary<Type, Func<XAttribute, object>> converters = new Dictionary<Type, Func<XAttribute, object>>
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
