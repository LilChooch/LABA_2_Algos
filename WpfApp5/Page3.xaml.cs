using ScottPlot.Colormaps;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private int delay = 1000; // Задержка между перемещениями в миллисекундах
        private List<(int, double)> timeList = new List<(int, double)>();


        public static event RefreshGraph TimeAdded;
        public delegate void RefreshGraph(List<(int, double)> timeList);
        public Page3()
        {
            InitializeComponent();
            DrawPegs();
            Speed.ValueChanged += Speed_ValueChanged;
        }

        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            delay = 1000 / (int)Math.Round(Speed.Value);
            //if (Speed.Value == Speed.Maximum)
            //    delay = 0;
        }

        private void DrawPegs()
        {
            for (int i = 0; i < 3; i++)
            {
                int x = (int)gameCanvas.Width / 6 + i * cellWidth + (i + 1) * pegWidth; //140
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
                int x = (int)gameCanvas.Width / 6 + i * cellWidth + (i + 1) * pegWidth; //140
                int y = pegHeight + cellHeight * numDiscs;
                foreach (int disc in pegs[i].Reverse())
                {
                    int discWidth = disc * cellWidth / numDiscs;
                    int discX = x + (pegWidth - discWidth) / 2;
                    Rectangle discRect = new Rectangle
                    {
                        Width = discWidth,
                        Height = cellHeight,
                        Fill = Brushes.LightBlue,
                        StrokeThickness = 2,
                        Stroke = Brushes.Black

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
            Stopwatch sw = Stopwatch.StartNew();
            await Move(discs - 1, fromPeg, otherPeg, toPeg);

            int disc = pegs[fromPeg].Pop();
            pegs[toPeg].Push(disc);

            await Dispatcher.InvokeAsync(() =>
            {
                
                gameCanvas.Children.Clear();
                DrawPegs();
                DrawDiscs();

                TextBox tb = new TextBox();
                int i = StepLog.Children.Count + 1;
                tb.TextAlignment = TextAlignment.Center; tb.FontSize = 25;
                tb.Text = $"{i}) {fromPeg + 1} --> {toPeg + 1}";
                StepLog.Children.Add(tb);
            });

            await Task.Delay(delay);

            await Move(discs - 1, otherPeg, toPeg, fromPeg);

            await Dispatcher.InvokeAsync(() =>
            {
            sw.Stop();
            if (!timeList.Select(t => t.Item1).Contains(discs))
            {
                double time = (sw.ElapsedTicks / 10000 / delay);
                timeList.Add((discs, time));
                TimeAdded?.Invoke(timeList);
            }
            });

        }

    private void Home_Click(object sender, RoutedEventArgs e)
        {
            MyFrame3.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }

        //private void MyFrame3_Navigated(object sender, NavigationEventArgs e)
        //{
        //}


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timeList.Clear();
            StepLog.Children.Clear();
            numDiscs = (int)Math.Round(CountRings.Value);
            cellHeight = pegHeight / numDiscs;
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

        private void Graph_Click(object sender, RoutedEventArgs e)
        {
            var opened = Application.Current.Windows.OfType<GraphWindow>().FirstOrDefault();
            if (opened is null)
            {
                GraphWindow graphWindow = new GraphWindow();
                graphWindow.DrawGraph(timeList);
                graphWindow.Show();
            }
            else
            {
                opened.DrawGraph(timeList);
                opened.Focus();
            }
        }
    }
}
