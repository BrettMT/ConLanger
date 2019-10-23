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

namespace ConLanger.Pages
{
    /// <summary>
    /// Interaction logic for LanguagePage.xaml
    /// </summary>
    public partial class LanguagePage : Page
    {
        Logic.Langer Langer;

        public LanguagePage(Logic.Langer langer)
        {
            Langer = langer ?? throw new Exception("No langer");
            InitializeComponent();
            CurrentLanguageLabel.Content = Langer.LanguageName;

            //Subscribe to this event so things update.
            Langer.ChangedLanguages += ListenForLanguageChange;
            
        }

        private void CreateNewLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            Langer.CreateLangauge(this.NewLanguageTextBox.Text);
        }

        private void ListenForLanguageChange(object o, EventArgs e)
        {
            CurrentLanguageLabel.Content = Langer.LanguageName;
        }
    }
}
