using Game.Logic;
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

namespace Game.View.UserControls
{
    /// <summary>
    /// Interaction logic for MoveHighlightUserControl.xaml
    /// </summary>
    public partial class MoveHighlightUserControl : UserControl
    {
        public Position Position { get; set; }
        public Checker RelatedChecker { get; set; }
        public MoveHighlightUserControl(Position position, Checker relatedChecker)
        {
            InitializeComponent();
            Position = position;
            RelatedChecker = relatedChecker;
        }
    }
}
