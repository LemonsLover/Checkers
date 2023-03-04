using Game.View.UserControls;
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

namespace Game.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    enum CheckerType
    {
        None,
        Black,
        White
    }
    public partial class MainWindow : Window
    {
        private CheckerType[,] checkers = {
            {CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black},
            {CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None},
            {CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black},
            {CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None},
            {CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None},
            {CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None},
            {CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White},
            {CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None},
            {CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White},
            {CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None},
        };
        public MainWindow()
        {
            InitializeComponent();
            InitializeField();
        }

        private void InitializeField()
        {
            for (int x = 0; x < checkers.GetLength(0); x += 1)
            {
                for (int y = 0; y < checkers.GetLength(1); y += 1)
                {
                    if(checkers[x,y] != CheckerType.None)
                    {
                        var newChecker = new CheckerUserControl();
                        var color = checkers[x, y] == CheckerType.White ? Color.FromRgb(255, 255, 255) : Color.FromRgb(0, 0, 0);
                        newChecker.Brush = new SolidColorBrush(color);
                        Grid.Children.Add(newChecker);
                        Grid.SetRow(newChecker, x+1);
                        Grid.SetColumn(newChecker, y+1);
                    }
                }
            }
        }
    }
}
