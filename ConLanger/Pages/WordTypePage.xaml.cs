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
    /// Interaction logic for WordTypePage.xaml
    /// </summary>
    public partial class WordTypePage : Page
    {
        Logic.Langer Langer;

        public WordTypePage(Logic.Langer L)
        {
            Langer = L;
            InitializeComponent();


            try
            {
                WordTypesList.ItemsSource = Langer.WordTypes;
                Langer.ChangedWordTypes += UpdateOnWordTypeChange;
            }
            catch
            {
                //I mean just dont crash. 
                //TODO: Log Error.
            }
        }

        private void AddTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            Langer.AddWordType(TypeTB.Text);
        }

        public void UpdateOnWordTypeChange(object o, EventArgs e)
        {
            WordTypesList.ItemsSource = Langer.WordTypes;
            WordTypesList.Items.Refresh();
        }

        private void RemoveTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            Langer.RemoveWordType((Data.WordType)WordTypesList.SelectedItem);
        }
    }
}
