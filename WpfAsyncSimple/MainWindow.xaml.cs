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

namespace WpfAsyncSimple
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GetList();
            //GetListAsync();
        }

        private void GetList()
        {
            Task<List<int>> t = ProcessList();
            t.Wait();
            List<int> result = t.Result;
            this.tbx.Text = result.Sum(x => x).ToString();
        }

        private async void GetListAsync()
        {
            Task<List<int>> t = ProcessList();

            this.tbx.Text = (await t).Sum(x => x).ToString();
        }

        private Task<List<int>> ProcessList()
        {
            Task<List<int>> task = new Task<List<int>>(() => { Thread.Sleep(5000); return new List<int> { 1, 2, 3, 4, 5 }; });
            task.Start();
            return task;
        }

    }
}
