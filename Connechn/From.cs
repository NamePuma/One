using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connechn
{
    public class From
    {
        private int id;
        private string name;
        private string teacher;

        public int Id { get { return id; } private set { id = value; } }
        public string Name { get { return name; } private set { name = value; } }

        public string Teacher { get { return teacher;} private set { teacher = value; } }

        public From(int id, string name, string teacher) 
        {
            Id = id;
            Name = name;
            Teacher = teacher;
        
        }
        

    }
}
