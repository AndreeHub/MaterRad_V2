using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproxiCalc.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetValues<T>() => (T[])Enum.GetValues(typeof(T));
    }
}
