using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connechn
{
    public class RoleIO
    {
        private string name; 
        public string Name { get { return name;  } private set { name = value; } }

        public RoleIO(string name)
        {
            Name = name;
        }



    }
}
