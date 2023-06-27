using Microsoft.Win32;
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

namespace Parser
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

        private void AdressButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(this.AdressLine.Text, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                MessageBox.Show("The Address URI must be absolute. For example, 'http://www.microsoft.com'");
                return;
            }

            this.WebBrowser.Navigate(uri);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "html files (*.html)|*.html|all files (*.*)|*.*";
            if (savefiledialog.ShowDialog() == true)
            {
                string filepath = savefiledialog.FileName;
                string pagecontent = GetWebPageContent();
                File.WriteAllText(filepath, pagecontent);
                MessageBox.Show("page saved successfully!");
            }
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog textDialog = new SaveFileDialog();
        //    textDialog.Filter = "HTML Files (*.html)|*.html|All files (*.*)|*.*"; ;
        //    textDialog.DefaultExt = "html";
        //    string pagecontent = GetWebPageContent();


        //    bool? result = textDialog.ShowDialog();
        //    if (result == true)
        //    {
        //        System.IO.Stream fileStream = textDialog.OpenFile();
        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
        //        string filepath = SaveFileDialog.FileName;
        //        File.WriteAllText(filepath, pagecontent);

        //    }
        //}
        private string GetWebPageContent()
        {
            dynamic document = WebBrowser.Document;
            return document.documentElement.OuterHtml;
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (WebBrowser.CanGoBack)
            {
                WebBrowser.GoBack();
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (WebBrowser.CanGoForward)
            {
                WebBrowser.GoForward();
            }
        }
    }
}
