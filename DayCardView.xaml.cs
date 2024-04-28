using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Будни_Программиста
{
    public partial class DayCardView : UserControl
    {
        Uri uri = new Uri("C:\\Users\\efimb\\Downloads\\calendar-master\\bin\\Debug\\net8.0-windows\\cpp.png", UriKind.Absolute);
        public DayCardView()
        {
            InitializeComponent();
            CurrentDayImage.Source = new BitmapImage(uri);
        }
    }
}
