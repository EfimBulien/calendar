using System.IO;
using System.Windows;
using System.Windows.Input;
using Будни_Программиста.Model;
using Будни_Программиста.ViewModel.Helpers;

namespace Будни_Программиста.ViewModel
{
    internal class MainWindowViewModel : BindingHelper
    {
        public static List<DatesChoice> datesChoices = [];
        public static List<Language> default_languages = [];
        public static DateTime selectedMonth = DateTime.Today;
        private const string Path = "data.json";

        public DateTime SelectedMonth
        {
            get 
            { 
                //MessageBox.Show($"get {selectedMonth}"); 
                return selectedMonth; 
            }
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    //MessageBox.Show($"set {selectedMonth}");
                    OnPropertyChanged();
                }
            }
        }
      
        public ICommand PreviousMonthCommand { get; private set; }
        public ICommand NextMonthCommand { get; private set; }

        public MainWindowViewModel() 
        {
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

        public static void GetData()
        {
            default_languages.Add(Language.Create("C++", "cpp.png"));
            default_languages.Add(Language.Create("Java", "java.png"));
            default_languages.Add(Language.Create("Python", "python.png"));
            default_languages.Add(Language.Create("JavaScript", "js.png"));
            default_languages.Add(Language.Create("C#", "csharp.png"));
            default_languages.Add(Language.Create("Assembler", "asm.png"));
            default_languages.Add(Language.Create("None", "none.jpg", true));
            if (!File.Exists(Path)) File.Create(Path).Close();
            datesChoices = Files.Deserialize<List<DatesChoice>>(Path);
            datesChoices ??= [];
        }

        public static List<object> GetChoiceByDate(string date)
        {
            for (int i = 0; i < datesChoices.Count; i++)
            {
                if (datesChoices[i].Date == date)
                {
                    return [i, datesChoices[i].Languages];
                }
            }
            return [];
        }

        public static List<Language>? GetCurrentDay(string date)
        {
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0) return datesChoices[Convert.ToInt32(choices[0])].Languages;
            return default_languages;
        }

        public static void SaveDay(string date, List<Language>? languages)
        {
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0)
            {
                datesChoices[Convert.ToInt32(choices[0])].Languages = languages;
                return;
            }
            datesChoices.Add(DatesChoice.Create(date, languages));
            Files.Serialize(datesChoices, Path);
        }

        private void ClearDay(string date)
        {
            List<object> choices = GetChoiceByDate(date);
            if (choices.Count > 0) datesChoices.Remove((DatesChoice)choices[1]);
            Files.Serialize(datesChoices, Path);
        }
    }
}
