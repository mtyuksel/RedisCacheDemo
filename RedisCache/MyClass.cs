using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache
{
    [Serializable]
    public class MyClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
