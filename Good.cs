using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    public class Good
    {
        public string Name {  get; set; }
        public string Country { get; set; }
        public float Price { get; set; }
        public Good() { }
        public Good(string name, string country, float price)
        {
            Name = name;
            Country = country;
            Price = price;
        }   
    }
}
