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
    /// Логика взаимодействия для ShowAnswer.xaml
    /// </summary>
    public partial class ShowAnswer : UserControl, Interface1
    {
       private enum forSelectedTypes { TextBlock, TextBox }
        


        public string Text { get; set; }

        public int Positiom { get; set; }

        public ObservableCollection<string> Answer { get; set; }

        public string Type { get; set; }
        public ShowAnswer()
        {
            InitializeComponent();

            addInStackPanel(new TextBlock() {Text="fasf", TextAlignment = TextAlignment.Center, FontSize = 30, Foreground=Brushes.White }, forSelectedTypes.TextBlock);
        }
        private void addInStackPanel(object obj, forSelectedTypes type)
        {
            switch(type) 
            {
                case forSelectedTypes.TextBlock:
                    if(obj is TextBlock) { stakeForAnswer.Children.Add(obj as TextBlock); return; }
                    MessageBox.Show("Типы не походят");
                    break;
                case forSelectedTypes.TextBox:
                    if(obj is TextBox) { stakeForAnswer.Children.Add(obj as TextBox); return;  }
                    MessageBox.Show("Типы не походят");
                    break;
                    
                 
                    
                
            }

        } 
        private void addInStack(string TextQuestion, ObservableCollection<string> collection, string type)
        {
            stakeForAnswer.Children.Add(new TextBlock() { Text = "fasf", TextAlignment = TextAlignment.Center, FontSize = 30, Foreground = Brushes.White });
            
        }
        
    }
}
