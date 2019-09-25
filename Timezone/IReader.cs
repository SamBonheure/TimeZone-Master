using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    interface IReader<T, T2>
    {
        List<Tuple<T, T2>> Read();
    }
}
