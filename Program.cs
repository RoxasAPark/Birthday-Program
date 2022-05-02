using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayProgram
{
    class Program
    {
        class Birthday
        {
            private int[] daysInMonth;
            private string[] months;
            private int daysLeft;

            private int todaysMonth;
            private int todaysDay;
            private int birthMonth;
            private int birthDay;

            public Birthday()
            {
                daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                months = new string[] {"January", "February", "March", "April", "May", "June", "July",
                    "August", "September", "October", "November", "December"};

            }

            private void promptUserInput()
            {
                Console.WriteLine("What is today's month?");

                int todayM;
                while(!Int32.TryParse(Console.ReadLine(), out todayM) || (todayM < 1 || todayM > 12))
                {
                    Console.WriteLine("You need to input a number from 1 to 12");
                    Console.WriteLine("What is today's month?");
                }

                todaysMonth = todayM;

                Console.WriteLine("What is today's day?");

                int todayD;
                while (!Int32.TryParse(Console.ReadLine(), out todayD) || todayD > daysInMonth[todayM - 1] || todayD < 1)
                {
                    Console.WriteLine("There are " + daysInMonth[todayM - 1] + " days in the month of " + months[todayM - 1]);
                    Console.WriteLine("Therefore, you need to input a number from 1 to " + daysInMonth[todayM - 1]);
                    Console.WriteLine("What is today's day?");
                }

                todaysDay = todayD;

                Console.WriteLine("What is your birth month?");

                int birthM;
                while (!Int32.TryParse(Console.ReadLine(), out birthM) || (birthM < 1 || birthM > 12))
                {
                    Console.WriteLine("You need to input a number from 1 to 12");
                    Console.WriteLine("What is your birth month?");
                }

                birthMonth = birthM;

                Console.WriteLine("What is your birth day?");

                int birthD;
                while (!Int32.TryParse(Console.ReadLine(), out birthD) || birthD > daysInMonth[birthM - 1] || birthD < 1)
                {
                    Console.WriteLine("There are " + daysInMonth[birthM - 1] + " days in the month of " + months[birthM - 1]);
                    Console.WriteLine("Therefore, you need to input a number from 1 to " + daysInMonth[birthM - 1]);
                    Console.WriteLine("What is today's day?");
                }

                birthDay = birthD;
            }

            private void calculate()
            {
                if(todaysMonth == birthMonth)
                {
                    if (todaysDay == birthDay)
                    {
                        daysLeft = 0;
                    }
                    else if(todaysDay < birthDay)
                    {
                        daysLeft = birthDay - todaysDay;
                    }
                    else
                    {
                        daysLeft = 365 - (todaysDay - birthDay);
                    }
                       
                }
                else if(todaysMonth < birthMonth)
                {
                    int currentMonth = todaysMonth;
                    daysLeft = daysInMonth[todaysMonth - 1] - todaysDay;
                    currentMonth++;

                    while (currentMonth <= birthMonth - 1) 
                    {
                        daysLeft += daysInMonth[currentMonth - 1];
                        currentMonth++;
                    }

                    daysLeft += birthDay;
                }
                else
                {
                    int currentMonth = todaysMonth;
                    daysLeft = daysInMonth[todaysMonth - 1] - todaysDay;
                    currentMonth++;

                    while(currentMonth <= 12)
                    {
                        daysLeft += daysInMonth[currentMonth - 1];
                        currentMonth++;
                    }

                    currentMonth = 1;
                    while(currentMonth <= birthMonth -1)
                    {
                        daysLeft += daysInMonth[currentMonth - 1];
                        currentMonth++;
                    }

                    daysLeft += birthDay;
                }
            }

            private void outputResult()
            {
                if(daysLeft == 0)
                {
                    Console.WriteLine("There are " + daysInMonth[birthMonth - 1] + " days in the month of " + months[birthMonth - 1]);
                    Console.WriteLine();
                    Console.WriteLine("Happy Birthday!");
                }
                else
                {
                    Console.WriteLine("There are " + daysInMonth[birthMonth - 1] + " days in the month of " + months[birthMonth - 1]);
                    Console.WriteLine();
                    Console.WriteLine("Number of days until birthday " + birthMonth + "/" + birthDay + ": " + daysLeft);
                }
            }

            public void userInterface()
            {
                promptUserInput();
                calculate();
                outputResult();
            }
             
        }

        static void Main(string[] args)
        {
            Birthday bd = new Birthday();
            bd.userInterface();
        }
    }
}
