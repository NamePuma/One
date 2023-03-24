using Connechn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
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
    /// Логика взаимодействия для EnterInSistem.xaml
    /// </summary>



    public partial class EnterInSistem : Page
    {
        private enum Page
        {
            first, second
        }
        private Page page = Page.first;

        private enum TwoClick
        {
            One, Two
        }
        private TwoClick clickForListBox = TwoClick.One;

        private enum ForIdQuestion
        {
            one, two
        }
        private ForIdQuestion enumId = ForIdQuestion.one;

        ConnectWithDataBase connection;
        public ObservableCollection<string> createQuestions { get; set; }

        public ObservableCollection<Receive> ForShow { get; set; }

        public ObservableCollection<CreateQuestion> ShowQuestion { get; set; }

        public static CreateQuestion CreateQuestion { get; set; }
        private enum forImageLion
        {
            visa,
            coll
        }
        private forImageLion enumLion = forImageLion.visa;


        public EnterInSistem(ConnectWithDataBase connect)
        {
            InitializeComponent();
            connection = connect;

            createQuestions = new ObservableCollection<string>();





            ForShow = connection.Receive(ConnectWithDataBase.teacher);
            DataContext = this;









        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (enumLion == forImageLion.visa)
            {
                imgLion.Visibility = Visibility.Visible;
                enumLion = forImageLion.coll;

            }
            else
            {
                imgLion.Visibility = Visibility.Collapsed;
                enumLion = forImageLion.visa;
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            string text = textOnCreateQuestions.Text;

            string type = comboBoxOnTypeQuestions.Text;

            string position = textBoxOnPositionQuestions.Text;


            if(text == string.Empty || type == null || position == string.Empty) { MessageBox.Show("Нельзя"); return; }

            try
            {
                CreateQuestion createQuestion = new CreateQuestion()
                {
                    Text = text,
                    position = int.Parse(position),
                    
                    PossibleAnswer = new ObservableCollection<string>(createQuestions)

                };




                if (enumId == ForIdQuestion.one)
                {

                    connection.AddQuestionWithId(createQuestion, type, ConnectWithDataBase.IdQuestion);
                }
                else if (enumId == ForIdQuestion.two)
                {
                    connection.AddQuestion(createQuestion, type);
                }
                if (ShowQuestion == null)
                {

                    ShowQuestion = new ObservableCollection<CreateQuestion>();
                    listiForQuestionnaire.ItemsSource = ShowQuestion;
                    ShowQuestion.Add(createQuestion);
                    clickForListBox = TwoClick.Two;


                }
                else
                {
                    ShowQuestion.Add(createQuestion);
                }




                textOnCreateQuestions.Text = string.Empty;

                comboBoxOnTypeQuestions.Text = string.Empty;

                textBoxOnPositionQuestions.Text = string.Empty;

                createQuestions.Clear();

                PossibleAnswer.Text = string.Empty;



            }
            catch
            {
                MessageBox.Show("ЭЭЭЭ куда буквы пишешь"); return;
            }
        }






        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            var text = textBoxForName.Text;
            if (text.Length < 1)
            {
                MessageBox.Show("Нет названия");
                return;
            }
            Connechn.ConnectWithDataBase.NameQuestionniry = text;
            connection.AddFromInBase();


            stackPanelNameQuetionniry.Visibility = Visibility.Hidden;
            stackPanelCreateQuesrion.Visibility = Visibility.Visible;
            stackPanelEditQuesrions.Visibility = Visibility.Visible;
            if (ForShow != null)
            {
                ForShow.Clear();
            }
            textBoxForName.Text = string.Empty;
            enumId = ForIdQuestion.two;
            addQuestionnire.Text = "Вопросы";
            block.Visibility = Visibility.Visible;
            back.Foreground = Brushes.Red;




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PossibleAnswer.Text.Length < 1) { MessageBox.Show("Nain"); return; }
            createQuestions.Add(PossibleAnswer.Text);
            PossibleAnswer.Text = string.Empty;

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch(clickForListBox)
            //{
            //    case TwoClick.One: clickForListBox = TwoClick.Two; listBoxForQuestions.SelectedItem = null; break;
            //    case TwoClick.Two: MessageBox.Show("Вы вфывыф"); clickForListBox = TwoClick.One; break;

            //}
            if (clickForListBox == TwoClick.One)
            {

                var list = sender as ListBox;

                if (list.SelectedItem == null) return;

                Receive receive = (Receive)list.SelectedItem;

                int id = receive.Id;

                ConnectWithDataBase.IdQuestion = id;

                ShowQuestion = connection.SelectQuestionniyAuto(id);

                stackPanelNameQuetionniry.Visibility = Visibility.Hidden;
                stackPanelCreateQuesrion.Visibility = Visibility.Visible;
                stackPanelEditQuesrions.Visibility = Visibility.Visible;

                listiForQuestionnaire.ItemsSource = ShowQuestion;

                addQuestionnire.Text = "Вопросы";


                clickForListBox = TwoClick.Two;
                back.Foreground = Brushes.Red;
                block.Visibility = Visibility.Visible;




            }
            else if (clickForListBox == TwoClick.Two)
            {
                var list = sender as ListBox;

                if (list.SelectedItem == null)
                {
                    ConnectWithDataBase.Index = -1;
                    return;
                }




                CreateQuestion receiveForUpdate = (CreateQuestion)list.SelectedItem;
                
                ConnectWithDataBase.Index = list.SelectedIndex;

                ConnectWithDataBase.IdQ = receiveForUpdate.Id;
                block.Visibility = Visibility.Hidden;
                
             

                //textForChangeQuestion.Text = receiveForUpdate.Text;

                //textForChangePosition.Text = receiveForUpdate.position.ToString();

                //listForChange.ItemsSource = receiveForUpdate.PossibleAnswer;



               



                



            }








        }

        private void listBoxForQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBoxForChangeAnswerOption = sender as ListBox;

            if (listBoxForChangeAnswerOption.SelectedItem == null) { return; }

            string answerOption = listBoxForChangeAnswerOption.SelectedItem.ToString();

            if (PossibleAnswer.Text.Length > 1) { return; }

            PossibleAnswer.Text = answerOption;

            createQuestions.RemoveAt(listBoxForChangeAnswerOption.SelectedIndex);



        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            connection.DeleteQuestion(Connechn.ConnectWithDataBase.IdQ);
            try
            {
                if (ShowQuestion == null || ConnectWithDataBase.Index == -1) {
                    MessageBox.Show("Ну нечего удалять");
                    return; 
                }
                ShowQuestion.RemoveAt(ConnectWithDataBase.Index);
                possibleAnswerEdit.Text = string.Empty; 
            }
            catch { MessageBox.Show("Ну нечего удалять"); }



        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var question = listiForQuestionnaire.SelectedItem as CreateQuestion;
            
            

            connection.UpdateQuestion(ConnectWithDataBase.IdQ, question);

            possibleAnswerEdit.Text = string.Empty;

            MessageBox.Show("Отлишна");

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var crQu = (CreateQuestion)listiForQuestionnaire.SelectedItem;
           if(listForChange.SelectedIndex == -1) { return; }
            crQu.PossibleAnswer.RemoveAt(listForChange.SelectedIndex);
            possibleAnswerEdit.Text = string.Empty;


        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var crQu =(CreateQuestion)listiForQuestionnaire.SelectedItem;
            if(possibleAnswerEdit.Text.Length < 1) { MessageBox.Show("Найн"); return; }
            crQu.PossibleAnswer.Add(possibleAnswerEdit.Text);

            possibleAnswerEdit.Text = string.Empty;
            


        }

        private void listForChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if(listBox.SelectedItem ==null) { return; }
            possibleAnswerEdit.Text = listBox.SelectedItem.ToString();
             
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (page != Page.first)
            {
                MessageBox.Show("Не куда");
            }
            else
            {
                stackPanelNameQuetionniry.Visibility = Visibility.Visible;
                stackPanelCreateQuesrion.Visibility = Visibility.Hidden;
                stackPanelEditQuesrions.Visibility = Visibility.Hidden;
                ForShow = connection.Receive(ConnectWithDataBase.teacher);
                listiForQuestionnaire.ItemsSource = ForShow;
                clickForListBox = TwoClick.One;
                back.Foreground = Brushes.Gray;


            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var question = listiForQuestionnaire.SelectedItem as CreateQuestion;

            question.PossibleAnswer[listForChange.SelectedIndex] = possibleAnswerEdit.Text;

        }
    }
}
