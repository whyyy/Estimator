
using Estimator.App.ViewModel;
using System.Windows;

namespace Estimator.App.View

{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class IssueWindow : Window
    {
        public IssueWindow()
        {
            InitializeComponent();
            DataContext = new IssueWindowViewModel();
        }

    }
}
