using generator.ViewModels.Helpers;
using System.Windows.Input;
using Будни_Программиста.Model;
using Будни_Программиста.ViewModel.Helpers;

namespace Будни_Программиста.ViewModel
{
    internal class MainWindowViewModel : BindingHelper
    {
        private List<DatesChoice> datesChoices = [];
        public static List<Language> default_languages = [];
        private DateTime selectedMonth;
        string path = "";

        public DateTime SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    OnPropertyChanged(nameof(SelectedMonth));
                }
            }
        }

        public ICommand PreviousMonthCommand { get; private set; }
        public ICommand NextMonthCommand { get; private set; }

        public MainWindowViewModel() 
        {
            SelectedMonth = DateTime.Today;
            PreviousMonthCommand = new BindableCommand(ExecutePreviousMonth);
            NextMonthCommand = new BindableCommand(ExecuteNextMonth);
        }
    
        private void ExecutePreviousMonth(object parameter)
        {
            SelectedMonth = SelectedMonth.AddMonths(-1);
        }

        private void ExecuteNextMonth(object parameter)
        {
            SelectedMonth = SelectedMonth.AddMonths(1);
        }

        public void GetData()
        {
            default_languages.Add(Language.Create("C++", "cpp.png"));
            default_languages.Add(Language.Create("Java", "java.png"));
            default_languages.Add(Language.Create("Python", "python.png"));
            default_languages.Add(Language.Create("JavaScript", "js.png"));
            default_languages.Add(Language.Create("C#", "csharp.png"));
            default_languages.Add(Language.Create("Assembler", "asm.png"));
            default_languages.Add(Language.Create("None", "none.png"));
            datesChoices = Files.Deserialize<List<DatesChoice>>(path);
        }

        private List<object> GetChoiceByDate(DateOnly date)
        {
            for (int i = 0; i < datesChoices.Count; i++)
            {
                if (datesChoices[i].Date == date.ToString())
                {
                    return [i, datesChoices[i].Languages];
                }
            }
            return [];
        }

        public List<Language> GetCurrentDay(DateOnly date)
        {
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0) return datesChoices[Convert.ToInt32(choices[0])].Languages;
            return [];
        }

        private void SaveDay(DateOnly date)
        {
            List<Language> languages = [];
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0)
            {
                datesChoices[Convert.ToInt32(choices[0])].Languages = languages;
                return;
            }
            datesChoices.Add(DatesChoice.Create(date.ToString(), languages));
        }

        private void ClearDay(DateOnly date)
        {
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0) datesChoices.Remove((DatesChoice)choices[1]);
        }
    }
}
