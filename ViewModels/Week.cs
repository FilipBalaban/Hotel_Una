using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.ViewModels
{
    public class Week
    {
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }

        public void AssignDateToDay(int date, string day)
        {
            switch (day)
            {
                case "Monday":
                    Monday = date;
                    break;
                case "Tuesday":
                    Tuesday = date;
                    break;
                case "Wednesday":
                    Wednesday = date;
                    break;
                case "Thursday":
                    Thursday = date;
                    break;
                case "Friday":
                    Friday = date;
                    break;
                case "Saturday":
                    Saturday = date;
                    break;
                case "Sunday":
                    Sunday = date;
                    break;
            }
        }
    }
}
