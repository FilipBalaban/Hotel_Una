using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.ViewModels
{
    public class ReservationViewModel: BaseViewModel
    {
        private int _id;
        private int _roomNum;
        private string _firstName;
        private string _lastName;
        private DateTime _reservationDate;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _numberOfGuests;

        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public int RoomNum
        {
            get => _roomNum;
            set
            {
                _roomNum = value;
                OnPropertyChanged(nameof(RoomNum));
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public DateTime ReservationDate
        {
            get => _reservationDate;
            set
            {
                _reservationDate = value;
                OnPropertyChanged(nameof(ReservationDate));
            }
        }
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public int NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged(nameof(NumberOfGuests));
            }
        }
    }
}
