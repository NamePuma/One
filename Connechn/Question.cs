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

        private int id;
        private CreateQuestion content;
        private int from;
        private string type;

        public int Id { get { return id;} set { id = value; } }
        public CreateQuestion Content { get { return content; } private set { content = value; } }

        public int From { get { return from; } private set { from = value; } }

        public string Type { get { return type; } set { type = value; } }
        public Question(int id, CreateQuestion content, int from, string type)
        {
            Id = id;
            Content = content;
            From = from;
            Type = type;
        }
    }
}
