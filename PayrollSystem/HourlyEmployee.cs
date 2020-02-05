/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 HourlyEmployee.cs
 HourlyEmployee class that extends Employee.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HourlyEmployee : Employee
{
    private decimal wage; // wage per hour
    private decimal hours; // hours worked for the week

    // Before: five-parameter constructor (firstName, lastName, 
    // socialSecurityNumber, hourlyWage, hoursWorked)

    // After: eight-parameter constructor,
    // now includes three new int variables for BirthDate
    public HourlyEmployee (string firstName, string lastName,
        string socialSecurityNumber, int birthMonth, int birthDay, 
        int birthYear, decimal hourlyWage, decimal hoursWorked)
        : base(firstName, lastName, socialSecurityNumber,
                birthMonth, birthDay, birthYear)
    {
        Wage = hourlyWage; // validate hourly wage
        Hours = hoursWorked; // validate hours worked
    }

    // property that gets and sets hourly employee's wage
    public decimal Wage
    {
        get
        {
            return wage;
        }
        set
        {
            if (value < 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Wage)} must be >= 0");
            }

            wage = value;
        }
    }

    // property that gets and sets hourly employee's hours
    public decimal Hours
    {
        get
        {
            return hours;
        }
        set
        {
            if (value < 0 || value > 168) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Hours)} must be >= 0 and <= 168");
            }
            hours = value;
        }
    }

    // calculate earnings; overide Employee's abstract method Earnings
    public override decimal Earnings()
    {
        if (Hours <= 40) // no overtime
        {
            return Wage * Hours;
        }
        else
        {
            return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
        }
    }

    // return string representation of HourlyEmployee object
    public override string ToString() =>
        $"hourly employee: {base.ToString()}\n" +
        $"hourly wage: {Wage:C}; hours worked: {Hours:F2}";
}
