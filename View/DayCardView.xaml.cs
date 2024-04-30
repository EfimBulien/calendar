using Будни_Программиста.ViewModel;

namespace Будни_Программиста.View
{
    public partial class DayCardView
    {
        public DayCardView()
        {
            InitializeComponent();
            DataContext = new DayCardViewModel();
        }
    }
}
