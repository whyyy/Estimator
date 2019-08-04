using Estimator.ViewModel;
using System.Windows;

namespace Estimator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new IssueWindowViewModel();

        }

    }
}
