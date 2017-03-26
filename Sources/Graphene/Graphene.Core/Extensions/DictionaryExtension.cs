using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphene.Core.Extensions
{
    public static class DictionaryExtension
    {
        public static T Get<T>(this Dictionary<string, object> dic, string name, T def)
        {
            if (dic.ContainsKey(name))
                return (T)dic[name];
            return def;
        }
    }
}
