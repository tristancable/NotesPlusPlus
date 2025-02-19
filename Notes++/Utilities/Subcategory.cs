using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Notes__.Utilities
{
    class Subcategory
    {
        public string Name { get; set; }
        public List<Note> notes { get; set; }
        public Subcategory(string name)
        {
            Name = name;
            notes = new List<Note>();
        }
    }
}