using Connechn;
using Newtonsoft.Json;
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
    /// Логика взаимодействия для ShowAnswer.xaml
    /// </summary>
    public partial class ShowAnswer : UserControl, Interface1
    {
        private enum forSelectedTypes { TextBlock, TextBox, ComboBox, RadioButton }



        public string Text { get; set; }

        public int Positiom { get; set; }

        public ConnectWithDataBase connected { get; set; }

        public ObservableCollection<string> Answer { get; set; }

        private ObservableCollection<Question> Questionniery { get; set; }

        public string Type { get; set; }
        public ShowAnswer(ConnectWithDataBase connect, Question question)
        {
            InitializeComponent();

            connected = connect;




            if (question.Type == "ComboBox")
            {

                addInStackPanel(new ComboBox() { ItemsSource = question.Content.PossibleAnswer }, question.Content.Text, forSelectedTypes.ComboBox);
            }
            else if (question.Type == "TextBox")
            {
                addInStackPanel(new TextBox() { FontSize = 30, Foreground = Brushes.Black }, question.Content.Text, forSelectedTypes.TextBox);
            }
            else if (question.Type == "RadioButon")
            {
                ObservableCollection<string> answers = new ObservableCollection<string>(question.Content.PossibleAnswer.ToList());
                int i = 0;
                foreach (string j in answers)
                {
                    if (i == 0)
                    {
                        addInStackPanel(new RadioButton() { GroupName = "yes", Content = j }, question.Content.Text, forSelectedTypes.RadioButton);
                        i++;
                    }
                    else
                    {
                        addInStackPanelForRadioButton(new RadioButton() { GroupName = "yes", Content = j });
                    }
                }
            }



            /*addInStackPanel();*/
        }
        private void addInStackPanel(object obj, string text, forSelectedTypes type)
        {
            switch (type)
            {
                case forSelectedTypes.TextBlock:
                    if (obj is TextBlock) { stakeForAnswer.Children.Add(new TextBlock() { Text = text, Foreground = Brushes.Blue, FontSize = 30 }); stakeForAnswer.Children.Add(obj as TextBlock); return; }
                    MessageBox.Show("Типы не походят");
                    break;
                case forSelectedTypes.TextBox:
                    if (obj is TextBox) { stakeForAnswer.Children.Add(new TextBlock() { Text = text, Foreground = Brushes.Blue, FontSize = 30 }); stakeForAnswer.Children.Add(obj as TextBox); return; }
                    MessageBox.Show("Типы не походят");
                    break;
                case forSelectedTypes.ComboBox:
                    if (obj is ComboBox) { stakeForAnswer.Children.Add(new TextBlock() { Text = text, Foreground = Brushes.Blue, FontSize = 30 }); stakeForAnswer.Children.Add(obj as ComboBox); return; }
                    MessageBox.Show("Типы нюню");
                    break;
                case forSelectedTypes.RadioButton:
                    if (obj is RadioButton) { stakeForAnswer.Children.Add(new TextBlock() { Text = text, Foreground = Brushes.Blue, FontSize = 30 }); stakeForAnswer.Children.Add(obj as RadioButton); return; }
                    MessageBox.Show("Типы нюню");
                    break;
            }

        }
        private void addInStackPanelForRadioButton(object obj)
        {
            if (obj is RadioButton) { stakeForAnswer.Children.Add(obj as RadioButton); return; }
            MessageBox.Show("Типы нюню");
        }

    }
}
