/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 BasePlusCommissionEmployee.cs
 BasePlusCommissionEmployee class that extends CommissionEmployee.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BasePlusCommissionEmployee : CommissionEmployee
{
    private decimal baseSalary; // base salary per week

    // Before: six-parameter constuctor (firstName, lastName,
    // socialSecurityNumber, grossSales, commissionRate, baseSalary)

    // After: eight-parameter constructor,
    // now includes three new int variables for BirthDate
    public BasePlusCommissionEmployee (string firstName, string lastName,
        string socialSecurityNumber, int birthMonth, int birthDay, int birthYear, 
        decimal grossSales, decimal commissionRate, decimal baseSalary)
        : base(firstName, lastName, socialSecurityNumber, birthMonth,
                birthDay, birthYear, grossSales, commissionRate)
    {
        BaseSalary = baseSalary; // validates base salary
    }

    // property that gets and sets
    // BasePlusCommissionEmployee's base salary
    public decimal BaseSalary
    {
        get
        {
            return baseSalary;
        }
        set
        {
            if (value < 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(BaseSalary)} must be >= 0");
            }
            baseSalary = value;
        }
    }

    // calculate earnings
    public override decimal Earnings() => BaseSalary + base.Earnings();

    // return string representation of SalariedEmployee object
    public override string ToString() =>
        $"base-salaried {base.ToString()}; base salary: {BaseSalary:C}";
}
