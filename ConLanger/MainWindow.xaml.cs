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

namespace ConLanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic.Langer RefLanger;

        //Hey dont forget, the Langer object exist at the application level.
        public MainWindow(Logic.Langer L)
        {
            RefLanger = L;
            InitializeComponent();
            mainFrame.Navigate(new Pages.LanguagePage(L));
        }

        private void LangButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.LanguagePage(RefLanger));
        }

        private void PhoneButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.PhoneticPage(RefLanger));
        }

        private void WordsButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.WordTypePage(RefLanger));
        }

        private void LexiconButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.LexiconPage(RefLanger));
        }
    }
}
