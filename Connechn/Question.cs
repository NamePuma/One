using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Connechn
{
    public  class Question
    {
        

        private JsonObject content;
        private int from;

        private string type;

        


        public JsonObject Content { get { return content; } private set { content = value; } }

        public int From { get { return from; } private set { from = value; } }

        public string Type { get { return type; } set { type = value; } }
        public Question(int id, JsonObject content, int from, string type)
        {

            
            Content = content;
            From = from;
            Type = type;

        }
        
        



    }
}
