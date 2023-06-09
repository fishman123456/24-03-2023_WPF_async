﻿using Microsoft.Win32;
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
        // считываем из файла
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            string data = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "TXT Files(*.txt)|*.txt|All(*.*)|*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = dialog.FileName;

            try
            {
                if (dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                    using (StreamReader sw = new StreamReader(path) )
                      
                    { data = await sw.ReadToEndAsync(); }
                }
                text_out.Text = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // записываем в файл
        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            string data = null;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TXT Files(*.txt)|*.txt|All(*.*)|*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = dialog.FileName;

            try
            {
                if (dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                   
                    UnicodeEncoding uniencoding = new UnicodeEncoding();
                    
                    byte[] result = uniencoding.GetBytes(text_out.Text);

                    using (FileStream SourceStream = File.Open(path, FileMode.OpenOrCreate))
                    {
                        SourceStream.Seek(0, SeekOrigin.End);
                        await SourceStream.WriteAsync(result, 0, result.Length);
                    }


                    
                }
                //text_out.Text = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    

