using System;
using System.Threading;
using System.Windows;

namespace UsedThreads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime _EndTime;

        private DateTime EndTime
        {
            get
            {
                return _EndTime;
            }

            set
            {
                _EndTime = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int TimeOut = 5000;
            int number = Int32.MaxValue;
            Int64 perv = 1;
            Int64 vtor = 1;
            Int64 sum = 0;
            var strTimeToResult = "";
            EndTime = DateTime.Now.AddMilliseconds(TimeOut);

            var thread2 = new Thread(
                () =>
                {
                    while(true)
                    {
                        strTimeToResult = TimeToView();
                        Application.Current.Dispatcher.Invoke(
                            () =>
                            {
                                TBlock2.Text = strTimeToResult;
                            });
                    }
                });
            thread2.IsBackground = true;
            thread2.Start();


            var thread = new Thread(
                () =>
                {

                    while (number >= sum)
                    {
                        sum = perv + vtor;
                        var result = sum.ToString();
                        EndTime = DateTime.Now.AddMilliseconds(TimeOut);

                        Thread.Sleep(TimeOut);
                        Application.Current.Dispatcher.Invoke(
                            () =>
                            {
                                TBlock.Text = result;
                            });

                        perv = vtor;
                        vtor = sum;
                    }

                });
            thread.Start();
        }


        private string TimeToView()
        {
            if (EndTime > DateTime.Now)
            {
                Thread.Sleep(50);
            }

            return (EndTime - DateTime.Now).ToString();
        }
    }
}
