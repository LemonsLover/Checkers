using Game.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Game.View.UserControls
{
    /// <summary>
    /// Interaction logic for CheckerUserControl.xaml
    /// </summary>
    public partial class CheckerUserControl : UserControl, INotifyPropertyChanged
    {
        public CheckerUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private Brush brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private Brush initialBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private bool initialBrushSetted = false;
        public Brush Brush
        {
            get { return brush; }
            set 
            {          
                brush = value;
                if (!initialBrushSetted)
                {
                    initialBrush = value;
                    initialBrushSetted = true;
                }
                OnPropertyChanged(nameof(brush));
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            //Brush = new SolidColorBrush(Color.FromRgb(255, 192, 203));
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Brush = new SolidColorBrush(Color.FromRgb(255, 192, 203));
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Brush = initialBrush;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
