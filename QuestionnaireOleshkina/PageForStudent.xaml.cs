using Connechn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QuestionnaireOleshkina
{
    /// <summary>
    /// Логика взаимодействия для PageForStudent.xaml
    /// </summary>
    public partial class PageForStudent : Page
    {
        private Page pageForQuestion;
        public ObservableCollection<Connechn.From> QuestionnaireForFrom { get; set; }
        private ConnectWithDataBase connect; 
        public PageForStudent(ConnectWithDataBase connect)
        {
            InitializeComponent();
            this.connect = connect;

            QuestionnaireForFrom = this.connect.RecieveForStudentOnFrom(QuestionnaireForFrom);
            DataContext = this;
           
        }

        private void SelectedQuestionnaire(object sender, SelectionChangedEventArgs e)
        {
            
            ListView listView = sender as ListView;
            var recieveObject = (Connechn.From)listView.SelectedItem;
            if (pageForQuestion == null) { pageForQuestion = new PageWithQuestion(connect,recieveObject); }
            NavigationService.Navigate(pageForQuestion);
            

           
        }
    }
}
