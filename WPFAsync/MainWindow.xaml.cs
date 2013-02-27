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

namespace WPFAsync
{
    using System.Net;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void  Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Response.Text = (await this.DownloadDataAsync()).ToString();
            }
            catch (Exception ex)
            {
                this.Response.Text = ex.Message;
            }
             
        }

        public async Task<int> DownloadDataAsync()
        {
            WebClient client = new WebClient();
            Task<byte[]> resultTask = client.DownloadDataTaskAsync(new Uri("http://www.pluralsight.com/training/Courses"));
            //independent work
            this.Response.Text = "Downloading";

            byte[] reault = await resultTask;
            return reault.Length;
        }

        private void Button_ClickSendbyDelegate(object sender, RoutedEventArgs e)
        {
            this.DownlaoadDataByDelegate();
        }

        public void DownlaoadDataByDelegate()
        {
            WebClient client = new WebClient();
            client.DownloadDataCompleted += this.client_DownloadDataCompleted;
            client.DownloadDataAsync(new Uri("http://www.pluralsight.com/training/Courses"));
            //independent work
            this.Response.Text = "Downloading";
        }

        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.Response.Text = e.Error.Message;
            }
            else
            {
                this.Response.Text = e.Result.ToString();
            }
        }

        private void ButtonTime_Click(object sender, RoutedEventArgs e)
        {
            this.TimeResult.Text = DateTime.Now.ToString();
        }
    }
}
