using Game.Logic;
using Game.Utils;
using Game.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        public MainWindow()
        {
            InitializeComponent();
            UpdateField();
        }

        private void UpdateField()
        {
            ClearCheckerField();
            ClearHighlightField();
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

        private void ClearCheckerField()
        {
            for (int i = Grid.Children.Count - 1; i >= 0; i -= 1)
            {
                UIElement Child = Grid.Children[i];
                if (Child is CheckerUserControl)
                    Grid.Children.Remove(Child);
            }
        }

        private void ClearHighlightField()
        {
            for (int i = Grid.Children.Count - 1; i >= 0; i -= 1)
            {
                UIElement Child = Grid.Children[i];
                if (Child is MoveHighlightUserControl)
                    Grid.Children.Remove(Child);
            }

            foreach(var checker in Grid.Children.OfType<CheckerUserControl>())
                checker.IsSelected = false;
        }

        private void NewChecker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClearHighlightField();
            AudioPlayer.Play("CheckerSelected");
            var checker = sender as CheckerUserControl;
            checker.IsSelected = true;
            var availableMoves = Field.GetAvailableMovesFor(checker.Checker);
            foreach(var move in availableMoves)
            {
                var highlight = new MoveHighlightUserControl(move, checker.Checker);
                highlight.MouseLeftButtonDown += Highlight_MouseLeftButtonDown;
                Grid.Children.Add(highlight);
                Grid.SetRow(highlight, move.Row + 1);
                Grid.SetColumn(highlight, move.Col + 1);
            }
        }

        private void Highlight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AudioPlayer.Play("CheckerMove");
            var highlight = sender as MoveHighlightUserControl;

            Field.MoveChecker(highlight.RelatedChecker, highlight.Position.Row, highlight.Position.Col);
            UpdateField();
        }
    }
}
