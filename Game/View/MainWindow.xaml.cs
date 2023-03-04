using Game.Logic;
using Game.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Game.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        Field Field = new Field();
        //private CheckerType[,] checkers = {
        //    {CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black},
        //    {CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None},
        //    {CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black},
        //    {CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None, CheckerType.Black, CheckerType.None},
        //    {CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None},
        //    {CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None, CheckerType.None},
        //    {CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White},
        //    {CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None},
        //    {CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White},
        //    {CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None, CheckerType.White, CheckerType.None},
        //};
        public MainWindow()
        {
            InitializeComponent();
            UpdateField();
        }

        private void UpdateField()
        {
            ClearField();
            var checkersField = Field.CheckersField;
            for (int x = 0; x < checkersField.GetLength(0); x += 1)
            {
                for (int y = 0; y < checkersField.GetLength(1); y += 1)
                {
                    if (checkersField[x, y] != null)
                    {
                        var newChecker = new CheckerUserControl();
                        var color = checkersField[x, y].Type == CheckerType.White ? Color.FromRgb(255, 255, 255) : Color.FromRgb(0, 0, 0);
                        newChecker.Brush = new SolidColorBrush(color);
                        newChecker.Checker = checkersField[x, y];
                        newChecker.MouseDown += NewChecker_MouseDown;
                        Grid.Children.Add(newChecker);
                        Grid.SetRow(newChecker, x + 1);
                        Grid.SetColumn(newChecker, y + 1);
                    }
                }
            }
        }

        private void NewChecker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var checker = sender as CheckerUserControl;
            var random = new Random();
            Field.MoveChecker(checker.Checker, random.Next(1,10), random.Next(1, 10));
            UpdateField();
        }

        private void ClearField()
        {
            for (int i = Grid.Children.Count - 1; i >= 0; i -= 1)
            {
                UIElement Child = Grid.Children[i];
                if (Child is CheckerUserControl)
                    Grid.Children.Remove(Child);
            }
        }
    }
}
