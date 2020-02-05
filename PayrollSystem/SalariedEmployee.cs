/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 SalariedEmployee.cs
 SalariedEmployee class that extends Employee.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SalariedEmployee : Employee
{
    private decimal weeklySalary;

    // Before: four-parameter constuctor (firstName, 
    // lastName, socialSecurityNumber, weeklySalary)

    // After: seven-parameter constructor,
    // now includes three new int variables for BirthDate
    public SalariedEmployee (string firstName, string lastName,
        string socialSecurityNumber, int birthMonth, int birthDay, 
        int birthYear, decimal weeklySalary)
        : base(firstName, lastName, socialSecurityNumber,
                birthMonth, birthDay, birthYear)
    {
        WeeklySalary = weeklySalary; // validate salary
    }

    // property that gets and sets salaried employee's salary
    public decimal WeeklySalary
    {
        get
        {
            return weeklySalary;
        }
        set
        {
            if (value < 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(WeeklySalary)} must be >= 0");
            }
            weeklySalary = value;
        }
    }

    // calculate earnings; overide abstract method Earnings in Employee
    public override decimal Earnings() => WeeklySalary;

    // return string representation of SalariedEmployee object
    public override string ToString() =>
        $"salaried employee: {base.ToString()}\n" +
        $"weekly salary: {WeeklySalary:C}";
}