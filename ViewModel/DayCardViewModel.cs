using System.Windows.Input;
using Будни_Программиста.View;
using Будни_Программиста.ViewModel.Helpers;

namespace Будни_Программиста.ViewModel;

internal class DayCardViewModel : BindingHelper
{
    public ICommand SelectLanguagesCommand { get; private set; }

    public DayCardViewModel()
    {
        SelectLanguagesCommand = new BindableCommand(ExecuteSelectLanguages);
    }

    private void ExecuteSelectLanguages(object parameter)
    {
        var selectLanguages = new SelectLanguagesWindow();
        selectLanguages.ShowDialog();
    }
}