using Hotel_Una.Exceptions;
using Hotel_Una.Models;
using Hotel_Una.Services;
using Hotel_Una.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel_Una.Commands
{
    public class UpdateReservationCommand : BaseCommand
    {
        private readonly Hotel _hotel;
        private readonly UpdateReservationViewModel _updateReservationViewModel;
        private readonly NavigationService _navigationService;

        public UpdateReservationCommand(Hotel hotel, UpdateReservationViewModel removeReservationViewModel, NavigationService navigationService)
        {
            _hotel = hotel;
            _updateReservationViewModel = removeReservationViewModel;
            _updateReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _navigationService = navigationService;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_updateReservationViewModel.ReservationInputContentControl))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _updateReservationViewModel.ReservationInputContentControl != null;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                Reservation reservation = new Reservation(_updateReservationViewModel.ReservationViewModel.RoomNum, _updateReservationViewModel.ReservationViewModel.FirstName, _updateReservationViewModel.ReservationViewModel.LastName, _updateReservationViewModel.ReservationViewModel.StartDate, _updateReservationViewModel.ReservationViewModel.EndDate, _updateReservationViewModel.ReservationViewModel.NumberOfGuests);
                if (reservation != null)
                {
                    _hotel.UpdateReservation(reservation);
                }
                else
                {
                    throw new NonExistentReservationException(reservation);
                }
                MessageBox.Show("Rezervacija je uspješno ažurirana", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationService.Navigate();
            }
            catch (NonExistentReservationException ex)
            {
                MessageBox.Show("Rezervacija nije pronađena", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
