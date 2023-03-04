using System.Windows.Media;

namespace Game.ViewModel
{
    public class CheckerViewModel
    {
        public Brush Brush { get; set; } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
    }
}
