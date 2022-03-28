using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace UsedThreads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            int number = Int32.MaxValue;
            Int64 perv = 1;
            Int64 vtor = 1;
            Int64 sum = 0;

            new Thread(
                () =>
                {
                    while (number >= sum)
                    {
                        sum = perv + vtor;
                        var result = sum.ToString();
                        Thread.Sleep(150);
                        TBlock.Dispatcher.Invoke(
                            () =>
                            {
                                TBlock.Text = result;
                            });

                        perv = vtor;
                        vtor = sum;
                    }

                }).Start();
        }
    }
}
