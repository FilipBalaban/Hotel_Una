using Hotel_Una.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.ViewModels
{
    public class CalendarViewModel: BaseViewModel
    {
        private readonly ObservableCollection<Week> _weeks;
        private DateTime _selectedDate;
        public string CurrentMonth =>  _selectedDate.ToString("MMMM", new CultureInfo("sr-Latn-RS")) + ' ' + _selectedDate.Year;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                DisplayCalendar();
            }
        }
        public IEnumerable<Week> Weeks => _weeks;
        public CalendarViewModel()
        {
            _weeks = new ObservableCollection<Week>();
            SelectedDate = DateTime.Now;
        }
        private void DisplayCalendar()
        {
            int days = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);
            int daysInWeekCounter = 0;
            Week week = new Week();
            for(int i = 1; i <= days; i++)
            {
                string dayInMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).ToString("dddd");
                if(daysInWeekCounter < 7)
                {
                    switch (dayInMonth)
                    {
                        case "Monday":
                            week.Monday = i;
                            break;
                        case "Tuesday":
                            week.Tuesday = i;
                            break;
                        case "Wednesday":
                            week.Wednesday = i;
                            break;
                        case "Thursday":
                            week.Thursday = i;
                            break;
                        case "Friday":
                            week.Friday = i;
                            break;
                        case "Saturday":
                            week.Saturday = i;
                            break;
                        case "Sunday":
                            week.Sunday = i;
                            break;
                    }
                }
                else
                {
                    _weeks.Add(week);
                    week = new Week();
                    daysInWeekCounter = 0;
                }
                daysInWeekCounter++;
            }
        }
    }
}
