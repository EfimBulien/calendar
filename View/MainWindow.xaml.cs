using System.Windows;
using Будни_Программиста.View;
using Будни_Программиста.ViewModel;

namespace Будни_Программиста
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            viewModel.GetData();
            FramePage.Content = new DaysPage() 
            { 
                DataContext = viewModel 
            };
        }
    }
}