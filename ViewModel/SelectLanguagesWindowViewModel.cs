using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Будни_Программиста.ViewModel.Helpers;

namespace Будни_Программиста.ViewModel;

internal class SelectLanguagesWindowViewModel : BindingHelper
{
    public ICommand CloseWindowCommand { get; private set; }
    public SelectLanguagesWindowViewModel()
    {
        CloseWindowCommand = new BindableCommand(CloseWindow);

    }

    private void CloseWindow(object parameter)
    {
        if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();
    }
}