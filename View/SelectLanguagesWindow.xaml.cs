using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Будни_Программиста.ViewModel;
using System.Windows.Controls;

namespace Будни_Программиста.View;

public partial class SelectLanguagesWindow
{
    
    public SelectLanguagesWindow()
    {
        InitializeComponent();
        Uri uri = new Uri("\\bin\\Debug\\net8.0-windows\\cpp.png", UriKind.Relative);
        CPP.Source = new BitmapImage(uri);
        DataContext = new SelectLanguagesWindowViewModel();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}