/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 Employee.cs
 Employee abstract base class but with implementation of Date class.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Employee abstract base class.
public abstract class Employee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }
        
    // adding three new int variables for employee's birth date
    public int BirthMonth { get; }
    public int BirthDay { get; }
    public int BirthYear { get; }

    // creating an empty BirthDate.
    public Date BirthDate;

    // Before: three-parameter constructor (firstName, lastName, socialSecurityNumber)

    // After: six-parameter constructor, now includes three new int variables for BirthDate
    public Employee (string firstName, string lastName, string socialSecurityNumber,
        int birthMonth, int birthDay, int birthYear)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
        BirthMonth = birthMonth;
        BirthDay = birthDay;
        BirthYear = birthYear;

        // creating BirthDate for other programs to enter birth date into
        // and print out their respective birth dates.
        BirthDate = new Date(BirthMonth, BirthDay, BirthYear);
    }

    // return string representation of Employee object, using properties
    public override string ToString() => $"{FirstName} {LastName}\n" 
        + $"social security number: {SocialSecurityNumber}\n"
        + $"birth date: {BirthDate.ToString()}";

    // abstract method overriden by derived classes
    public abstract decimal Earnings(); // no implementation here
}

