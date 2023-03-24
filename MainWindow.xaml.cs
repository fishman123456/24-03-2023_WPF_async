using System;
using System.Collections.Generic;
using System.IO;
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

namespace _24_03_2023_WPF_async
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
        private async void button1_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                string path = "test.txt";
                string data = null;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using(StreamReader sr = new StreamReader(fs))
                    {
                        data = await sr.ReadToEndAsync();
                    }
                }

                text_out.Text = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
