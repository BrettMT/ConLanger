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
    /// Interaction logic for PhoneticPage.xaml
    /// </summary>
    public partial class PhoneticPage : Page
    {
        Logic.Langer Langer;

        public PhoneticPage(Logic.Langer langer)
        {
            Langer = langer;
            InitializeComponent();
            try
            {
                Langer.AddPhoneme("test", "test", 1, "C");
            }
            catch(Logic.UnableToModifyLanguageException e)
            {
                //TODO: this should honestly be removed when your done in this section.
            }
            try
            {
                PhonemeList.ItemsSource = Langer.Phonemes;
                Langer.ChangedPhonemes += UpdateOnPhonemeChange;
            }
            catch
            {
                //I mean just dont crash. 
                //TODO: Log Error.
            }


        }

        private void AddPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: this should happen inside the Langer.
            try
            {
                Langer.AddPhoneme(PhoneIPATB.Text, PhoneRomanTB.Text, int.Parse(PhoneWeightTB.Text), PhoneCodeTB.Text);
            }
            catch (Logic.UnableToModifyLanguageException ex)
            {
                //TODO: throw a log message.
            }
        }

        private void UpdateOnPhonemeChange(object o, EventArgs e)
        {
            PhonemeList.ItemsSource = Langer.Phonemes;
            PhonemeList.Items.Refresh();
        }

        private void PhonemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PhonemeList.SelectedItem != null)
            {
                PhoneIPATB.Text = ((Data.Phoneme)PhonemeList.SelectedItem).IPA;
                PhoneRomanTB.Text = ((Data.Phoneme)PhonemeList.SelectedItem).Roman;
                PhoneCodeTB.Text = ((Data.Phoneme)PhonemeList.SelectedItem).SyllableCode;
                PhoneWeightTB.Text = ((Data.Phoneme)PhonemeList.SelectedItem).Weight.ToString();
            }
        }

        private void EditPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            Langer.EditPhoneme((Data.Phoneme)PhonemeList.SelectedItem, PhoneIPATB.Text, PhoneRomanTB.Text, int.Parse(PhoneWeightTB.Text), PhoneCodeTB.Text);
        }

        private void RemovePhoneButton_Click(object sender, RoutedEventArgs e)
        {
            Langer.RemovePhoneme((Data.Phoneme)PhonemeList.SelectedItem);
        }
    }
}
