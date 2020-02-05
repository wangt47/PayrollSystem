/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 CommissionEmployee.cs
 Commission Employee class that extends Employee.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CommissionEmployee : Employee
{
    private decimal grossSales; // gross weekly sales
    private decimal commissionRate; // commission percentage

    // Before: five-parameter constuctor (firstName, 
    // lastName, socialSecurityNumber, grossSales, commissionRate)

    // After: eight-parameter constructor,
    // now includes three new int variables for BirthDate
    public CommissionEmployee (string firstName, string lastName,
        string socialSecurityNumber, int birthMonth, int birthDay, 
        int birthYear, decimal grossSales, decimal commissionRate)
        : base(firstName, lastName, socialSecurityNumber, 
                birthMonth, birthDay, birthYear)
    {
        GrossSales = grossSales; // validates gross sales
        CommissionRate = commissionRate; // validates commision rate
    }

    // property that gets and sets commission employee's gross sales
    public decimal GrossSales
    {
        get
        {
            return grossSales;
        }
        set
        {
            if (value < 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GrossSales)} must be >= 0");
            }
            grossSales = value;
        }
    }

    // property that gets and sets commission employee's commission rate
    public decimal CommissionRate
    {
        get
        {
            return commissionRate;
        }
        set
        {
            if (value <= 0 || value >= 1) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(CommissionRate)} must be > 0 and < 1");
            }
            commissionRate = value;
        }
    }

    // calculate earnings; overide abstract method Earnings in Employee
    public override decimal Earnings() => CommissionRate * GrossSales;

    // return string representation of CommissionEmployee object
    public override string ToString() =>
        $"comission employee: {base.ToString()}\n" +
        $"gross sales: {GrossSales:C}; " +
        $"commission rate: {CommissionRate:F2}";
}