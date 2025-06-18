using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Una.Services;
using Hotel_Una.ViewModels;

namespace Hotel_Una.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
