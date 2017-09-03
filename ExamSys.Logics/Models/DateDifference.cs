using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSys.Logics.Models
{
    public class DateDifference
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public DateDifference(DateTime date1, DateTime date2)
        {
            int Subtracted_Days = 0;
            int Subtracted_Months = 0;
            int Subtracted_Years = 0;

            /*  SUbtract days of Date 1  */
            int date1_DaysLeft = 0;
            if (date1.Year % 4 == 0 && date1.Month == 2)
            {
                date1_DaysLeft = 29 - date1.Day;
            }
            else
            {
                int m = date1.Month;
                if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                {
                    date1_DaysLeft = 31 - date1.Day;
                }
                else if (m == 4 || m == 6 || m == 9 || m == 12)
                {
                    date1_DaysLeft = 30 - date1.Day;
                }
                else if (m == 2)
                {
                    date1_DaysLeft = 28 - date1.Day;
                }
            }



            Subtracted_Days = date1_DaysLeft + date2.Day;
            if (date2.Year % 4 == 0 && date2.Month == 2)
            {
                if (Subtracted_Days > 29)
                {
                    Subtracted_Days -= 29;
                    Subtracted_Months += 1;
                }
            }
            else
            {
                int m = date2.Month;
                if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                {
                    if (Subtracted_Days > 31)
                    {
                        Subtracted_Days -= 31;
                        Subtracted_Months += 1;
                    }
                }
                else if (m == 4 || m == 6 || m == 9 || m == 12)
                {
                    if (Subtracted_Days > 30)
                    {
                        Subtracted_Days -= 30;
                        Subtracted_Months += 1;
                    }
                }
                else if (m == 2)
                {
                    if (Subtracted_Days > 28)
                    {
                        Subtracted_Days -= 28;
                        Subtracted_Months += 1;
                    }
                }
            }

            Subtracted_Months += date2.Month + (12 - date1.Month);

            if (Subtracted_Months > 12)
            {
                Subtracted_Months = Subtracted_Months - 12;
                Subtracted_Years += 1;
            }

            Subtracted_Years += (date2.Year - date1.Year) - 1;

            Days = Subtracted_Days;
            Months = Subtracted_Months;
            Years = Subtracted_Years;
        }

    }


}