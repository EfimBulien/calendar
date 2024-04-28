using System.ComponentModel;
using System.Windows.Controls;
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
                DayCardView dayCard = new DayCardView();
                dayCard.CurrentDayText.Text = day.ToString();
                Days.Children.Add(dayCard);
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedMonth") GenerateDays();
        }
    }
}
