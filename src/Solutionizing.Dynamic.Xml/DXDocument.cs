using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public class DXDocument : DXContainer<XDocument>
    {
        public DXDocument(XDocument element)
            : base(element)
        {
        }

        protected override Func<XDocument, object> GetConverterForType(Type type)
        {
            return null;
        }
    }
}
