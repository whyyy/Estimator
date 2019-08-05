using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Estimator.ViewModel
{
    class EstimatorViewModel : ObservableObject
    {
        private ICommand getIssues;
        public ICommand GetIssues
        {
            get
            {
                if (getIssues == null)
                {
                    getIssues = new RelayCommand(p => new GetIssues());
                }
                return getIssues;
            }
        }
    }
}
