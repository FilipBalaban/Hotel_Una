using Hotel_Una.Models;
using Hotel_Una.ViewModels;
using Hotel_Una.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel_Una.Commands
{
    public class SearchCommand : BaseCommand
    {
        private RemoveReservationViewModel _removeReservationViewModel;
        private readonly Hotel _hotel;
        public RemoveReservationViewModel RemoveReservationView
        {
            get => _removeReservationViewModel;
            set
            {
                _removeReservationViewModel = value;
            }
        }
        public SearchCommand(Hotel hotel, RemoveReservationViewModel removeReservationViewModel)
        {
            _hotel = hotel;
            _removeReservationViewModel = removeReservationViewModel;
            _removeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        
        public override bool CanExecute(object? parameter)
        {
            if(_removeReservationViewModel != null)
            {
                return _removeReservationViewModel.ReservationID > 0;
            }
            else
            {
                return false;
            }
        }
        public override void Execute(object? parameter)
        {
            var reservation = _hotel.GetReservations().ToList().FirstOrDefault(r => r.ID == _removeReservationViewModel.ReservationID);
            if (reservation != null)
            {
                _removeReservationViewModel.ReservationContentControl = new ReservationViewModel(reservation).GetReservationDataContentControl();
            }
            else
            {
                MessageBox.Show("Rezervacija nije pronađena", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_removeReservationViewModel.ReservationID))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
