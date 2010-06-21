using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public class DXElement : DynamicObject
    {
        private readonly XElement element;

        public DXElement(XElement element)
        {
            this.element = element;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return element == null ? Enumerable.Empty<string>() :
                from e in element.Elements()
                select e.Name.LocalName;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = element == null ? null : element.Element(binder.Name).AsDynamic();
            return result != null;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type.IsAssignableFrom(typeof(XElement)))
            {
                result = element;
                return true;
            }

            var mapper = typeMap.GetOrDefault(binder.Type);

            if (mapper == null)
                return base.TryConvert(binder, out result);

            result = mapper(element);
            return true;
        }

        static Dictionary<Type, Func<XElement, object>> typeMap = new Dictionary<Type, Func<XElement, object>>
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
