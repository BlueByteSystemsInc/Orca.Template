using Microsoft.Win32;
using System.Windows;

namespace Orca.Template.Wizard
{
    /// <summary>
    /// Interaction logic for WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        public ProjectDetails ProjectDetails { get; } = new ProjectDetails();

        public WizardWindow()
        {
            InitializeComponent();
            DataContext = ProjectDetails;
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void OnBrowseLicenceButtonClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                LicensePathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
