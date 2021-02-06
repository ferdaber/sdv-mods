using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackToMapChests
{
    class ModData
    {
        public Dictionary<string, HashSet<string>> ZoneAreas { get; set; } = new Dictionary<string, HashSet<string>>();
    }
}
