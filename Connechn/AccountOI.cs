using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connechn
{
    public class AccountOI
    {
        private string login;
        private string password;
        private string firstName; 
        private string lastName;
        private string patronymic;
        private string role;
        private string classForBase;

     

        public string Login { get { return login; } private set { login = value; } }

        public string Password { get { return password; } private set { password = value; } }

        public string FirstName { get { return firstName; } private set { firstName = value; } }

        public string LastName { get { return lastName; } private set { lastName = value; } }

        public string Patronymic { get { return patronymic; } private set { patronymic = value; } }

        public string Role { get { return role; } private set { role = value; } }

        public string ClassForBase { get { return classForBase; } private set { classForBase = value; } }


        public AccountOI( string login, string password, string firstName, string lasetName, string patronymic, string role , string classForBase) 
        
        { 
         Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Role = role;
            ClassForBase = classForBase;
        }

    }
}
