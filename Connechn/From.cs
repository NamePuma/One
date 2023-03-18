using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connechn
{
    public class From
    {
        
        private string name;
        private string teacher;

      
        public string Name { get { return name; } private set { name = value; } }

        public string Teacher { get { return teacher;} private set { teacher = value; } }

        public From( string name, string teacher) {

            Name = name;
            Teacher = teacher;
        
        }
        

    }
}
