using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Будни_Программиста.Model;
using Будни_Программиста.ViewModel;

namespace Будни_Программиста.View
{
    public partial class DaysPage
    {
        public DateTime SelectedMonth { get; set; }
        
        public DaysPage()
        {
            InitializeComponent();
            Loaded += (sender, _) =>
            {
                if (DataContext is not MainWindowViewModel viewModel) return;
                viewModel.PropertyChanged += ViewModel_PropertyChanged!;
                GenerateDays();
            };
        }

        private void GenerateDays()
        {
            Days.Children.Clear();

            var selectedMonth = SelectedMonth;
            if (DataContext is MainWindowViewModel viewModel) selectedMonth = viewModel.SelectedMonth;

            var daysInMonth = DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month);

            for (var day = 1; day <= daysInMonth; day++)
            {
                List<Language> languages = MainWindowViewModel.GetCurrentDay($"{day}.{selectedMonth.Month}.{selectedMonth.Year}");
                DayCardView dayCard = new()
                {
                    CurrentDayText =
                    {
                        Text = day.ToString()
                    },
                    CurrentDayImage =
                    {
                        Background = null
                    }
                };
                foreach (var language in languages)
                {
                    if (language.IsSelected)
                    {
                        ImageBrush imageBrush = new(new BitmapImage(new Uri($"../../../{language.PathPicture}", UriKind.Relative)));
                        dayCard.CurrentDayImage.Background = imageBrush;
                        break;
                    }
                }
                Days.Children.Add(dayCard);
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedMonth") GenerateDays();
        }
    }
}
