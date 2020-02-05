/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 Date.cs
 Date class declaration, to be used for 
 in the Employee abstract class to contain
 a BirthDate for every employee in an array.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Date
{
    private int month;
    private int day;
    public int Year { get; private set; }

    public Date(int month, int day, int year)
    {
        Month = month;
        Day = day;
        Year = year;
        Console.WriteLine($"Date object constructor for date {this}");
    }

    public int Month
    {
        get
        {
            return month;
        }
        private set
        {
            if (value <= 0 || value > 12) // validate month
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Month)} must be 1-12");
            }
            month = value;
        }
    }

    public int Day
    {
        get
        {
            return day;
        }
        private set
        {
            int[] daysPerMonth =
                {0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

            if (value <= 0 || value > daysPerMonth[Month])
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Day)} out of range for current month/year");
            }

            if (Month == 2 && value == 29 &&
                !(Year % 400 == 0 || (Year % 4 == 0 && Year % 100 != 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Day)} out of range for current month/year");
            }
            day = value;
        }
    }
    public override string ToString() => $"{Month}/{Day}/{Year}";
}
