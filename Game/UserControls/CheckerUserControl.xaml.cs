using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game.UserControls
{
    /// <summary>
    /// Interaction logic for CheckerUserControl.xaml
    /// </summary>
    public partial class CheckerUserControl : UserControl
    {
        public CheckerUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public Brush Brush { get; set; } = new SolidColorBrush(Color.FromRgb(0,0,0));
    }
}
