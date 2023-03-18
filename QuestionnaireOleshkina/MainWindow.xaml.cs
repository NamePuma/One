using System;
using System.Collections.Generic;
using System.Linq;
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

namespace QuestionnaireOleshkina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {



        private Page enterPage;

        ConnectWithDataBase connectWithDataBase;
        public Page EnterPage
        {
            get { return enterPage; }
        }



        public MainWindow()
        {
            InitializeComponent();

            connectWithDataBase = new ConnectWithDataBase();

            connectWithDataBase.AutoConnect();

            enterPage = new EnterPage(connectWithDataBase);

            



            MyFrame.Navigate(EnterPage);

           

                

        }
    }
}
