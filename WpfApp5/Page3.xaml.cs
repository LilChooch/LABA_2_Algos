using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private Stack<int>[] pegs;
        private int numDiscs;
        private int cellWidth = 250;
        private int cellHeight = 20;
        private int pegWidth = 10;
        private int pegHeight = 200;
        private int delay = 500; // Задержка между перемещениями в миллисекундах

        public Page3()
        {
            InitializeComponent();
            numDiscs = 10;
            pegs = new Stack<int>[3];
            for (int i = 0; i < 3; i++)
            {
                pegs[i] = new Stack<int>();
            }

            for (int i = numDiscs; i > 0; i--)
            {
                pegs[0].Push(i);
            }

            DrawPegs();
            DrawDiscs();

            Task.Run(() => Move(numDiscs, 0, 2, 1));
        }

        private void DrawPegs()
        {
            for (int i = 0; i < 3; i++)
            {
                int x = 140 + i * cellWidth + (i + 1) * pegWidth;
                Rectangle peg = new Rectangle
                {
                    Width = pegWidth,
                    Height = pegHeight,
                    Fill = Brushes.Gray
                };
                Canvas.SetLeft(peg, x);
                Canvas.SetTop (peg, gameCanvas.Height - cellHeight - pegHeight);
                gameCanvas.Children.Add(peg);
            }
        }

        private void DrawDiscs()
        {
            for (int i = 0; i < 3; i++)
            {
                int x = 140 + i * cellWidth + (i + 1) * pegWidth;
                int y = pegHeight + cellHeight * numDiscs;
                foreach (int disc in pegs[i].Reverse())
                {
                    int discWidth = disc * cellWidth / numDiscs;
                    int discX = x + (pegWidth - discWidth) / 2;
                    Rectangle discRect = new Rectangle
                    {
                        Width = discWidth,
                        Height = cellHeight,
                        Fill = Brushes.Blue
                    };
                    Canvas.SetLeft(discRect, discX);
                    Canvas.SetTop(discRect, y - cellHeight);
                    gameCanvas.Children.Add(discRect);
                    y -= cellHeight;
                }
            }
        }

        private async Task Move(int discs, int fromPeg, int toPeg, int otherPeg)
        {
            if (discs == 0)
            {
                return;
            }

            await Move(discs - 1, fromPeg, otherPeg, toPeg);

            int disc = pegs[fromPeg].Pop();
            pegs[toPeg].Push(disc);

            await Dispatcher.InvokeAsync(() =>
            {
                gameCanvas.Children.Clear();
                DrawPegs();
                DrawDiscs();

            });

            await Task.Delay(delay);

            await Move(discs - 1, otherPeg, toPeg, fromPeg);
        }

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame3.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
    }
}
