using ScottPlot;
using ScottPlot.WPF;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        public GraphWindow()
        {
            InitializeComponent();
            Page3.TimeAdded += Page3_TimeAdded;
        }

        private void Page3_TimeAdded(List<(int, double)> timeList)
        {
            DrawGraph(timeList);
        }

        public void DrawGraph(List<(int, double)> timeList)
        {
            int size = timeList.Count;
            if (size < 2)
                return;
            double[] dataY = new double[size];
            int[] dataX = new int[size];
            for (int i = 0; i < size; i++)
            {
                dataX[i] = i + 1;
                dataY[i] = timeList[i].Item2;
            }

            MyPlot.Reset();
            MyPlot.Plot.Axes.Bottom.Label.Text = "Количество колец";
            MyPlot.Plot.Axes.Left.Label.Text = "Время (миллисекунды)";
            MyPlot.Plot.Add.Scatter(dataX, dataY);
            MyPlot.Refresh();
        }
    }
}
