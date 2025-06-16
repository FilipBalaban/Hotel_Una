using Hotel_Una.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public MainViewModel(Hotel hotel)
        {
            CurrentViewModel = new CalendarViewModel();
        }
    }
}
