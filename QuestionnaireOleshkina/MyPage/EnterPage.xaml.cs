using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Connechn;
using Npgsql;
using NpgsqlTypes;

namespace QuestionnaireOleshkina
{
    /// <summary>
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    /// 



    public partial class EnterPage : Page
    {


        private ConnectWithDataBase connect;

        public ConnectWithDataBase Connect { get { return connect; } private set { connect = value; } }

        private Page teacherPage;

        public Page TeacherPage { get { return teacherPage; } private set { teacherPage = value; } }

        private Page pageForStudent;

        public Page PageForStudent { get { return pageForStudent; } private set { pageForStudent = value; } }




        public EnterPage(ConnectWithDataBase connechn)
        {
            InitializeComponent();

            Connect = connechn;

            if (PageForStudent == null)
            {
                PageForStudent = new PageForStudent();
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            CheckEnter(loginTextBox, loginPassword);


        }







        private void CheckEnter(TextBox textBoxLogin, PasswordBox passwordBoxPassowrd)
        {
            if (textBoxLogin.Text.Length < 1 || passwordBoxPassowrd.Password.Length < 1) { MessageBox.Show("Так, не понял. Ниче не вписал же"); return; }

            var login = textBoxLogin.Text;
            var password = passwordBoxPassowrd.Password.ToString();

            NpgsqlCommand npgsqlCommand = Connect.autongsqlConnection.CreateCommand();

            npgsqlCommand.CommandText = "select * from \"Account\" where \"Login\" = @log and \"Password\" = @pas limit 1";
            npgsqlCommand.Parameters.AddWithValue("@log", NpgsqlDbType.Varchar, login);
            npgsqlCommand.Parameters.AddWithValue("@pas", NpgsqlDbType.Varchar, password);
            var result = npgsqlCommand.ExecuteReader();
            if (!result.HasRows) { result.Close(); return; }
            result.Read();
            
                if (result.GetString(5) == "Teacher")
                {
                    Connechn.ConnectWithDataBase.teacher =login;
                     result.Close();
                    if (TeacherPage == null)
                    {
                        TeacherPage = new EnterInSistem(Connect);
                    }
                    NavigationService.Navigate(TeacherPage);
                }
                else if (result.GetString(5) == "Student")
                {
                    result.Close();
                    Connechn.ConnectWithDataBase.NameStudent = login;
                    NavigationService.Navigate(PageForStudent);

                }


            
            result.Close();
        }
    }
}
