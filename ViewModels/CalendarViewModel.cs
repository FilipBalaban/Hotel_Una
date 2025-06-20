using Hotel_Una.Commands;
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
using System.Windows.Input;

namespace Hotel_Una.ViewModels
{
    public class CalendarViewModel: BaseViewModel
    {
        private readonly ObservableCollection<Week> _weeks;
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(CurrentMonth));
                DisplayCalendar();
            }
        }
        public string CurrentMonth => _selectedDate.ToString("MMMM", new CultureInfo("sr-Latn-RS")) + ' ' + _selectedDate.Year;
        public IEnumerable<Week> Weeks => _weeks;
        public ICommand LastMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public CalendarViewModel(Hotel hotel)
        {
            _weeks = new ObservableCollection<Week>();
            SelectedDate = DateTime.Now;
            LastMonthCommand = new LastMonthCommand(this);
            NextMonthCommand = new NextMonthCommand(this);
        }
        private void DisplayCalendar()
        {
            _weeks.Clear();
            int daysInMonth = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);
            int daysInWeekCounter = 1;
            Week week = new Week();
            for(int i = 1; i <= daysInMonth; i++)
            {
                string dayInMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, i).ToString("dddd");
                if(i == 1 && dayInMonth != "Sunday")
                {
                    int lastMonth = new DateTime(_selectedDate.Year, _selectedDate.Month, 1).AddMonths(-1).Month;
                    int year = _selectedDate.Year;
                    if(lastMonth == 12)
                    {
                        year--;
                    }

                    int actualDayInWeek = (int)new DateTime(_selectedDate.Year, _selectedDate.Month, i).DayOfWeek;
                    int daysInLastMonth = DateTime.DaysInMonth(year, lastMonth);
                    for (int j = daysInLastMonth - actualDayInWeek + 1; j <= daysInLastMonth; j++)
                    {
                        string dayInLastMonth = new DateTime(year, lastMonth, j).ToString("dddd");
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
                    int year = _selectedDate.Year;
                    if(nextMonth == 1)
                    {
                        year++;
                    }
                    int daysInNextMonth = DateTime.DaysInMonth(year, nextMonth);
                    for (int j = 1; j < 7 - actualDayInWeek; j++)
                    {
                        string dayInNextMonth = new DateTime(year, nextMonth, j).ToString("dddd");
                        week.AssignDateToDay(j, dayInNextMonth);
                        daysInWeekCounter++;
                    }
                    _weeks.Add(week);
                }
            }
        }
    }
}
