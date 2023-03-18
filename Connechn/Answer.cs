using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Connechn
{
    public class Answer
    {
        private int id; 
        private string student;
        private int questions;
        private JsonObject content;
        private DateTime date; 

        public int Id { get { return id; } private set { id = value; } }
        public string Student { get { return student; } private set { student = value; } }

        public int Questions { get { return questions; } private set { questions = value; } }
        public JsonObject Content { get { return content; } private set { content = value; } }

        public DateTime Date { get { return date; } private set { date = value; } }

        public Answer(int id, string student, int questions, JsonObject content, DateTime  date)
        {
            Id = id;
            Student = student;
            Questions = questions;
            Content = content;
             Date = date; 

           


        }


    }
}
