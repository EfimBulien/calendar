using System.Windows;
using Будни_Программиста.ViewModel;
using System.Windows.Controls;
using Будни_Программиста.Model;

namespace Будни_Программиста.View;

public partial class SelectLanguagesWindow : Window
{
    
    public SelectLanguagesWindow()
    {
        InitializeComponent();
        List<CheckBox> buttons = [Cpp, Java, Python, JS, Cs, Asm];
        DataContext = new SelectLanguagesWindowViewModel();
        MessageBox.Show(MainWindowViewModel.selectedMonth.ToString());
        SelectLanguagesWindowViewModel.date = $"{SelectLanguagesWindowViewModel.date}.{MainWindowViewModel.selectedMonth.Month}." + $"{MainWindowViewModel.selectedMonth.Year}";
        List<object> list = MainWindowViewModel.GetChoiceByDate(SelectLanguagesWindowViewModel.date);
        MessageBox.Show($"{SelectLanguagesWindowViewModel.date} - {list.Count}");
        if (list.Count > 0)
        {
            List<Language> languages = (List<Language>)list[1];
            foreach (Language language in languages)
            {
                foreach (CheckBox button in buttons)
                {
                    if (button.Content.ToString() == language.Name || button.Name == "Cpp" && language.Name == "C++")
                    {
                        button.IsChecked = language.IsSelected;
                        MessageBox.Show(button.Content.ToString());
                    }
                }
            }
        }
    }

    public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}