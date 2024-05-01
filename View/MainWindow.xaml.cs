using Будни_Программиста.ViewModel;

namespace Будни_Программиста.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            MainWindowViewModel.GetData();
            FramePage.Content = new DaysPage() 
            { 
                DataContext = viewModel 
            };
        }
    }
}