/*
 CISP 405 Summer 2019 Tony Wang SID # 1443145
 
 Assignment 6 Description:
 Modify the payroll system from Ch. 12's example
 codes for Employee class and its subclasses by
 intregrating the Date class and use the PayrollSystemTest
 code to see if you've made a successful modification and
 the program outputs exactly from the assignment's instructions.
 

 PayrollSystemTest.cs
 The main class of this programming assignment,
 provided by the Assignment's word document to
 test if I made a successful modification of all
 of the employee classes and the console program
 output the exact output expected from the 
 Assignment's instructions.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class PayrollSystemTest
    {
        static void Main(string[] args)
        {
            // create derived class objects
            SalariedEmployee salariedEmployee1 = new SalariedEmployee("John",
               "Smith", "111-11-1111", 6, 15, 1944, 800M);
            HourlyEmployee hourlyEmployee1 = new HourlyEmployee("Karen",
               "Price", "222-22-2222", 12, 29, 1960, 16.75M, 40M);
            CommissionEmployee commissionEmployee1 =
               new CommissionEmployee("Sue", "Jones", "333-33-3333",
               9, 8, 1954, 10000M, .06M);
            BasePlusCommissionEmployee basePlusCommissionEmployee1 =
               new BasePlusCommissionEmployee("Bob", "Lewis", "444-44-4444",
               3, 2, 1965, 5000M, .04M, 300M);

            SalariedEmployee salariedEmployee2 = new SalariedEmployee("Afatarli",
               "Valeri", "511-11-1111", 1, 5, 1915, 600M);
            HourlyEmployee hourlyEmployee2 = new HourlyEmployee("Henry",
               "Buris", "622-22-2222", 2, 9, 1970, 14.75M, 36M);
            CommissionEmployee commissionEmployee2 =
               new CommissionEmployee("Anthony", "Doss", "733-33-3333",
               4, 18, 1944, 10045M, .07M);
            BasePlusCommissionEmployee basePlusCommissionEmployee2 =
               new BasePlusCommissionEmployee("Bob", "Lewis", "844-44-4444",
               5, 1, 1960, 4300M, .05M, 290M);

            SalariedEmployee salariedEmployee3 = new SalariedEmployee("Linda",
               "Ha", "911-11-1111", 7, 25, 1968, 400M);
            HourlyEmployee hourlyEmployee3 = new HourlyEmployee("Brian",
               "Louie", "122-22-2222", 8, 6, 1966, 18.85M, 60M);
            CommissionEmployee commissionEmployee3 =
               new CommissionEmployee("Leon", "Powell", "233-33-3333",
               10, 22, 1959, 10100M, .07M);
            BasePlusCommissionEmployee basePlusCommissionEmployee3 =
               new BasePlusCommissionEmployee("David", "Tong", "344-44-4444",
               11, 8, 1970, 5080M, .08M, 400M);

            // printing all types of Employee's info and their earnings

            Console.WriteLine("Employees processed individually:\n");

            Console.WriteLine("{0}\n{1}: {2:C}\n", salariedEmployee1, "earned", salariedEmployee1.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", hourlyEmployee1, "earned", hourlyEmployee1.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", commissionEmployee1, "earned", commissionEmployee1.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", basePlusCommissionEmployee1, "earned", basePlusCommissionEmployee1.Earnings());

            Console.WriteLine("{0}\n{1}: {2:C}\n", salariedEmployee2, "earned", salariedEmployee2.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", hourlyEmployee2, "earned", hourlyEmployee2.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", commissionEmployee2, "earned", commissionEmployee2.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", basePlusCommissionEmployee2, "earned", basePlusCommissionEmployee2.Earnings());


            Console.WriteLine("{0}\n{1}: {2:C}\n", salariedEmployee3, "earned", salariedEmployee3.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", hourlyEmployee3, "earned", hourlyEmployee3.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", commissionEmployee3, "earned", commissionEmployee3.Earnings());
            Console.WriteLine("{0}\n{1}: {2:C}\n", basePlusCommissionEmployee3, "earned", basePlusCommissionEmployee3.Earnings());


            // create four-element Employee array
            Employee[] employees = new Employee[12];

            // initialize array with Employees
            employees[0] = salariedEmployee1;
            employees[1] = hourlyEmployee1;
            employees[2] = commissionEmployee1;
            employees[3] = basePlusCommissionEmployee1;

            employees[4] = salariedEmployee2;
            employees[5] = hourlyEmployee2;
            employees[6] = commissionEmployee2;
            employees[7] = basePlusCommissionEmployee2;

            employees[8] = salariedEmployee3;
            employees[9] = hourlyEmployee3;
            employees[10] = commissionEmployee3;
            employees[11] = basePlusCommissionEmployee3;

            int currentMonth;

            // get and validate current month
            do
            {
                Console.Write("Enter the current month (1 - 12): ");
                currentMonth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            } while ((currentMonth < 1) || (currentMonth > 12));

            Console.WriteLine("Employees processed polymorphically:\n");

            // generically process each element in array employees
            foreach (var currentEmployee in employees)
            {
                Console.WriteLine(currentEmployee); // invokes ToString

                // determine whether element is a BasePlusCommissionEmployee
                if (currentEmployee is BasePlusCommissionEmployee)
                {
                    // downcast Employee reference to 
                    // BasePlusCommissionEmployee reference
                    BasePlusCommissionEmployee employee =
                       (BasePlusCommissionEmployee)currentEmployee;

                    employee.BaseSalary *= 1.1M;
                    Console.WriteLine(
                       "new base salary with 10% increase is: {0:C}",
                       employee.BaseSalary);
                } // end if

                // if month of employee's birthday, add $100 to salary
                if (currentMonth == currentEmployee.BirthDate.Month)
                    Console.WriteLine(
                       "earned {0:C} {1}\n", currentEmployee.Earnings(),
                       "plus $100.00 birthday bonus");
                else
                    Console.WriteLine(
                       "earned {0:C}\n", currentEmployee.Earnings());
            } // end for

            // get type name of each object in employees array
            for (int j = 0; j < employees.Length; j++)
                Console.WriteLine("Employee {0} is a {1}", j,
                   employees[j].GetType());

            // Pauses the console and showcase the results
            // prompt user any key to exit the console
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
