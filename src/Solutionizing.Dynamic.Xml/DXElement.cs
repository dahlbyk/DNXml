using System;
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

        protected override Func<XElement, object> GetConverterForType(Type type)
        {
            return converters.GetOrDefault(type);
        }

        static Dictionary<Type, Func<XElement, object>> converters = new Dictionary<Type, Func<XElement, object>>
        {
            { typeof(DateTime), e => (DateTime)e },
            { typeof(DateTime?), e => (DateTime?)e },
            { typeof(DateTimeOffset), e => (DateTimeOffset)e },
            { typeof(DateTimeOffset?), e => (DateTimeOffset?)e },
            { typeof(Guid), e => (Guid)e },
            { typeof(Guid?), e => (Guid?)e },
            { typeof(TimeSpan), e => (TimeSpan)e },
            { typeof(TimeSpan?), e => (TimeSpan?)e },
            { typeof(bool), e => (bool)e },
            { typeof(bool?), e => (bool?)e },
            { typeof(decimal), e => (decimal)e },
            { typeof(decimal?), e => (decimal?)e },
            { typeof(double), e => (double)e },
            { typeof(double?), e => (double?)e },
            { typeof(float), e => (float)e },
            { typeof(float?), e => (float?)e },
            { typeof(int), e => (int)e },
            { typeof(int?), e => (int?)e },
            { typeof(long), e => (long)e },
            { typeof(long?), e => (long?)e },
            { typeof(string), e => (string)e },
            { typeof(uint), e => (uint)e },
            { typeof(uint?), e => (uint?)e },
            { typeof(ulong), e => (ulong)e },
            { typeof(ulong?), e => (ulong?)e }
        };
    }
}
