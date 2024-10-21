using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bevolkingsverdubbeling
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

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            bool validGrowth = double.TryParse(growthTextBox.Text, out double growth);
            bool validPopulation = double.TryParse(populationtextBox.Text, out double population);
            double doublePopulation = population * 2;
            double growthPercentage = (1 + (growth / 100));
            int years = 1;
            if(growth == 0)
            {
                MessageBox.Show("Zonder groeipercentage is er geen verdubbeling.");
            }
            else
            {
                do
                {
                    population *= growthPercentage;
                    years++;
                } while (population < doublePopulation);
                resultTextBox.Text = $"Nieuw bevolkingsgetal na {years} jaren is {population} mensen. ";
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
            populationtextBox.Clear();
            growthTextBox.Clear();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}