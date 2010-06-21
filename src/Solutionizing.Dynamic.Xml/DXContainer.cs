using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public abstract class DXContainer<T> : DynamicObject where T : XContainer
    {
        private readonly T element;

        public DXContainer(T element)
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
            if (binder.Type.IsAssignableFrom(typeof(T)))
            {
                result = element;
                return true;
            }

            var converter = GetConverterForType(binder.Type);

            if (converter == null)
                return base.TryConvert(binder, out result);

            result = converter(element);
            return true;
        }

        protected abstract Func<T, object> GetConverterForType(Type type);
    }
}
