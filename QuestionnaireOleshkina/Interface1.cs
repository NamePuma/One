using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireOleshkina
{
    public interface Interface1
    {
        string Text { get; }
        int Positiom { get; }
        ObservableCollection<string> Answer { get; }
        string Type { get; }
    }
}
