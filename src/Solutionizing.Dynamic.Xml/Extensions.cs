using System.Collections.Generic;
using System.Xml.Linq;

namespace Solutionizing.Dynamic.Xml
{
    public static class Extensions
    {
        public static dynamic AsDynamic(this XDocument @this)
        {
            return new DXDocument(@this);
        }

        public static dynamic AsDynamic(this XElement @this)
        {
            return new DXElement(@this);
        }

        public static dynamic AsDynamic(this XAttribute @this)
        {
            return new DXAttribute(@this);
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key)
        {
            TValue value;
            @this.TryGetValue(key, out value);
            return value;
        }
    }
}
