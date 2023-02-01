using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Website_Downloader
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                
                
                if (URLTextBox.Text.Length== 0) 
                {
                    MessageBox.Show("Please add a url link!");
                }
                else
                {
                    HttpResponseMessage response =
                    await client.GetAsync(URLTextBox.Text);
                    string body = await response.Content.ReadAsStringAsync();
                    BodyTextBox.Text = body;
                    CodeLabel.Content = "Code: " + (int)response.StatusCode + ", Status: " + response.StatusCode;
                }
                
                
                
            }

        }

        private void SaveCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PathTextBox.IsEnabled = true;
            PathLabel.IsEnabled = true;
            SaveButton.Focusable = true;
            SaveButton.IsEnabled= true;
            PathTextBox.Visibility = Visibility.Visible;
            PathLabel.Visibility = Visibility.Visible;
            SaveButton.Visibility = Visibility.Visible;
        }

        private void SaveCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PathTextBox.IsEnabled= false;
            PathLabel.IsEnabled= false;
            SaveButton.Focusable = false;
            SaveButton.IsEnabled = false;
            PathTextBox.Visibility = Visibility.Collapsed;
            PathLabel.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Collapsed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(SaveCheckBox.IsChecked == true)
            {
                if(PathTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter a Path!");
                }
                else
                {
                    string path = PathTextBox.Text;
                    path = path.Replace("\"","");
                    File.WriteAllText(path, BodyTextBox.Text);
                    MessageBox.Show("Site Downloaded!");
                }
            }
        }
    }
}
