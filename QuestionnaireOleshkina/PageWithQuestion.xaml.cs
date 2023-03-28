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
    /// Логика взаимодействия для PageWithQuestion.xaml
    /// </summary>
    public partial class PageWithQuestion : Page
    {
        private ConnectWithDataBase Connect { get; set; }
        public ObservableCollection<Question> questionForSrudent { get; set; }

        public ObservableCollection<Connechn.CreateQuestion> createQuestions { get; set; }
        public PageWithQuestion(ConnectWithDataBase connect, From questionnaire)
        {
            InitializeComponent();
            Connect = connect;
            questionForSrudent = connect.ReceiveForStudentOnQuestion(questionForSrudent, questionnaire.Id);
            DataContext = this;
           
        }
    }
}
