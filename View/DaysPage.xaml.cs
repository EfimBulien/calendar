using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Будни_Программиста.Model;
using Будни_Программиста.ViewModel;

namespace Будни_Программиста.View
{
    public partial class DaysPage : Page
    {
        public DateTime SelectedMonth { get; set; }


        public DaysPage()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                if (DataContext is MainWindowViewModel viewModel)
                {
                    viewModel.PropertyChanged += ViewModel_PropertyChanged;
                    GenerateDays();
                }
            };
        }

        private void GenerateDays()
        {
            Days.Children.Clear();

            DateTime selectedMonth = SelectedMonth;
            if (DataContext is MainWindowViewModel viewModel) selectedMonth = viewModel.SelectedMonth;

            int daysInMonth = DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                ImageBrush imageBrush = new(new BitmapImage(new Uri("none.jpg", UriKind.Relative)));
                MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
                List<Language> languages = mainWindowViewModel.GetCurrentDay($"{day}.{selectedMonth.Month}.{selectedMonth.Year}");
                DayCardView dayCard = new();
                dayCard.CurrentDayText.Text = day.ToString();
                dayCard.CurrentDayImage.Background = null;
                foreach (Language language in  languages)
                {
                    if (language.isSelected)
                    {
                        dayCard.CurrentDayImage.Background = imageBrush;
                        break;
                    }
                }
                if (dayCard.CurrentDayImage.Background == null)
                {
                    dayCard.CurrentDayImage.Background = imageBrush;
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
