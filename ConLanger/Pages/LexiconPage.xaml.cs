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
    /// Interaction logic for LexiconPage.xaml
    /// </summary>
    public partial class LexiconPage : Page
    {
        Logic.Langer Langer;

        public LexiconPage(Logic.Langer l)
        {
            Langer = l;
            InitializeComponent();

            WordTypeCB.ItemsSource = Langer.WordTypes;
            WordTypeCB.SelectedIndex = 1;
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            Langer.AddWord(Logic.Tools.ConvertStringToPhoneList(NewWordTB.Text, Langer), MeaningTB.Text, (Data.WordType)WordTypeCB.SelectedItem);
        }
    }
}
