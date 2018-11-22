using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    [Serializable]
   public class Owner
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Owner(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"Id:{Id} -Name:{Name}";
        }
    }
}
