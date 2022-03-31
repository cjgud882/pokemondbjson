using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pokemonjson
{
    class pokemon
    {
        
        public int m_hp { get; set; }
        public int m_dmg { get; set; }
        public string m_name { get; set; }
        public string m_ability { get; set; }

    }
}
