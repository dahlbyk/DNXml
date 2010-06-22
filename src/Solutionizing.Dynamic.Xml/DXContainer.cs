using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public abstract class DXContainer<T> : DXObject<T> where T : XContainer
    {
        public DXContainer(T element) : base(element)
        {
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return inner == null ? Enumerable.Empty<string>() :
                from e in inner.Elements()
                select e.Name.LocalName;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = (inner == null ? null : inner.Element(binder.Name)).AsDynamic();
            return true;
        }
    }
}
