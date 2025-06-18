using Hotel_Una.Models;
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
        public CalendarViewModel(Hotel hotel)
        {
            _weeks = new ObservableCollection<Week>();
            SelectedDate = DateTime.Now.AddMonths(12);
        }
        private void DisplayCalendar()
        {
            int daysInMonth = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);
            int daysInWeekCounter = 1;
            Week week = new Week();
            for(int i = 1; i <= daysInMonth; i++)
            {
                string dayInMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, i).ToString("dddd");
                if(i == 1 && dayInMonth != "Sunday")
                {
                    int lastMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, 1).AddMonths(-1).Month;
                    int actualDayInWeek = (int)new DateTime(_selectedDate.Year, _selectedDate.Month, i).DayOfWeek;
                    int daysInLastMonth = DateTime.DaysInMonth(_selectedDate.Year, lastMonth);
                    for (int j = daysInLastMonth - actualDayInWeek + 1; j <= daysInLastMonth; j++)
                    {
                        string dayInLastMonth = new DateTime(_selectedDate.Year, lastMonth, j).ToString("dddd");
                        week.AssignDateToDay(j, dayInLastMonth);
                        daysInWeekCounter++;
                    }
                }
                week.AssignDateToDay(i, dayInMonth);

                if (daysInWeekCounter >= 7)
                {
                    _weeks.Add(week);
                    week = new Week();
                    daysInWeekCounter = 0;
                }
                daysInWeekCounter++;
                if (i == daysInMonth && dayInMonth != "Saturday")
                {
                    int nextMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, 1).AddMonths(1).Month;
                    int actualDayInWeek = (int)new DateTime(_selectedDate.Year, _selectedDate.Month, i).DayOfWeek;
                    int daysInNextMonth = DateTime.DaysInMonth(_selectedDate.Year, nextMonth);
                    for (int j = 1; j < 7 - actualDayInWeek; j++)
                    {
                        string dayInNextMonth = new DateTime(_selectedDate.Year, nextMonth, j).ToString("dddd");
                        week.AssignDateToDay(j, dayInNextMonth);
                        daysInWeekCounter++;
                    }
                    _weeks.Add(week);
                }
            }
        }
    }
}
